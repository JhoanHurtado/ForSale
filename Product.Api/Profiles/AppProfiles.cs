using AutoMapper;
using Product.Dto.Dto;
using prod = Product.Entity.Entity;

namespace Product.Api.Profiles
{
    public class AppProfiles: Profile
    {
        public AppProfiles()
        {
            this.CreateMap<prod.Product,ProductDto > ().ReverseMap();
        }
    }
}
