using e_commerce.Context;
using e_commerce.Dtos;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Product> _products;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
        _products = context.Set<Product>();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Product>>> Get([FromQuery] ProductFilters? filters)
    {
        if (filters == null || string.IsNullOrEmpty(filters.Type))
        {
            return Ok(await _products.ToListAsync());
        }
        
        return Ok(await _products.Where(p => p.Type.ToLower().Equals(filters.Type.ToLower())).ToListAsync());
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetById(int id)
    {
        var result = await _products.FindAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Product>> Create(Product product)
    {
        await _products.AddAsync(product);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Product>> Update(int id, Product product)
    {
        if (id != product.Id)
        {
            return BadRequest();
        }

        _context.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Product>> Delete(int id)
    {
        var product = await _products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        _products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}