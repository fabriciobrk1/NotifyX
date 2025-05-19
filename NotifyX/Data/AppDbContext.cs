using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NotifyX.Models;

namespace NotifyX.Data
{
    public class AppDbContext : IdentityDbContext<AdminUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; } // Clientes cadastrados no sistema
    }
}
