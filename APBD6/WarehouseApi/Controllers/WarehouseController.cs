using Microsoft.AspNetCore.Mvc;
using WarehouseApi.Data;
using WarehouseApi.Models;

namespace WarehouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        [HttpGet]
        public IActionResult GetProductWarehouses()
        {
            var productWarehouses = _warehouseRepository.GetProductWarehouses();
            return Ok(productWarehouses);
        }

        [HttpPost]
        public IActionResult AddProductWarehouse([FromBody] ProductWarehouse productWarehouse)
        {
            if (productWarehouse == null)
            {
                return BadRequest("Invalid product warehouse data.");
            }

            _warehouseRepository.AddProductWarehouse(productWarehouse);
            return Ok(productWarehouse);
        }
    }
}
