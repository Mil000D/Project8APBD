namespace Zadanie8.DTO
{
    public class DoctorDTO2
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<PrescriptionDTO1> Prescriptions { get; set; }
    }
}
