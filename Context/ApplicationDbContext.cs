using e_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace e_commerce.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
}