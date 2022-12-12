using Microsoft.EntityFrameworkCore;

namespace Phonebook
{
    public class InmemoryContext: DbContext
    {
        public InmemoryContext(DbContextOptions options) : base(options) { }

        // TODO: Implement your tables classes in their own files and list the properties for them here
        // public DbSet<MyTableRecord> MyTableRecords { get; set; }
    }
}
