using ExtermeWeatherBoardApiv2.Data;
using ExtremeWeatherBoardApiv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExtermeWeatherBoardApiv2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet("GetAll")]
        public async Task<List<Category>?> GetAllAsync()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok();
        }        
    }
}
