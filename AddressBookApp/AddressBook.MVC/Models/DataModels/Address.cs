using System.ComponentModel.DataAnnotations.Schema;

namespace AddressBook.MVC.Models.DataModels
{
    public class Address : ObjectBase
    {
        public int HouseNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }

        [ForeignKey("PersonId")]
        public Person Person { get; set; }
        public int PersonId { get; set; }
    }
}
