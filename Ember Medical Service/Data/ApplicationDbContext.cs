using System;
using System.Collections.Generic;
using System.Text;
using Ember_Medical_Service.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ember_Medical_Service.Models;

namespace Ember_Medical_Service.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }
        public DbSet<Ember_Medical_Service.Data.ListOfPositionsVM> ListOfPositionsVM { get; set; }
        public DbSet<Ember_Medical_Service.Models.PatientInfoVM> PatientInfoVM { get; set; }
        public DbSet<Ember_Medical_Service.Models.StaffInfoVM> StaffInfoVM { get; set; }
        public DbSet<Ember_Medical_Service.Models.MedicalHistoryVM> MedicalHistoryVM { get; set; }
        public DbSet<Ember_Medical_Service.Models.ListOfAppointmentVM> ListOfAppointmentVM { get; set; }
       
    }
}
