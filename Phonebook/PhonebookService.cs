﻿namespace Phonebook
{
    public class PhonebookService
    {
        private readonly InmemoryContext _context;

        public PhonebookService(InmemoryContext context)
        {
            _context = context;
        }

        // TODO: Implement the following methods

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

        public Task AddPhonesToContact(string name, List<string> phones)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ContactExists(string name)
        {
            throw new NotImplementedException();
        }

        // TODO: For this method, you have to design a class to output the required data,
        // which is: contact name and list of contact phones

        public Task<Contact> GetContact(string name)
        {
            throw new NotImplementedException();
        }
    }
}
