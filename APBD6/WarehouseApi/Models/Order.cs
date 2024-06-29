namespace WarehouseApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? FullfilledAt { get; set; }
    }
}
