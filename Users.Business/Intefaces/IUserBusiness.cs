using Commons.Commons;
using Users.Dto.Dtos;

namespace Users.Business.Intefaces
{
    public interface IUserBusiness
    {
        //Task<BusinessResult<List<UserDto>>> Get();
        Task<BusinessResult<List<UserDto>>> Find(string Filtro);
        Task<BusinessResult<UserDto>> Add(UserDto user);
        Task<BusinessResult<UserDto>> Update(UserDto user);
        //Task<BusinessResult<UserDto>> Delete(int userId);
    }
}
