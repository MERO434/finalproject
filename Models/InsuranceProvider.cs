using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class InsuranceProvider
    {
        [Required]
        [Key]
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderContact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        // Navigation properties
        public ICollection<PatientInsurance> PatientInsurances { get; set; }
    }

}
