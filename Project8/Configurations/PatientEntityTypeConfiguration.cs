using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Zadanie8.Models;

namespace Zadanie8.Configurations
{
    public class PatientEntityTypeConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(p => p.IdPatient);
            builder.Property(p => p.FirstName).HasMaxLength(100);
            builder.Property(p => p.LastName).HasMaxLength(100);
            builder.Property(p => p.Birthdate).HasColumnType("Date");
            builder.ToTable(nameof(Patient));

            builder.HasData(
                new Patient { IdPatient = 1, FirstName = "Alice", LastName = "Johnson", Birthdate = new DateTime(1992, 12, 5) },
                new Patient { IdPatient = 2, FirstName = "Bob", LastName = "Smith", Birthdate = new DateTime(1987, 8, 18) },
                new Patient { IdPatient = 3, FirstName = "Carol", LastName = "Davis", Birthdate = new DateTime(1995, 3, 25) }
                );
        }
    }
}
