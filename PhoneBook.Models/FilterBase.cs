using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Models
{
    public class FilterBase
    {
        public FilterBase()
        {
            this.PageNumber= 1;
            this.PageSize= 10;
        }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
