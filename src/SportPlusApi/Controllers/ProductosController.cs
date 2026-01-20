using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportPlusApi.Data;
using SportPlusApi.Models;

namespace SportPlusApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. OBTENER TODOS LOS PRODUCTOS
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos.ToListAsync();
        }

        // 2. OBTENER UN PRODUCTO POR ID (Nuevo)
        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            return producto;
        }

        // 3. CREAR UN PRODUCTO NUEVO
        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            // Corregido para que apunte a GetProducto (singular)
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        // 4. ACTUALIZAR UN PRODUCTO (Nuevo)
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id) return BadRequest();

            _context.Entry(producto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Productos.Any(e => e.Id == id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // 5. ELIMINAR UN PRODUCTO (Nuevo)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}