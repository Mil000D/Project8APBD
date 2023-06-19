using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Zadanie8.Models;
using Zadanie8.PasswordHandlers;

namespace Zadanie8.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.IdUser);
            builder.Property(u => u.Username).HasMaxLength(20);
            builder.Property(u => u.Password).HasMaxLength(100);
            builder.ToTable(nameof(User));
            builder.HasData(
                new User { IdUser = 1, Username = "user8888", Password = PasswordHandler.HashPassword("user8888", "strongpassword123") },
                new User { IdUser = 2, Username = "user123", Password = PasswordHandler.HashPassword("user123", "strongpass123") },
                new User { IdUser = 3, Username = "useruser2222", Password = PasswordHandler.HashPassword("useruser2222", "veryverystrongpassword") }
                );
        }
    }
}
