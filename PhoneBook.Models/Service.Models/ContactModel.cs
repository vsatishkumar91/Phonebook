using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneBook.Models.Data.Models;

namespace PhoneBook.Models.Service.Models
{
    public class ContactModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string PrimaryNumber { get; set; }
        public string SecondaryNumber { get; set; }
        public Guid CategoryId { get; set; }
    }
}
