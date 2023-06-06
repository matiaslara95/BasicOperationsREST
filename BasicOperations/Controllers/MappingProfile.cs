using AutoMapper;
using BasicOperations.Entity.DataTransferObjects;
using BasicOperations.Entity.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicOperations.Controllers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserForRegistration, User>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
