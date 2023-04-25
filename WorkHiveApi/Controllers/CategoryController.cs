using BLL.Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }



        [HttpGet("GetDetails/{id}")]
        public IActionResult GetCategoryDetails(int id)
        {
            try
            {
                var category = _categoryService.GetCategory(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var categoryList = _categoryService.GetCategories();
                return Ok(categoryList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
        //to get category with more number of jobs
        [HttpGet("GetPopular")]
        public IActionResult GetPopularCategories()
        {
            try
            {
                var categoryList = _categoryService.GetPopularCategories();
                return Ok(categoryList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] string categoryName)
        {
            try
            {
                var result = _categoryService.Createcategory(categoryName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                return StatusCode(StatusCodes.Status500InternalServerError, "An unexpected error occurred");
            }
        }
    }
}
