using AutoMapper;
using Commons.Commons;
using Microsoft.AspNetCore.Mvc;
using Product.Business.Business;
using Product.Business.Interface;
using Product.Dto.Dto;

namespace Product.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductBusiness _IprodcutBusiness;

        public ProductController(IProductBusiness iprodcutBusiness)
        {
            _IprodcutBusiness = iprodcutBusiness;
        }

        //Path: api/ProductController 
        [HttpGet]
        public async Task<BusinessResult<List<ProductDto>>> Get()
        {
            return await _IprodcutBusiness.Get();
        }

        //Path: api/ProductController/filtro
        [HttpGet("{filtro}")]
        public async Task<BusinessResult<List<ProductDto>>> Get(string filtro)
        {
            return await _IprodcutBusiness.Find(filtro);
        }

        //Path: api/ProductController
        [HttpPost]
        public async Task<BusinessResult<ProductDto>> Post(ProductDto productDto)
        {
            return await _IprodcutBusiness.Add(productDto);
        }

        //Path: api/ProductController
        [HttpPut]
        public async Task<BusinessResult<ProductDto>> Put(ProductDto productDto) {
            return await _IprodcutBusiness.Update(productDto);
        }

        //Path: api/ProductController
        [HttpDelete]
        public async Task<BusinessResult<ProductDto>> Delete(int productId)
        {
            return await _IprodcutBusiness.Delete(productId);
        }


    }
}
