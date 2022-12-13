using Microsoft.EntityFrameworkCore;

namespace Phonebook
{
    public class InmemoryContext: DbContext
    {
        public InmemoryContext(DbContextOptions options) : base(options) { }

        DbSet<Contact> Contacts { get; set; }

        DbSet<Phone> Phones { get; set; }

    }
}
