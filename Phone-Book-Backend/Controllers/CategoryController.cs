using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models.Data.Models;
using PhoneBook.Service.IService;

namespace Phone_Book_Backend.Controllers
{
    [ApiController]
    [Route("api/category/")]
    public class CategoryController: ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService) { 
       
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory() {
            IList<Category>categoryDtos=await categoryService.getAllCategory();
            return Ok(categoryDtos);
        }

        [HttpPost]
        public async Task<IActionResult>AddCategory(string categoryName)
        {
            return Ok(await categoryService.AddCategory(categoryName));
        }

        [HttpGet]
        [Route("/findById")]
        public async Task<IActionResult>GetCategoryById(Guid id)
        {
            return Ok(categoryService.CategoryFindById(id));
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteCategory(Guid id)
        {
            var category=await categoryService.DeleteCategory(id);
            if(category==null)
            {
                return NotFound();
            }
            return Ok(category);
        }
    }
}
