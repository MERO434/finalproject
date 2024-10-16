using test.Models;
using System.ComponentModel.DataAnnotations;

public class MedicalRecord
{
    [Required]
    public int MedicalRecordId { get; set; }
    public int PatientId { get; set; }
    public int DoctorId { get; set; }
    public string Diagnosis { get; set; }
    public string Treatment { get; set; }
    public DateTime RecordDate { get; set; }

    // Navigation properties
    public Patient Patient { get; set; }
    public Doctor Doctor { get; set; }
}


