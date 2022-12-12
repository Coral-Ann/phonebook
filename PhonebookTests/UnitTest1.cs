using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace PhonebookTests
{
    public class PhonebookServiceTests
    {
        private InmemoryContext _context;

        [SetUp]
        public void Setup()
        {
            var _contextOptions = new DbContextOptionsBuilder<InmemoryContext>()
           .UseInMemoryDatabase("BloggingControllerTest")
           .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
           .Options;

            _context = new InmemoryContext(_contextOptions);
        }

        /*
         * TODO: Write tests for every public method in PhonebookService. 
         * Example below checks that AddContact correctly adds given contact to the table.
         
        [TestCase("John Smith", new[] { "1234567", "978394562" })]
        public void AddContact_WorksFine(string name, string[] phones)
        {
            var sut = new PhonebookService(_context);

            sut.AddContact(name, phones.ToList());

            var contact = _context.Contacts.Single(c => c.Name == name);
            contact.ShouldNotBeNull("Contact is not present in the table");
            contact.Phones.Count().ShouldBe(phones.Length, "Not all phones are present in the table");
            foreach (var phone in phones)
                contact.Phones.ShouldContain(phone, $"{phone} is not present in the table");
        }
        */
    }
}