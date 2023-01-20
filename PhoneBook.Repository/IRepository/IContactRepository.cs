using PhoneBook.Models.Data.Models;
using PhoneBook.Models.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Repository.Repository
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContact();

        Task<Guid> AddContact(ContactModel addContactRequest);

        Task<Guid> UpdateContact(ContactModel contact, Guid id);

        Task<IList<Contact>> GetContacts(int pageSize, int pageNumber, string firstName, string searchKey);

       void DeleteContact(Contact contact);

       Task<Contact> GetContactById(Guid id);
        Task<IList<Contact>> GetAllContactByCategoryId(Guid id);
    }
}
