using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Surgery
    {
        [Required]
        public int SurgeryId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string SurgeryType { get; set; }
        public DateTime SurgeryDate { get; set; }
        public string OperationTheater { get; set; }
        public string Status { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }

}
