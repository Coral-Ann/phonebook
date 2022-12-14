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

        public Task AddContact(string name, List<string> phones)
        {
            var contact = new Contact
            {
                Name = name,
                Phones = phones.Select(p => new Phone() { PhoneNumber = p }).ToList()
            };

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task AddPhonesToContact(string name, List<string> phones)
        {
            var contact = await _context.Contacts.Where(c => c.Name == name).FirstOrDefaultAsync();
            if (contact != null) 
            {
                foreach (var phone in phones)
                {
                    var dbPhone = new Phone
                    {
                        ContactId = contact.ContactId,
                        PhoneNumber = phone
                    };
                    _context.Add(dbPhone);
                }
                _context.SaveChanges();
            }
        }    

        public async Task<bool> ContactExists(string name)
        {
            var contact = await _context.Contacts.Where(c => c.Name == name).FirstOrDefaultAsync();
            return contact != null;
        }

        public async Task<Contact?> GetContact(string name)
        {
             return await _context.Contacts.Where(c => c.Name == name).FirstOrDefaultAsync();
        }
    }
}
