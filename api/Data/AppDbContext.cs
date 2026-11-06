using Microsoft.EntityFrameworkCore;
using Nightpike.Api.Models;

namespace Nightpike.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Event> Events => Set<Event>();
}