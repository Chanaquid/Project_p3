using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController : ControllerBase
    {
        public StoreContext Context { get; }

        public ProductsController(StoreContext context)
        {
            Context = context;
                    
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await Context.Products.ToListAsync();

            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await Context.Products.FindAsync(id);

        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct([FromBody] Product product)
        {
            if(product == null)
            {
                return BadRequest("Invalid product data");
            }

            Context.Products.Add(product);
            await Context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = product.Id}, product);
        }

        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if(product == null || id != product.Id)
            {
                return BadRequest("Invalid product data or mismatched IDs");
            }

            var existingProduct = await Context.Products.FindAsync(id);
            
            if(existingProduct == null){

                return NotFound("Product not found.");

            }

            //Update properties of the existing product from the provided product
            Context.Entry(existingProduct).CurrentValues.SetValues(product);

            await Context.SaveChangesAsync();

            return NoContent();
        }



    }
}