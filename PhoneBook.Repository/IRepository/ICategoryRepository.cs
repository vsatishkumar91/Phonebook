using PhoneBook.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.IRepository
{
    public interface ICategoryRepository
    {
        public Task<IList<Category>> GetAllCategory();
        Task<Guid> AddCategory(string name);
        Task<Guid> DeleteCategory(Guid id);
        Task<Category>CategoryFindById(Guid id);

    }
}
