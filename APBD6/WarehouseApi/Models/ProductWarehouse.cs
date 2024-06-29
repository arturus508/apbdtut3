namespace WarehouseApi.Models
{
    public class ProductWarehouse
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int IdWarehouse { get; set; }
        public int IdOrder { get; set; }
        public double Price { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
