using propd = Product.Entity.Entity;
using System.Linq.Expressions;

namespace Product.Interface.Interface
{
    public interface IProduct
    {
        Task<List<propd.Product>> Get();
        Task<List<propd.Product>> Find(Expression<Func<propd.Product,bool>> filter);
        Task<propd.Product> Add(propd.Product product);
        Task<bool> Update(propd.Product product);
        Task<bool> Delete(int ProductId);
    }
}
