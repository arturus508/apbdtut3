using WarehouseApi.Models;

namespace WarehouseApi.Data
{
    public interface IWarehouseRepository
    {
        IEnumerable<ProductWarehouse> GetProductWarehouses();
        void AddProductWarehouse(ProductWarehouse productWarehouse);
    }
}
