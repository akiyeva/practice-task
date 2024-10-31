using Microsoft.AspNetCore.Mvc;
using Task.Application.Dtos;
using Task.Application.Services;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryManager;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryManager = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categoryList = await _categoryManager.GetListAsync();

            return Ok(categoryList);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> Get(int? id)
        {
            if (id == null) return NotFound();

            var category = await _categoryManager.GetAsync(id.Value);

            return Ok(category);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CategoryCreateDto createDto)
        {
            var createdCategory = await _categoryManager.AddAsync(createDto);

            return Ok(createdCategory);
        }

        [HttpPut("{id?}")]
        public async Task<IActionResult> Put(int? id, [FromBody] CategoryUpdateDto updateDto)
        {
            if (id == null) return NotFound();

            var updatedCategory = await _categoryManager.UpdateAsync(id.Value, updateDto);

            return Ok(updatedCategory);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var deletedCategory = await _categoryManager.DeleteAsync(id.Value);

            return Ok(deletedCategory);
        }
    }

}

