using Commons.Commons;
using Product.Dto.Dto;

namespace Product.Business.Interface
{
    public interface IProductBusiness
    {
        Task<BusinessResult<List<ProductDto>>> Get();
        Task<BusinessResult<List<ProductDto>>> Find(string Filtro);
        Task<BusinessResult<ProductDto>> Add(ProductDto product);
        Task<BusinessResult<ProductDto>> Update(ProductDto product);
        Task<BusinessResult<ProductDto>> Delete(int ProductId);
    }
}
