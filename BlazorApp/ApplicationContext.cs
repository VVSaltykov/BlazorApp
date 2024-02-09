using BlazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
        }
    }
}
