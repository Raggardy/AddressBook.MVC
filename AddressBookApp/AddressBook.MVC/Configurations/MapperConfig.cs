using AddressBook.MVC.Models.DataModels;
using AddressBook.MVC.Models.ViewModels;
using AutoMapper;

namespace AddressBook.MVC.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Person, PersonVM>().ReverseMap();
        }
    }
}
