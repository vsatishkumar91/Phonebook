using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PhoneBook.Models.Data.Models
{
    public class Category
    {

        [Key]
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Contact> ContactDtos { get; } = new List<Contact>();
    }
}
