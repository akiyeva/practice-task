using Microsoft.AspNetCore.Mvc;
using Task.Application.Services.Contracts;

namespace Task.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        public readonly ICategoryService _categoryManager;
        public CategoriesController(ICategoryService categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
        }

    }
}
