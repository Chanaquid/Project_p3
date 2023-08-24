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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetCategories()
        {
            try
            {
                var categories = await _categoryRepository.GetCategoriesAsync();
                return Ok(categories);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server errorr. Please try again.");
            }
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(id);
                return category;
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Please try again");
            }            

        }

        [HttpPost]
        public async Task<ActionResult<Category>> CreateCategory([FromBody] Category category)
        {
            try
            {
                if(category == null)
                {
                    return BadRequest("Invalid product data");
                }
                await _categoryRepository.AddCategoryAsync(category);
                await _categoryRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(GetCategory), new {id = category.Id}, category);
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Could not create product.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(id);
                if(category == null)
                {
                    return NotFound("Product not found");
                }

                _categoryRepository.DeleteCategoryAsync(category);
                await _categoryRepository.SaveChangesAsync();
                return StatusCode(204, "The category has been deleted succesfully.");
                
            }
            catch(Exception)
            {
                return StatusCode(500, "Internal server error. Could not delete the category");
            }
        }
    }
}