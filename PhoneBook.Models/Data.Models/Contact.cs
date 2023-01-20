using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PhoneBook.Models.Service.Models;

namespace PhoneBook.Models.Data.Models
{
    public class Contact
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string PrimaryNumber { get; set; }
        public string SecondaryNumber { get; set; }
        public string CreatedBy { get; set; }
        public string? LastUpdatedBy { get; set; }

        [ForeignKey("CategoryDto")]
        public Guid CategoryId { get; set; }
        public virtual Category CategoryDto { get; set; }
    }
}
