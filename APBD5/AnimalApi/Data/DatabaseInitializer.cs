using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace AnimalApi.Data
{
    public class DatabaseInitializer
    {
        private readonly string _connectionString;

        public DatabaseInitializer(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Initialize()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string createTableQuery = @"
                    IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Animals' and xtype='U')
                    CREATE TABLE Animals (
                        IdAnimal INT PRIMARY KEY IDENTITY(1,1),
                        Name NVARCHAR(100) NOT NULL,
                        Description NVARCHAR(500),
                        Category NVARCHAR(50),
                        Area NVARCHAR(50)
                    );";

                using (SqlCommand command = new SqlCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

