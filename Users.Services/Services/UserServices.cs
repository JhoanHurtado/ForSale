using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Users.Entity.Entities;
using Users.Interfaces.Interfaces;

namespace Users.Services.Services
{
    public class UserServices : IUserInterfaces
    {
        private readonly AppDbContext _context;

        public UserServices(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            _context.Entry(user).State = EntityState.Added;
            try
            {
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return user;
        }

        public async Task<List<User>> Find(Expression<Func<User, bool>> filter)
        {
            var resp = await _context.Set<User>().Where(filter).ToListAsync();
            return resp;
        }

        public async Task<bool> Update(User user)
        {
            _context.Set<User>().Attach(user);
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
