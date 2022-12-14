using System.ComponentModel.DataAnnotations;

namespace Phonebook
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        
        public string? Name { get; set; }

        public IList<Phone> Phones { get; set; } = new List<Phone>();

    }
}