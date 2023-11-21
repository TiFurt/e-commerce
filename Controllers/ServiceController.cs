using e_commerce.Context;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<Service> _services;

    public ServiceController(ApplicationDbContext context)
    {
        _context = context;
        _services = context.Set<Service>();
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Service>>> Get()
    {
        return await _services.ToListAsync();
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Service>> GetById(int id)
    {
        var result = await _services.FindAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<ActionResult<Service>> Create(Service service)
    {
        await _services.AddAsync(service);
        await _context.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetById), new { id = service.Id }, service);
    }
    
    [HttpPut("{id:int}")]
    public async Task<ActionResult<Service>> Update(int id, Service service)
    {
        if (id != service.Id)
        {
            return BadRequest();
        }

        _context.Entry(service).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ActionResult<Service>> Delete(int id)
    {
        var service = await _services.FindAsync(id);
        if (service == null)
        {
            return NotFound();
        }

        _services.Remove(service);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}