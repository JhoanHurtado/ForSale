using Commons.Commons;
using Microsoft.AspNetCore.Mvc;
using Users.Business.Intefaces;
using Users.Dto.Dtos;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness _IuserBusiness;

        public UserController(IUserBusiness iuserBusiness)
        {
            _IuserBusiness = iuserBusiness;
        }

        //Path: api/[controller]
        [HttpPost]
        public async Task<BusinessResult<UserDto>> Post(UserDto userDto)
        {
            return await _IuserBusiness.Add(userDto);
        }

        //Path: api/[controller]
        [HttpPut]
        public async Task<BusinessResult<UserDto>> Put(UserDto userDto)
        {
            return await _IuserBusiness.Update(userDto);
        }

        //Path: api/[controller]/email
        [HttpGet("{email}")]
        public async Task<BusinessResult<List<UserDto>>> Get(string email)
        {
            return await _IuserBusiness.Find(email);
        }
    }
}
