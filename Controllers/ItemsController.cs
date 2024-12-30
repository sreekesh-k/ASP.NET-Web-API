using Items_Web_API.Data;
using Items_Web_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Items_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/items
        [HttpGet]
        public IActionResult GetItems()
        {
            return Ok(_context.Items.ToList());
        }

        // GET: api/items/{id}
        [HttpGet("{id}")]
        public IActionResult GetItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
                return NotFound();
            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public IActionResult CreateItem([FromBody] Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetItem), new { id = item.Id }, item);
        }

        // PUT: api/items/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateItem(int id, [FromBody] Item item)
        {
            var existingItem = _context.Items.Find(id);
            if (existingItem == null)
                return NotFound();

            existingItem.Name = item.Name;
            existingItem.Quantity = item.Quantity;
            existingItem.Description = item.Description;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/items/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteItem(int id)
        {
            var item = _context.Items.Find(id);
            if (item == null)
                return NotFound();

            _context.Items.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
