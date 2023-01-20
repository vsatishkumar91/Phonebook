using PhoneBook.Models.Data.Models;
using PhoneBook.Repository.IRepository;
using PhoneBook.Repository.RepositoryImp;
using PhoneBook.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.ContactService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository) { 
            this.categoryRepository = categoryRepository;
        }

        public async Task<Guid> AddCategory(string categoryName)
        {
           
            return await categoryRepository.AddCategory(categoryName.ToLower());
        }

        public async Task<Category> CategoryFindById(Guid id)
        {
          var category= await categoryRepository.CategoryFindById(id);
            return category;
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
            
            return await categoryRepository.DeleteCategory(id);
          
        }

        public async Task<IList<Category>> getAllCategory()
        {
            return await categoryRepository.GetAllCategory();
        }
    }
}
