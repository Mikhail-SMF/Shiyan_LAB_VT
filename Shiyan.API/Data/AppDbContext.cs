using Instruments.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Shiyan.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
