using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
