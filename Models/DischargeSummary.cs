using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class DischargeSummary
    {
        [Required]
        public int DischargeSummaryId { get; set; }
        public int PatientId { get; set; }
        public DateTime DischargeDate { get; set; }
        public string FinalDiagnosis { get; set; }
        public string PrescribedMedication { get; set; }
        public string FollowUpInstructions { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
    }

}
