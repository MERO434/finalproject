using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Prescription
    {
        [Required]
        public int PrescriptionId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string Medication { get; set; }
        public string Dosage { get; set; }
        public DateTime PrescriptionDate { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }

}
