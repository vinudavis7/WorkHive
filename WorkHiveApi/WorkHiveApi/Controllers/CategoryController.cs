using BLL.Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WorkHiveApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }



        [HttpGet("GetDetails/{id}")]
        public Category GetCategoryDetails(int id)
        {
            return _categoryService.GetCategory(id);
        }
        [HttpGet("GetAll")]
        public List<Category> GetAll()
        {
            return _categoryService.GetCategories();
        }
        [HttpGet("GetPopular")]
        public List<Category> GetPopularCategories()
        {
            return _categoryService.GetPopularCategories();
        }

        //// POST api/<CategoryController>
        //[HttpPost]
        //public Category Post([FromBody] Category category)
        //{
        //    return _categoryService.Createcategory(category);

        //}

        //// PUT api/<CategoryController>/5
        //[HttpPut]
        //public Category Put([FromBody] Category category)
        //{
        //    return _categoryService.UpdateCategory(category);

        //}

    }
}
