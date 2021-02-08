using ArandaSoft.Identity.DataBase.Configurations;
using ArandaSoft.Identity.DataBase.Seed;
using ArandaSoft.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArandSoft.Identity.DataBase
{
    public class IdentityDBContext : DbContext
    {
        public IdentityDBContext(DbContextOptions<IdentityDBContext> options) : base(options)
        {           
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolPermission> RolPermission { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("bnl");

            modelBuilder.ApplyConfiguration(new UserConfigurations());
            modelBuilder.ApplyConfiguration(new RolConfigurations());
            modelBuilder.ApplyConfiguration(new PermissionConfigurations());
            modelBuilder.ApplyConfiguration(new RolPermissionConfigurations());
            
        }
    }
}
