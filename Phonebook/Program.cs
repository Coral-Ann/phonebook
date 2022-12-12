// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Phonebook;

var _contextOptions = new DbContextOptionsBuilder<InmemoryContext>()
       .UseInMemoryDatabase("BloggingControllerTest")
       .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
       .Options;

using var context = new InmemoryContext(_contextOptions);
context.Database.EnsureCreated();

var service = new PhonebookService(context);

while (true)
{
    Console.WriteLine("Welcome to the Phonebook! Please select the action:");
    Console.WriteLine("1: Add a new contact");
    Console.WriteLine("2: Add a new phone number");
    Console.WriteLine("3: Show a contact");
    switch (Console.ReadLine())
    {
        case "1":
            await AddContact(service);
            break;

        case "2":
            await AddPhones(service);
            break;

        case "3":
            await DisplayContact(service);
            break;

        default: continue;
    }
}

static async Task AddContact(PhonebookService service)
{
    var name = InputName();
    var phones = new List<string>();
    InputPhones(phones);

    await service.AddContact(name, phones);
    Console.WriteLine($"Contact {name} added");
}

static async Task AddPhones(PhonebookService service)
{
    var name = InputName();
    if (!await service.ContactExists(name))
    {
        Console.WriteLine($"Contact {name} not found");
        return;
    }
    var phones = new List<string>();
    InputPhones(phones);
    await service.AddPhonesToContact(name, phones);
    Console.WriteLine($"Phones added to contact {name}");
}

static async Task DisplayContact(PhonebookService service)
{
    var name = InputName();
    var contact = await service.GetContact(name);
    if (contact == null)
        Console.WriteLine($"Contact {name} not found");
    else
    {
        Console.WriteLine(contact.Name);
        foreach (var phone in contact.Phones)
            Console.WriteLine(phone);
    }
}

static void InputPhones(List<string> phones)
{
    do
    {
        Console.WriteLine("Input phone number");
        phones.Add(Console.ReadLine());
        Console.WriteLine("Add another number? Y/N");
    }
    while (Console.ReadLine() == "Y");
}

static string InputName()
{
    Console.WriteLine("Input name of the contact");
    var name = Console.ReadLine();
    return name;
}