using PhoneBook.Models.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.IService
{
    public  interface ICategoryService
    {
        Task<IList<Category>> getAllCategory();
        Task<Guid> AddCategory(string categoryName);
        Task<Guid> DeleteCategory(Guid id);
        Task<Category>CategoryFindById(Guid id);
       
    }
}
