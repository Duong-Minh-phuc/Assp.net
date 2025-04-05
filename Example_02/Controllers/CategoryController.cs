using Example_02.Data;
using Example_02.Model;
using Microsoft.AspNetCore.Mvc;

namespace Example_02.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ THÊM
        [HttpPost]
        public IActionResult Create([FromBody] Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok(category);
        }

        // ✅ ĐỌC
        [HttpGet]
        public IActionResult GetAll()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // ✅ SỬA
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Category updatedCategory)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            category.Name = updatedCategory.Name;
            category.Description = updatedCategory.Description;

            _context.SaveChanges();
            return Ok(category);
        }

        // ✅ XOÁ
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent(); // HTTP 204
        }
    }
}
