using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Repository
{
    public class MedicalRecordRepository : IMedicalRecordRepository
    {
        private readonly ApplicationDbContext _EmberMedicaldb;
        public MedicalRecordRepository(ApplicationDbContext EmberMedicaldb)
        {
            _EmberMedicaldb = EmberMedicaldb;

        }
        public bool Create(MedicalRecord entity)
        {
            _EmberMedicaldb.MedicalRecords.Add(entity);
            return Save();
        }

        public bool Delete(MedicalRecord entity)
        {
            _EmberMedicaldb.MedicalRecords.Remove(entity);
            return Save();
        }

        public bool IsExist(int id)
        {
            var exist = _EmberMedicaldb.MedicalRecords.Any(q => q.ID == id);
            return exist;
        }

        public ICollection<MedicalRecord> FindAll()
        {
            var Records = _EmberMedicaldb.MedicalRecords.ToList();
            return Records;
        }

        public MedicalRecord FindByID(int id)
        {
            var Records = _EmberMedicaldb.MedicalRecords.Find(id);
            return Records;
        }

        public bool Save()
        {
            var Changes = _EmberMedicaldb.SaveChanges();
            return Changes > 0;
        }

        public bool Update(MedicalRecord entity)
        {
            _EmberMedicaldb.MedicalRecords.Update(entity);
            return Save();
        }
    }
}
