using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class ContactFilter : FilterBase
    {
        public string FirstName { get; set; } 
        public string SearchKey { get; set; }

    }
}
