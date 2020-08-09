using Microsoft.EntityFrameworkCore;
using api.Domain.Models;

namespace api.Persistence.Contexts
{
    public class AppDbContext : DbContext {
        public DbSet<City> Cities {get;set;}

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>().Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Entity<City>().HasKey(c => c.Id);            
            builder.Entity<City>().HasAlternateKey(c => c.Ibge);
            builder.Entity<City>().HasAlternateKey(c => new {c.Uf, c.Cidade});
            builder.Entity<City>().ToTable("cities");
        }
    }
} 