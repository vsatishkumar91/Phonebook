using PhoneBook.Models.Data.Models;
using PhoneBook.Models.Dtos.Models;

namespace Phone_Book_Backend.Extensions
{
    public static class Extensions
    {
        public static ContactDto AsDto(this Contact item)
        {
            return new ContactDto(item.Id, item.FirstName, item.LastName, item.Email, item.Dob, item.PrimaryNumber, item.SecondaryNumber, item.CategoryDto);
        }
    }
}
