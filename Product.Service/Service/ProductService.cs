using Microsoft.EntityFrameworkCore;
using propd = Product.Entity.Entity;
using Product.Interface.Interface;
using System.Linq.Expressions;

namespace Product.Service.Service
{
    public class ProductService : IProduct
    {
        private readonly propd.AppDbContext _context;

        public ProductService(propd.AppDbContext context)
        {
            _context = context;
        }

        public async Task<propd.Product> Add(propd.Product product)
        {
            _context.Entry(product).State = EntityState.Added;
            try
            {
                _ = await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public async Task<bool> Delete(int ProductId)
        {
            var product = await _context.Set<propd.Product>().FindAsync(ProductId);
            _context.Entry(product).State = EntityState.Deleted;
            try
            {
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<propd.Product>> Find(Expression<Func<propd.Product, bool>> filter)
        {
            return await _context.Set<propd.Product>().Where(filter).ToListAsync();
        }

        public async Task<List<propd.Product>> Get()
        {
            return await _context.Set<propd.Product>().ToListAsync();
        }

        public async Task<bool> Update(propd.Product product)
        {
            _context.Set<propd.Product>().Attach(product);
            _context.Entry(product).State = EntityState.Modified;
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
