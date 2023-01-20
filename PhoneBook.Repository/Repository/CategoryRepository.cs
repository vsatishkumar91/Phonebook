using Microsoft.EntityFrameworkCore;
using PhoneBook.Models.Data.Models;
using PhoneBook.Repository.IRepository;
using PhoneBook.Repository.RepositoryImp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PhoneBookContext phoneBookContext;
        public CategoryRepository(PhoneBookContext phoneBookContext) {
            this.phoneBookContext = phoneBookContext;
         }
        public async Task<IList<Category>> GetAllCategory()
        {
            var categories = await phoneBookContext.Category.ToListAsync();
            return categories;

        }
        public async Task<Guid> AddCategory(string categoryName)
        {
            
            var category=await phoneBookContext.Category.FirstOrDefaultAsync(c=>c.CategoryName== categoryName);
            if(category!=null)
            {
                return category.CategoryId;
            }
            
            Category createdCategory = new Category()
            {
                CategoryId = Guid.NewGuid(),
                CategoryName = categoryName
            };
            await phoneBookContext.Category.AddAsync(createdCategory);
            await phoneBookContext.SaveChangesAsync();
            return createdCategory.CategoryId;
        }

        public async Task<Guid> DeleteCategory(Guid id)
        {
           Category category= await CategoryFindById(id);
            if (category == null)
            {
                return category.CategoryId;
            }
             phoneBookContext.Category.Remove(category);
            await phoneBookContext.SaveChangesAsync();
            return category.CategoryId;
        }

        public async Task<Category> CategoryFindById(Guid id)
        {
            var contact = await phoneBookContext.Category.FindAsync(id);
            return contact;
        }

        
    }
}
