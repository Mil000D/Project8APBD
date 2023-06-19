using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zadanie8.Models;

namespace Zadanie8.Configurations
{
    public class MedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder.HasKey(m => m.IdMedicament);
            builder.Property(m => m.Name).HasMaxLength(100);
            builder.Property(m => m.Description).HasMaxLength(100);
            builder.Property(m => m.Type).HasMaxLength(100);
            builder.ToTable(nameof(Medicament));

            builder.HasData(
                new Medicament { IdMedicament = 1, Name = "Paracetamol", Description = "Fever and pain reliever", Type = "Tablet" },
                new Medicament { IdMedicament = 2, Name = "APAP", Description = "Used to treat pain and fever", Type = "Capsule" },
                new Medicament { IdMedicament = 3, Name = "Ibuprofen", Description = "Used to treat fever, swelling, pain, and redness", Type = "Tablet" }
                );
        }
    }
}
