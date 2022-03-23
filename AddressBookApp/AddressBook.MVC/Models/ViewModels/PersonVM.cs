using AddressBook.MVC.Models.DataModels;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.MVC.Models.ViewModels
{
    public class PersonVM
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string LastName { get; set; }


        public DateTime Birthday { get; set; }

        [Display(Name = "Partner's Name")]
        public string? PartnerName { get; set; }      

       
        public Employer? Employer { get; set; }       

        public Address Address { get; set; }

    }
}
