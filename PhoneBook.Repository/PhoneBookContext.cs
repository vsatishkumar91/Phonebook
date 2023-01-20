using Microsoft.EntityFrameworkCore;
using PhoneBook.Models.Data.Models;

namespace PhoneBook.Repository
{
    public class PhoneBookContext:DbContext
    {
        public PhoneBookContext(DbContextOptions options):base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
