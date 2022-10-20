using AutoMapper;
using GOCompanies.Models;
using GOCompanies.ViewModels;

namespace GOCompanies
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegistrationViewModel, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }

}
