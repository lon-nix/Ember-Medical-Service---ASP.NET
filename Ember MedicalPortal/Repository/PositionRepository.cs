using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Repository
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _EmberMedicaldb;
        public PositionRepository(ApplicationDbContext EmberMedicaldb)
        {
            _EmberMedicaldb = EmberMedicaldb;

        }
        public bool Create(Position entity)
        {
            _EmberMedicaldb.Positions.Add(entity);
            return Save();
        }

        public bool Delete(Position entity)
        {
            _EmberMedicaldb.Positions.Remove(entity);
            return Save();
        }

        public bool IsExist(int id)
        {
            var exist = _EmberMedicaldb.Positions.Any(q => q.ID == id);
            return exist;
        }

        public ICollection<Position> FindAll()
        {
            var Positions = _EmberMedicaldb.Positions.ToList();
            return Positions;
        }

        public Position FindByID(int id)
        {
            var Positions = _EmberMedicaldb.Positions.Find(id);
            return Positions;
        }

        public bool Save()
        {
            var Changes = _EmberMedicaldb.SaveChanges();
            return Changes > 0;
        }

        public bool Update(Position entity)
        {
            _EmberMedicaldb.Positions.Update(entity);
            return Save();
        }
    }
}
