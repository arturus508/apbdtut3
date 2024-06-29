using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using AnimalApi.Models;

namespace AnimalApi.Data
{
    public class AnimalRepository
    {
        private readonly string _connectionString;

        public AnimalRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Animal> GetAnimals(string orderBy = "name")
        {
            var animals = new List<Animal>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM Animals ORDER BY {orderBy}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            animals.Add(new Animal
                            {
                                IdAnimal = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Description = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Category = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Area = reader.IsDBNull(4) ? null : reader.GetString(4)
                            });
                        }
                    }
                }
            }

            return animals;
        }

        public void AddAnimal(Animal animal)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Animals (Name, Description, Category, Area) VALUES (@Name, @Description, @Category, @Area)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", animal.Name);
                    command.Parameters.AddWithValue("@Description", animal.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", animal.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Area", animal.Area ?? (object)DBNull.Value);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void UpdateAnimal(int id, Animal animal)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "UPDATE Animals SET Name = @Name, Description = @Description, Category = @Category, Area = @Area WHERE IdAnimal = @IdAnimal";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", animal.Name);
                    command.Parameters.AddWithValue("@Description", animal.Description ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Category", animal.Category ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Area", animal.Area ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@IdAnimal", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteAnimal(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Animals WHERE IdAnimal = @IdAnimal";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdAnimal", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
