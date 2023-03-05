using AutoMapper;
using Commons.Commons;
using CryptoHelper;
using Users.Business.Intefaces;
using Users.Dto.Dtos;
using Users.Entity.Entities;
using Users.Interfaces.Interfaces;

namespace Users.Business.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserInterfaces _IUser;
        private readonly IMapper _mapper;

        public UserBusiness(IUserInterfaces iUser, IMapper mapper)
        {
            _IUser = iUser;
            _mapper = mapper;
        }

        public async Task<BusinessResult<UserDto>> Add(UserDto userDto)
        {
            try
            {
                var userExist = await Find(userDto.Email);
                if (userExist.Result.Count > 0)
                {
                    return BusinessResult<UserDto>.Success(null, $"Este Email: {userDto.Email} ya se encuentra registrado, por favor ingrese sesion");
                }
                //Encriptar contraseña
                userDto.Password = Crypto.HashPassword(userDto.Password);
                userDto.Id =  Guid.NewGuid().ToString();
                var user = _mapper.Map<User>(userDto);
                var userNew = await _IUser.Add(user);
                if (userNew == null)
                {
                    return BusinessResult<UserDto>.Success(null, "User no agregado");
                }
                var userNewDto = _mapper.Map<UserDto>(userNew);
                return BusinessResult<UserDto>.Success(userNewDto, "User agregado");
            }
            catch (Exception ex)
            {
                return BusinessResult<UserDto>.Success(null, "Hubo un error al agregar los productos");
            }
        }

        public async Task<BusinessResult<List<UserDto>>> Find(string Filtro)
        {
            try
            {
                var users = await _IUser.Find(x => x.Email.Equals(Filtro.ToLower()));
                var userDto = _mapper.Map<List<UserDto>>(users);
                return BusinessResult<List<UserDto>>.Success(userDto, "Users");
            }
            catch (Exception)
            {
                return BusinessResult<List<UserDto>>.Success(null, "hubo un error al consultar");
            }
        }

        public async Task<BusinessResult<UserDto>> Update(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var usuarioUpdate = await _IUser.Update(user);
                if (!usuarioUpdate)
                {
                    return BusinessResult<UserDto>.Success(null, "Usuario no actualizado");
                }
                return BusinessResult<UserDto>.Success(userDto, "Usuario actualizado");
            }
            catch (Exception ex)
            {
                return BusinessResult<UserDto>.Success(null, "Hubo un error al actualizar el usuario");
            }
        }
    }
}
