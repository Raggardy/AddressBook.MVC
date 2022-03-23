namespace AddressBook.MVC.Models.DataModels
{
    public class Employer : ObjectBase
    {
        public string? Name { get; set; }
        public string? Business { get; set; }
        public string? Number { get; set; }


        public List<Person> People { get; set; }
        public int PersonId { get; set; }
    }
}