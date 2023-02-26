using AutoMapper;
using Commons.Commons;
using Product.Business.Interface;
using Product.Dto.Dto;
using Product.Interface.Interface;
using prod = Product.Entity.Entity;

namespace Product.Business.Business
{
    public class ProdcutBusiness: IProductBusiness
    {
        private IProduct _Iproduct;
        private readonly IMapper _mapper;

        public ProdcutBusiness(IProduct iproduct, IMapper mapper)
        {
            _Iproduct = iproduct;
            _mapper = mapper;
        }

        public async Task<BusinessResult<List<ProductDto>>> Get(){
            try
            {
                var products = await _Iproduct.Get();
                var productsDto = _mapper.Map<List<ProductDto>>(products);
                return BusinessResult<List<ProductDto>>.Success(productsDto, "Lista de productos");
            }
            catch (Exception ex)
            {
                return BusinessResult<List<ProductDto>>.Success(null, "Hubo un error al cargar los productos");
            }
        }

        public async Task<BusinessResult<List<ProductDto>>> Find(string Filtro)
        {
            try
            {
                var filterNumber = Filtro.All(char.IsDigit) ? Convert.ToDecimal(Filtro) : 0;
                var products = await _Iproduct.Find(x => x.Name.Contains(Filtro) || /*x.Id == filterNumber ||*/ x.Price == filterNumber);
                var productsDto = _mapper.Map<List<ProductDto>>(products);
                return BusinessResult<List<ProductDto>>.Success(productsDto, "Productos encontrados");
            }
            catch (Exception)
            {
                return BusinessResult<List<ProductDto>>.Success(null, "Hubo un error al cargar los productos");
            }
        }

        public async Task<BusinessResult<ProductDto>> Add(ProductDto productDto) {
            try
            {
                var product = _mapper.Map<prod.Product>(productDto);
                var productNew = await _Iproduct.Add(product);
                if (productNew == null)
                {
                    return BusinessResult<ProductDto>.Success(null, "Producto no agregado");
                }
                var productNewDto = _mapper.Map<ProductDto>(productNew);
                return BusinessResult<ProductDto>.Success(productNewDto, "Producto agregado");
            }
            catch (Exception ex)
            {
                return BusinessResult<ProductDto>.Success(null, "Hubo un error al agregar los productos");
            }
        }

        public async Task<BusinessResult<ProductDto>> Update(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<prod.Product>(productDto);
                var productUpdate = await _Iproduct.Update(product);
                if (!productUpdate)
                {
                    return BusinessResult<ProductDto>.Success(new ProductDto(), "Producto no actualizado");
                }
                return BusinessResult<ProductDto>.Success(new ProductDto(), "Producto actualizado");
            }
            catch (Exception)
            {
                return BusinessResult<ProductDto>.Success(null, "Hubo un error al actualizar el producto");
            }
        }

        public async Task<BusinessResult<ProductDto>> Delete(int productId)
        {
            try
            {
                var productUpdate = await _Iproduct.Delete(productId);
                if (!productUpdate)
                {
                    return BusinessResult<ProductDto>.Success(new ProductDto(), "Producto no eliminar");
                }
                return BusinessResult<ProductDto>.Success(new ProductDto(), "Producto eliminado");
            }
            catch (Exception)
            {
                return BusinessResult<ProductDto>.Success(null, "Hubo un error al eliminar el producto");
            }
        }

    }
}
