using ConsoleAppProject.App03;
using WebApplications.Network;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplications.Pages.Network;

namespace WebApplications.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // App 03
        public DbSet<Student> Students { get; set; }

        // App 04
        public DbSet<Post> Posts { get; set; }
        public DbSet<PhotoPost> Photos { get; set; }
        public DbSet<MessagePost> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
