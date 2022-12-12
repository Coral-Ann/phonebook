using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Phonebook
{
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }

        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(Contact.ContactId))]
        public int ContactId { get; set; }

    }
}