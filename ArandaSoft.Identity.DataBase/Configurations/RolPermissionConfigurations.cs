using ArandaSoft.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaSoft.Identity.DataBase.Configurations
{
    public class RolPermissionConfigurations : IEntityTypeConfiguration<RolPermission>
    {
        public void Configure(EntityTypeBuilder<RolPermission> builder)
        {
            builder.HasKey(rp => new { rp.RolId, rp.PermissionId });

            builder.HasOne(rp => rp.Rol).WithMany(r => r.RolPermissions).HasForeignKey(rp => rp.RolId);
            builder.HasOne(rp => rp.Permission).WithMany(r => r.RolPermissions).HasForeignKey(rp => rp.PermissionId);
        }
    }
}
