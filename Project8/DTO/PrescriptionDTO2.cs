namespace Zadanie8.DTO
{
    public class PrescriptionDTO2
    {
        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }
        public PatientDTO Patient { get; set; }
        public DoctorDTO1 Doctor { get; set; }
        public ICollection<MedicamentDTO> Medicaments { get; set; }
    }
}
