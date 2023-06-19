using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Zadanie8.Models;

namespace Zadanie8.Configurations
{
    public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(p => p.IdPrescription);
            builder.Property(p => p.Date).HasColumnType("Date");
            builder.Property(p => p.DueDate).HasColumnType("Date");
            builder.HasOne(p => p.Patient)
                   .WithMany(p => p.Prescriptions)        
                   .HasForeignKey(p => p.IdPatient);
            builder.HasOne(p => p.Doctor)
                   .WithMany(p => p.Prescriptions)
                   .HasForeignKey(p => p.IdDoctor);
            builder.ToTable(nameof(Prescription));

            builder.HasData(
                new Prescription { IdPrescription = 1, Date = new DateTime(2022, 10, 5), DueDate = new DateTime(2022, 10, 15), IdPatient = 1, IdDoctor = 1 },
                new Prescription { IdPrescription = 2, Date = new DateTime(2022, 11, 10), DueDate = new DateTime(2022, 11, 20), IdPatient = 2, IdDoctor = 2 },
                new Prescription { IdPrescription = 3, Date = new DateTime(2022, 12, 15), DueDate = new DateTime(2022, 12, 25), IdPatient = 3, IdDoctor = 3 }
            );
        }
    }
}
