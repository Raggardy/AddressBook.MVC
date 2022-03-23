using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.MVC.Models.DataModels
{
    public class Person : ObjectBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public DateTime Birthday { get; set; }
        public string? PartnerName { get; set; }

        // Nav properties

        [ForeignKey("EmployerId")]
        public Employer? Employer { get; set; }
        public int EmployerId { get; set; }
        
        public Address? Address { get; set; }
        public int? AddressId { get; set; }
    }
}
