using Zadanie8.DTO;
using Zadanie8.Models;

namespace Zadanie8.Mapper
{
    public class MapPrescriptionToDTO : IMapPrescriptionToDTO
    {
        public PrescriptionDTO2 ResponsePrescription(Prescription prescription)
        {
            var prescriptionDTO = new PrescriptionDTO2
            {
                Date = prescription.Date,
                DueDate = prescription.DueDate,
                Patient = new PatientDTO
                {
                    FirstName = prescription.Patient.FirstName,
                    LastName = prescription.Patient.LastName,
                    Birthdate = prescription.Patient.Birthdate
                },
                Doctor = new DoctorDTO1
                {
                    FirstName = prescription.Doctor.FirstName,
                    LastName = prescription.Doctor.LastName,
                    EmailAddress = prescription.Doctor.EmailAddress
                },
                Medicaments = prescription.PrescriptionMedicaments.Select(p => new MedicamentDTO
                {
                    Name = p.Medicament.Name,
                    Description = p.Medicament.Description,
                    Type = p.Medicament.Type
                }).ToList()
            };
            return prescriptionDTO;
        }
    }
}
