using Microsoft.EntityFrameworkCore;

namespace Phonebook
{
    public class InmemoryContext: DbContext
    {
        public InmemoryContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Phone> Phones { get; set; }

    }
}
