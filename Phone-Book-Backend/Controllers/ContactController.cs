using Microsoft.AspNetCore.Mvc;
using Phone_Book_Backend.Extensions;
using PhoneBook.Exceptions;
using PhoneBook.Models.Data.Models;
using PhoneBook.Models.Dtos.Models;
using PhoneBook.Models.Service.Models;
using PhoneBook.Service.ContactService;
using PhoneBook.Service.IService;
using PhoneBook.Service.ServiceImp;

namespace Phone_Book_Backend.Controllers
{
    [ApiController]
    [Route("api/contact/")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        private readonly ILogger<ContactController> logger;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            this.contactService = contactService;
            this.logger = logger;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactDto>>> GetAllContacts()
        {
            var contsctList = (await contactService.GetAllContact()).Select(item=>item.AsDto());
            return Ok(contsctList);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddContact(CreateContactDto addContactDto)
        {
            var addContactRequest = new ContactModel()
            {
                FirstName = addContactDto.FirstName,
                LastName= addContactDto.LastName,
                Email=addContactDto.Email,
                Dob=addContactDto.Dob,
                PrimaryNumber=addContactDto.PrimaryNumber,
                SecondaryNumber=addContactDto.SecondaryNumber,
                CategoryId=addContactDto.CategoryId,
            };
            var contactId = await contactService.AddContact(addContactRequest);
            return CreatedAtAction(nameof(AddContact), new { id = contactId });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> UpdateContact([FromRoute] Guid id, UpdateContactDto updateContactRequest)
        {
            var updateContact = new ContactModel()
            {
                FirstName = updateContactRequest.FirstName,
                LastName = updateContactRequest.LastName,
                Email = updateContactRequest.Email,
                Dob = updateContactRequest.Dob,
                PrimaryNumber = updateContactRequest.PrimaryNumber,
                SecondaryNumber = updateContactRequest.SecondaryNumber,
                CategoryId = updateContactRequest.CategoryId,
            };
            var contact = await contactService.UpdateContact(updateContact, id);
            if(contact == null)
            {
                logger.LogInformation($"contact not found with contactId {id}");
                return NotFound();
            }
            return Ok(contact);
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteContact(Guid id)
        {
            var contact = await contactService.DeleteContact(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }


        [HttpGet]
        [Route("find/")]
        public async Task<ActionResult> GetContactById(Guid id)
        {
            var contact = await contactService.GetContactById(id);
            if (contact != null)
            {
                return Ok(contact);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("filter/")]
        public async Task<ActionResult> GetContacts(string ?firstName, string ?searchKey, int pageSize, int pageNumber)
        {
            var contactList = (await contactService.GetContacts( pageSize, pageNumber, firstName, searchKey))?
                .Select(contact => contact.AsDto());
            if (contactList.Count() == 0)
            {
                return NotFound();
            }
            logger.LogInformation("contacts in getContacts: ", contactList.Count());
            return Ok(contactList);
        }

        [HttpGet]
        [Route("/categoryId")]
        public async Task<ActionResult> GetAllContactByCategoryId(Guid id)
        {
            var contactList = await contactService.GetAllContactByCategoryId(id);
            if (contactList == null)
            {
                return NotFound();

            }
            return Ok(contactList);
        }
    }
}
