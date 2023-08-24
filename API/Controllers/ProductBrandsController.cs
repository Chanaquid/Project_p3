using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public ProductBrandsController(IProductBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            try
            {
                var productBrands = await _productBrandRepository.GetProductBrandsAsync();
                return Ok(productBrands);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Please try again");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrand(int id)
        {
            try
            {
                return await _productBrandRepository.GetProductBrandByIdAsync(id);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Please try again");
            }
        }

        [HttpPost]
        public async Task<ActionResult<ProductBrand>> CreateProductBrands([FromBody] ProductBrand productBrand)
        {
            try
            {
                if(productBrand == null)
                {
                    return BadRequest("Invalid product data");
                }

                await _productBrandRepository.AddProductBrandAsync(productBrand);
                await _productBrandRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProductBrand), new {id = productBrand.Id}, productBrand);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server error. Could not create Brand");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productBrandRepository.GetProductBrandByIdAsync(id);
                if(product == null)
                {
                    return NotFound("Product not found");
                }
                _productBrandRepository.DeleteProductBrandAsync(product);
                await _productBrandRepository.SaveChangesAsync();

                return StatusCode(204, "Object successfully deleted");
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Could not delete product brand");
            }
        }
    }
}