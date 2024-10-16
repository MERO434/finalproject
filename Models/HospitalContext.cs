using test.Models;
using Microsoft.EntityFrameworkCore;

namespace test.Data
{

    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options) // Pass options to the base class DbContext
        {
        }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<RoomAssignment> RoomAssignments { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }
        public DbSet<PatientInsurance> PatientInsurances { get; set; }
        public DbSet<InsuranceProvider> InsuranceProviders { get; set; }
        public DbSet<DischargeSummary> DischargeSummaries { get; set; }
        

        
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Example of composite key for PatientInsurance
            modelBuilder.Entity<PatientInsurance>()
                .HasKey(pi => new { pi.PatientId, pi.ProviderId });
            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.RoomId); // Assuming RoomId is the primary key

                entity.Property(r => r.CostPerDay)
                      .HasColumnType("money"); // Specify SQL Server money type
            });

            // Configure relationships, constraints, etc.
        }


    }

}
