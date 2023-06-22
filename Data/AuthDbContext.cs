using Microsoft.EntityFrameworkCore;
using Practical_17.Models;
using System.Xml;

namespace IdentityDemo.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }        
    }
}
