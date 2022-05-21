using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Entities;
using ShopDAW.Entities.DTOs;
using ShopDAW.Repositories.ProductRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopDAW.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _repository;
        public ProductController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductByName(string name)
        {
            var product = await _repository.GetByName(name);
            if (product == null)
                return NotFound("Product doesn't exist!");
            return Ok(new ProductDTO(product));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto)
        {
            Product newProduct = new Product();

            newProduct.name = dto.name;
            newProduct.price = dto.price;
            _repository.Create(newProduct);
            await _repository.SaveAsync();
            return Ok(new ProductDTO(newProduct));
        }
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteProduct(string name)
        {
            var product = await _repository.GetByName(name);
            if (product == null)
                return NotFound("Product doesn't exist!");
            _repository.Delete(product);
            await _repository.SaveAsync();
            return NoContent();
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> UpdateName(string name, CreateProductDTO dto)
        {

            var product = await _repository.GetByName(name);
            if (product == null)
                return NotFound("Product doesn't exist");
            product.name = dto.name;
            await _repository.SaveAsync();
            return Ok(new ProductDTO(product));
        }
    }
}
