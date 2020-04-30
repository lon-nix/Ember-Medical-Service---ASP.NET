using System;
using System.Collections.Generic;
using System.Text;
using EmberMedicalServicePortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmberMedicalServicePortal.Data
{
    public class ApplicationDbContext : IdentityDbContext <ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        public DbSet<Patient> Patients { get; set; }     
      
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<EmberMedicalServicePortal.Models.PatientInfoVM> PatientInfo { get; set; }
        public DbSet<EmberMedicalServicePortal.Models.ListOfAppointmentVM> AppointmentList { get; set; }
        public DbSet<EmberMedicalServicePortal.Models.MedicalHistoryVM> MedicalHistory { get; set; }
        public DbSet<EmberMedicalServicePortal.Models.EmployeeVM> Employees { get; set; }

        
    }
}
