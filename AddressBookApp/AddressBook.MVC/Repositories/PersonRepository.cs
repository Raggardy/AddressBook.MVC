using AddressBook.MVC.Contracts;
using AddressBook.MVC.Models.DataModels;

namespace AddressBook.MVC.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
