
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityEmail.Entities;
using Microsoft.EntityFrameworkCore;

namespace IdentityEmail.Context
{
    public class EmailContext : IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;initial catalog=IdentityEmailDbNight;integrated security=true;trust server certificate=true");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}