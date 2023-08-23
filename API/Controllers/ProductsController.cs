using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            try
            {
                var products = await _productRepository.GetProductsAsync();

                return Ok(products);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Please try again");
            }
        
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(id);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Please try again");
            }
            

        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            try
            {
                if(product == null)
                {
                    return BadRequest("Invalid product data");
                }

                await _productRepository.AddProductAsync(product);
                await _productRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetProduct), new { id = product.Id}, product);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server error. Could not create product.");
            }
            
           
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                 if(product == null || id != product.Id)
                {
                    return BadRequest("Invalid product data or mismatched IDs");
                }

                var existingProduct = await _productRepository.GetProductByIdAsync(id);
                
                if(existingProduct == null){

                    return NotFound("Product not found.");

                }

                 //Update properties of the existing product from the provided product
                 existingProduct.Name = product.Name;
                 
                 _productRepository.UpdateProduct(existingProduct);

                return NoContent();
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal Server error. Product could now be updated");
            }
            
           

           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _productRepository.GetProductByIdAsync(id);
                if(product == null)
                {
                    return NotFound("Product not found");
                }

                _productRepository.DeleteProductAsync(product);
                await _productRepository.SaveChangesAsync();

                return NoContent(); // 204 error response is appropiate for DELETE on success.
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Could not delete product");
            }
            
        }


    }
}