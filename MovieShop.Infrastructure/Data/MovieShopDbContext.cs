using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;

namespace MovieShop.Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {

        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options): base(options)
        { 
        
        }

        public DbSet<Genre> Genres { get; set; }
    
    }

    
}
