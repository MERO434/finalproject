using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class PatientInsurance
    {
        [Required]
        public int PatientId { get; set; }
        public int ProviderId { get; set; }
        public string PolicyNumber { get; set; }
        public string CoverageDetails { get; set; }
        public DateTime ExpirationDate { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public InsuranceProvider Provider { get; set; }
    }

}
