    using API.Models;
using Application.User.Registration;
using AutoMapper;
using EFData.Models;

namespace API.AuthServices
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<RegistrationUserQuery, RegistrationQuery>().ForMember(x => x.Role, x => x.MapFrom(z => Roles.User));
            CreateMap<RegistrationQuery, RegistrationEntity>();
        }
    }
}
