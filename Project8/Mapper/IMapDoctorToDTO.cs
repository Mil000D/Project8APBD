using Zadanie8.DTO;
using Zadanie8.Models;

namespace Zadanie8.Mapper
{
    public interface IMapDoctorToDTO
    {
        public DoctorDTO2 ResponseDoctor(Doctor doctor);
        public ICollection<DoctorDTO2> ResponseDoctors(ICollection<Doctor> doctors);
    }
}
