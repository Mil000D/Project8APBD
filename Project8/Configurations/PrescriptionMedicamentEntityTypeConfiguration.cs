using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie8.Models;

namespace Zadanie8.Configurations
{
    public class PrescriptionMedicamentEntityTypeConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
    {
        public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
        {
            builder.HasKey(pm => new { pm.IdMedicament, pm.IdPrescription });
            builder
                .HasOne(pm => pm.Medicament)
                .WithMany(m => m.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdMedicament);
            builder
                .HasOne(pm => pm.Prescription)
                .WithMany(p => p.PrescriptionMedicaments)
                .HasForeignKey(pm => pm.IdPrescription);
            builder.Property(pm => pm.Details).HasMaxLength(100);
            builder.ToTable("Prescription_Medicament");

            builder.HasData(
                new PrescriptionMedicament { IdMedicament = 1, IdPrescription = 1, Dose = 2, Details = "Take twice daily" },
                new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "Take once daily with food" },
                new PrescriptionMedicament { IdMedicament = 3, IdPrescription = 3, Dose = 3, Details = "Take three times daily" }
                );
        }
    }
}
