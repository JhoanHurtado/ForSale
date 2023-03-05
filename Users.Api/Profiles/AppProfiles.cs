
using AutoMapper;
using Users.Dto.Dtos;
using Users.Entity.Entities;

namespace Users.Api.Profiles
{
    public class AppProfiles: Profile
    {
        public AppProfiles()
        {
            this.CreateMap<User,UserDto > ().ReverseMap();
        }
    }
}
