using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _EmberMedicaldb;
        private readonly UserManager<Patient> _userManager;
        public PatientRepository(ApplicationDbContext EmberMedicaldb, UserManager<Patient> userManager)
        {
            _EmberMedicaldb = EmberMedicaldb;
            _userManager = userManager;

        }
        public bool Create(Patient entity)
        {
            var result = _userManager.CreateAsync(entity).Result;
            return result.Succeeded;
        }

        public bool Delete(Patient entity)
        {
            _EmberMedicaldb.Patients.Remove(entity);
            return Save();
        }

        public bool IsExist(int id)
        {
            var exist = _EmberMedicaldb.Patients.Any(q => q.Id == id.ToString());
            return exist;
        }

        public ICollection<Patient> FindAll()
        {
            var PatientList = _userManager.Users.ToList();
            return PatientList;
        }

        public Patient FindByID(int id)
        {
            var PatientList = _EmberMedicaldb.Patients.Find(id);
            return PatientList;

        }

        public bool Save()
        {
            var Changes = _EmberMedicaldb.SaveChanges() ;
            return Changes > 0;
        }

        public bool Update(Patient entity)
        {
            _EmberMedicaldb.Patients.Update(entity);
            return Save ();
        }
    }
}
