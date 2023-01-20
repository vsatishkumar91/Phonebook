using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models.Data.Models;
using PhoneBook.Models.Dtos.Models;
using PhoneBook.Models.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Service.IService
{
    public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContact();
        Task<Guid> AddContact(ContactModel addContactRequest);
       // Task<IList<Contact>> GetContactsByCategory(string categoryRequest, int pageSize, int pageNumber);
        Task<Guid> UpdateContact(ContactModel updateContactRequest, Guid id);
        Task<IEnumerable<Contact>> GetContacts(int pageSize, int pageNumber, string firstName, string searchKey);
        Task<Contact>DeleteContact(Guid id);
        Task<Contact> GetContactById(Guid id);
        Task<IList<Contact>> GetAllContactByCategoryId(Guid id);
    }
}
