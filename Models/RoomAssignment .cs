using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class RoomAssignment
    {
        [Required]
        public int RoomAssignmentId { get; set; }
        public int PatientId { get; set; }
        public int RoomId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // Navigation properties
        public Patient Patient { get; set; }
        public Room Room { get; set; }
    }

}
