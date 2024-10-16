using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Doctor
    {
        [Required]
        public int DoctorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialization { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<Surgery> Surgeries { get; set; }
    }

}
