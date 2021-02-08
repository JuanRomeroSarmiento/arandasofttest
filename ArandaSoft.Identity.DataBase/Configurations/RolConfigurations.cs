using ArandaSoft.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaSoft.Identity.DataBase.Configurations
{
    public class RolConfigurations : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(rol => rol.Id);

            builder.Property(rol => rol.Id).ValueGeneratedNever();
            builder.Property(rol => rol.Name).HasMaxLength(100).IsRequired();            
        }
    }
}
