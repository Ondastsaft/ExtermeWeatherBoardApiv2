using ExtermeWeatherBoardApiv2.Data;
using ExtermeWeatherBoardApiv2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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

        //public async Task<IActionResult> AddCategory()
        //{
        //    var requestBody = await new StreamReader(Request.Body).ReadToEndAsync();

        //    if (string.IsNullOrEmpty(requestBody))
        //    {
        //        return BadRequest("Empty request body");
        //    }
        //    try
        //    {
        //        var categoryJson = JsonConvert.DeserializeObject<Category>(requestBody);
        //        if(categoryJson!=null)
        //        {
        //            await _context.Categories.AddAsync(categoryJson);
        //            await _context.SaveChangesAsync();
        //            return Ok();
        //        }
        //    }
        //    catch (JsonException ex)
        //    {
        //        return BadRequest("Invalid JSON format");
        //    }
        //    return BadRequest("Invalid request body");
        //}
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory()
        {
            var jsonString = await new StreamReader(Request.Body).ReadToEndAsync();
            if (string.IsNullOrEmpty(jsonString))
            {
                return BadRequest("Empty JSON string");
            }

            try
            {
                var categoryJson = JsonConvert.DeserializeObject<Category>(jsonString);
                if (categoryJson != null && categoryJson.CreatorAdminUserData != null)                    
                {
                    var adminUserData = await _context.AdminUserDatas.Where(aud => aud.Id == categoryJson.CreatorAdminUserData.Id).SingleOrDefaultAsync();
                    if (adminUserData != null)
                    {
                        Category category = new Category()
                        {
                            Title = categoryJson.Title,
                            TimeStamp = categoryJson.TimeStamp,
                            CreatorAdminUserData = adminUserData

                        };
                        await _context.Categories.AddAsync(category);
                        await _context.SaveChangesAsync();
                    }
                }
                return Ok();
            }
            catch 
            {
                return BadRequest("Invalid JSON format");
            }
        }
    }
}
