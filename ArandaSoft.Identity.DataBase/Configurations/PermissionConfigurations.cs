using ArandaSoft.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaSoft.Identity.DataBase.Configurations
{
    public class PermissionConfigurations : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(per => per.Id);

            builder.Property(per => per.Id).ValueGeneratedNever();
            builder.Property(per => per.Name).HasMaxLength(100).IsRequired();
        }
    }
}
