using ArandaSoft.Identity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaSoft.Identity.DataBase.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(user => user.Name).HasMaxLength(100).IsRequired();
            builder.Property(user => user.PasswordHash).IsRequired();
            builder.Property(user => user.Salt).IsRequired();
            builder.Property(user => user.FullName).HasMaxLength(256).IsRequired();
            builder.Property(user => user.Email).HasMaxLength(256).IsRequired();
            builder.Property(user => user.PhoneNumber).HasMaxLength(30);
            builder.Property(user => user.Address).HasMaxLength(200);

            builder.HasOne(user => user.Rol).WithMany(rol => rol.Users).HasForeignKey(user => user.RolId);
        }
    }
}
