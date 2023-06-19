using Zadanie8.DTO;
using Zadanie8.Models;

namespace Zadanie8.Mapper
{
    public interface IMapPrescriptionToDTO
    {
        public PrescriptionDTO2 ResponsePrescription(Prescription prescription);
    }
}
