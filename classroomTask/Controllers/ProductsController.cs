using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task.Application.Dtos;
using Task.Application.Services;
namespace classroomTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productManager;
      
        public ProductsController(IProductService productService)
        {
            _productManager = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productList = await _productManager.GetListAsync(include: products => products.Include(p => p.Category));

            return Ok(productList);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var product = await _productManager.GetAsync(id.Value);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateDto createDto)
        {
            var createdProduct = await _productManager.AddAsync(createDto);

            return Ok(createdProduct);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody] ProductUpdateDto updateDto)
        {
            if (id == null) return NotFound();

            var updatedProduct = await _productManager.UpdateAsync(id.Value, updateDto);

            return Ok(updatedProduct);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var deletedProduct = await _productManager.DeleteAsync(id.Value);

            return Ok(deletedProduct);
        }

    }
}
