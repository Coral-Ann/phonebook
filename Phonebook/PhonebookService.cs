using Microsoft.EntityFrameworkCore;

namespace Phonebook
{
    public class PhonebookService
    {
        private readonly InmemoryContext _context;

        public PhonebookService(InmemoryContext context)
        {
            _context = context;
        }

        public async Task AddContact(string name, List<string> phones)
        {
            var contact = new Contact
            {
                Name = name,
                Phones = phones.Select(p => new Phone() { PhoneNumber = p }).ToList()
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task AddPhonesToContact(string name, List<string> phones)
        {
            var contact = await _context.Contacts.Where(c => c.Name == name).FirstOrDefaultAsync();
            if (contact == null)
                return;

            await _context.AddRangeAsync(phones.Select(p => new Phone
                {
                    ContactId = contact.ContactId,
                    PhoneNumber = p
                }));
            await _context.SaveChangesAsync();
        }  

        public async Task<bool> ContactExists(string name)
            => await _context.Contacts.AnyAsync(c => c.Name == name);

        public async Task<Contact?> GetContact(string name)
            => await _context.Contacts.Where(c => c.Name == name).FirstOrDefaultAsync();
    }
}
