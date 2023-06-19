using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie8.Models;

namespace Zadanie8.Configurations
{
    public class DoctorEntityTypeConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(d => d.IdDoctor);
            builder.Property(d => d.FirstName).HasMaxLength(100);
            builder.Property(d => d.LastName).HasMaxLength(100);
            builder.Property(d => d.EmailAddress).HasMaxLength(100);
            builder.ToTable(nameof(Doctor));

            builder.HasData(
                new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", EmailAddress = "john.doe@example.com" },
                new Doctor { IdDoctor = 2, FirstName = "Jane", LastName = "Smith", EmailAddress = "jane.smith@example.com" },
                new Doctor { IdDoctor = 3, FirstName = "David", LastName = "Johnson", EmailAddress = "david.johnson@example.com" }
            );
        }
    }
}
