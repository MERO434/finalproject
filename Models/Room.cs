using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Room
    {
        [Required]
        public int RoomId { get; set; }
        public string RoomType { get; set; }
        public int AvailableBeds { get; set; }
        public decimal CostPerDay { get; set; }

        // Navigation properties
        public ICollection<RoomAssignment> RoomAssignments { get; set; }
    }

}
