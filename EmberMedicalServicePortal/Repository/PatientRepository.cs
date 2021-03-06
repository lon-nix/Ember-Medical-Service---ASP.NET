﻿using EmberMedicalServicePortal.Contracts;
using EmberMedicalServicePortal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _EmberMedicaldb;
        public PatientRepository(ApplicationDbContext EmberMedicaldb)
        {
            _EmberMedicaldb = EmberMedicaldb;
            ;

        }
        public bool Create(Patient entity)
        {
            _EmberMedicaldb.Patients.Add(entity);

            return Save();
        }

        public bool Delete(Patient entity)
        {
            _EmberMedicaldb.Patients.Remove(entity);
            return Save();
        }

        public bool IsExist(int id)
        {
            var exist = _EmberMedicaldb.Patients.Any(q => q.ID == id);
            return exist;
        }

        public ICollection<Patient> FindAll()
        {
            var PatientList = _EmberMedicaldb.Patients.ToList();
            return PatientList;
        }

        public Patient FindByID(int id)
        {
            var PatientList = _EmberMedicaldb.Patients.Find(id);
            return PatientList;

        }

        public bool Save()
        {
            var Changes = _EmberMedicaldb.SaveChanges();
            return Changes > 0;
        }

        public bool Update(Patient entity)
        {
            _EmberMedicaldb.Patients.Update(entity);
            return Save();
        }
    }
}
