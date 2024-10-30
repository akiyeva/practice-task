using Microsoft.AspNetCore.Mvc;
using Task.Application.Services.Contracts;
namespace classroomTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productManager;
      
        public ProductsController(IProductService productManager)
        {
            _productManager = productManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
        }
    }
}
