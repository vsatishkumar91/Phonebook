using Microsoft.EntityFrameworkCore;
using PhoneBook.Models.Data.Models;
using PhoneBook.Models.Service.Models;
using PhoneBook.Repository.Repository;
namespace PhoneBook.Repository.RepositoryImp
{
    public class ContactRepository : IContactRepository
    {
        private readonly PhoneBookContext contactRepository;

        public ContactRepository(PhoneBookContext contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public async Task<Guid> AddContact(ContactModel addContactRequest)
        {
            Contact contact = new Contact()
            {
                Id = Guid.NewGuid(),
                FirstName = addContactRequest.FirstName,
                LastName = addContactRequest.LastName,
                Email = addContactRequest.Email,
                Dob = addContactRequest.Dob,
                PrimaryNumber = addContactRequest.PrimaryNumber,
                SecondaryNumber = addContactRequest.SecondaryNumber,
                CreatedBy = "arghya",
                CategoryId= addContactRequest.CategoryId,
            };
            await contactRepository.Contacts.AddAsync(contact);
            await contactRepository.SaveChangesAsync();
            return contact.Id;
        }

        public async Task<IEnumerable<Contact>> GetAllContact()
        {
            var contactList = await contactRepository.Contacts.Include(c=>c.CategoryDto).ToListAsync();
            return contactList;
        }
        public async Task<Guid> UpdateContact(ContactModel updateContactRequest, Guid id)
        {
            var contactInDb = await contactRepository.Contacts.FindAsync(id);
            if (contactInDb == null)
            {
               return Guid.Empty;
            }
            contactInDb.FirstName = updateContactRequest.FirstName;
            contactInDb.LastName = updateContactRequest.LastName;
            contactInDb.Email = updateContactRequest.Email;
            contactInDb.PrimaryNumber = updateContactRequest.PrimaryNumber;
            contactInDb.SecondaryNumber = updateContactRequest.SecondaryNumber;
            contactInDb.Dob = updateContactRequest.Dob;
            contactInDb.CategoryId= updateContactRequest.CategoryId;
            await contactRepository.SaveChangesAsync();
            return contactInDb.Id;
        }
        public async Task<Contact> GetContactById(Guid id)
        {
            var contact = await contactRepository.Contacts.FindAsync(id);
            return contact;
        }

        public async void DeleteContact(Contact contact)
        {
            contactRepository.Contacts.Remove(contact);
            await contactRepository.SaveChangesAsync();
        }


        public async Task<IList<Contact>> GetContacts(int pageSize, int pageNumber, string firstName, string searchKey)
        {

            var collections = contactRepository.Contacts as IQueryable<Contact>;

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                firstName = firstName.Trim();
                collections = collections.Where(c => c.FirstName.ToLower().StartsWith(firstName.ToLower()));

            }

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                searchKey = searchKey.Trim();
                collections = collections.Where(c => c.FirstName.Contains(searchKey));
            }

            return await collections.OrderBy(c => c.FirstName).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();
        }

        public async Task<IList<Contact>> GetAllContactByCategoryId(Guid id)
        {
            var contactList=await contactRepository.Contacts.Where(c=>c.CategoryId==id).ToListAsync();
            return contactList;
        }
    }
}
