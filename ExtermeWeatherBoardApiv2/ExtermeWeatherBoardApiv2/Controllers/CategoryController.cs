using ExtermeWeatherBoardApiv2.Data;
using ExtremeWeatherBoardApiv2.Models;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet]
        public IEnumerable<Category?>? Get()
        {
            var categories = _context.Categories.ToList();
            if (categories == null)
            {
                return null;
            }
            return categories;
        }
    }
}
