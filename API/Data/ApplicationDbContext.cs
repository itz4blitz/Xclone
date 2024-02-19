using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
