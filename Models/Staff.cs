using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Staff
    {
        [Required]
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public int DepartmentId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Navigation properties
        public Department Department { get; set; }
    }

}
