using Zadanie8.DTO;
using Zadanie8.Models;

namespace Zadanie8.Mapper
{
    public class MapDoctorToDTO : IMapDoctorToDTO
    {
        public DoctorDTO2 ResponseDoctor(Doctor doctor)
        {
            var doctorDTO = new DoctorDTO2
            {
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                EmailAddress = doctor.EmailAddress,
                Prescriptions = doctor.Prescriptions.Select(p => new PrescriptionDTO1
                {
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Patient = new PatientDTO
                    {
                        FirstName = p.Patient.FirstName,
                        LastName = p.Patient.LastName,
                        Birthdate = p.Patient.Birthdate
                    }
                }).ToList()
            };
            return doctorDTO;
        }
        public ICollection<DoctorDTO2> ResponseDoctors(ICollection<Doctor> doctors)
        {
            var doctorDTOs = doctors.Select(d => new DoctorDTO2
            {
                FirstName = d.FirstName,
                LastName = d.LastName,
                EmailAddress = d.EmailAddress,
                Prescriptions = d.Prescriptions.Select(p => new PrescriptionDTO1
                {
                    Date = p.Date,
                    DueDate = p.DueDate,
                    Patient = new PatientDTO
                    {
                        FirstName = p.Patient.FirstName,
                        LastName = p.Patient.LastName,
                        Birthdate = p.Patient.Birthdate
                    }
                }).ToList()
            }).ToList();
            return doctorDTOs;
        }
    }
}
