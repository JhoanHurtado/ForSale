using System.Linq.Expressions;
using Users.Entity.Entities;

namespace Users.Interfaces.Interfaces
{
    public interface IUserInterfaces
    {
        //Task<List<User>> Get();
        Task<List<User>> Find(Expression<Func<User, bool>> filter);
        Task<User> Add(User user);
        Task<bool> Update(User user);
        //Task<bool> Delete(int userId);
        //Task<User> Login(int id);
    }
}
