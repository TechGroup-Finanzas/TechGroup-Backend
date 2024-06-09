using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TechGroup.API.TechGroup.Products.Request;
using TechGroup.API.TechGroup.Products.Response;
using TechGroup.Domain.TechGroup.Products.Interfaces;
using TechGroup.Infrastructure.TechGroup.Products.Interfaces;
using TechGroup.Infrastructure.TechGroup.Products.Models;

namespace TechGroup.API.TechGroup.Products.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductDomain _productDomain;
        private readonly IMapper _mapper;
        private readonly IProductInfrastructure _productInfrastructure;
        
        public ProductController(IProductDomain productDomain, IMapper mapper, IProductInfrastructure productInfrastructure)
        {
            _productDomain = productDomain;
            _mapper = mapper;
            _productInfrastructure = productInfrastructure;
        }
        
        //GET : api/Product
        [HttpGet]
        public async Task<List<ProductResponse>> GetAllAsync()
        {
            var products = await _productInfrastructure.GetAllAsync();
            var productsResponse = _mapper.Map<List<Product>, List<ProductResponse>>(products);
            return productsResponse;
        }
        
        //GET : api/Product/{id}
        [HttpGet("{id}")]
        public async Task<ProductResponse> GetByIdAsync(int id)
        {
            var product = await _productInfrastructure.GetByIdAsync(id);
            var productResponse = _mapper.Map<Product, ProductResponse>(product);
            return productResponse;
        }
        
        //POST : api/Product
        [HttpPost]
        public async Task CreateAsync([FromBody] ProductRequest product)
        {
            if (ModelState.IsValid)
            {
                var productToMapped = _mapper.Map<ProductRequest, Product>(product);
                await _productDomain.SaveAsync(productToMapped);
            }
            else
            {
                StatusCode(400);
            }
        }
        
        //PUT : api/Product/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductRequest product)
        {
            var productToMapped = _mapper.Map<ProductRequest, Product>(product);
            var productUpdated = await _productDomain.UpdateAsync(id, productToMapped);
            if (productUpdated)
            {
                return Ok();
            }

            return BadRequest();
            
        }
        
        //DELETE : api/Product/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var productDeleted = await _productDomain.DeleteAsync(id);
            if (productDeleted)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
