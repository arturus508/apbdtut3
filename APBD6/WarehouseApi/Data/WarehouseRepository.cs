using WarehouseApi.Models;
using System.Data.SqlClient;

namespace WarehouseApi.Data
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly string _connectionString;

        public WarehouseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<ProductWarehouse> GetProductWarehouses()
        {
            var productWarehouses = new List<ProductWarehouse>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Product_Warehouse", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productWarehouses.Add(new ProductWarehouse
                        {
                            Id = reader.GetInt32(0),
                            IdProduct = reader.GetInt32(1),
                            IdWarehouse = reader.GetInt32(2),
                            IdOrder = reader.GetInt32(3),
                            Price = reader.GetDouble(4),
                            CreatedAt = reader.GetDateTime(5)
                        });
                    }
                }
            }

            return productWarehouses;
        }

        public void AddProductWarehouse(ProductWarehouse productWarehouse)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Product_Warehouse (IdProduct, IdWarehouse, IdOrder, Price, CreatedAt) VALUES (@IdProduct, @IdWarehouse, @IdOrder, @Price, @CreatedAt)", connection);
                command.Parameters.AddWithValue("@IdProduct", productWarehouse.IdProduct);
                command.Parameters.AddWithValue("@IdWarehouse", productWarehouse.IdWarehouse);
                command.Parameters.AddWithValue("@IdOrder", productWarehouse.IdOrder);
                command.Parameters.AddWithValue("@Price", productWarehouse.Price);
                command.Parameters.AddWithValue("@CreatedAt", productWarehouse.CreatedAt);
                command.ExecuteNonQuery();
            }
        }
    }
}
