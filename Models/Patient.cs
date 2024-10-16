using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Patient
    {
        [Required]
        public int  PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public ICollection<Appointment> Appointments { get; set; }
        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Prescription> Prescriptions { get; set; }
        public ICollection<RoomAssignment> RoomAssignments { get; set; }
        public ICollection<PatientInsurance> Insurances { get; set; }
        public ICollection<DischargeSummary> DischargeSummaries { get; set; }
    }

}
