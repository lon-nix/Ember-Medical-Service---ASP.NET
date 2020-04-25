using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationDbContext _EmberMedicaldb;
        private readonly UserManager<Staff> _userManager;
        public StaffRepository(ApplicationDbContext EmberMedicaldb, UserManager<Staff> userManager)
        {
            _EmberMedicaldb = EmberMedicaldb;
            _userManager = userManager;

        }
        public bool Create(Staff entity)
        {
            var result= _userManager.CreateAsync(entity).Result;
            return result.Succeeded;
        }

        public bool Delete(Staff entity)
        {
            _EmberMedicaldb.Staffs.Remove(entity);
            return Save();
        }

        public bool IsExist(int id)
        {
            var exist = _EmberMedicaldb.Staffs.Any(q => q.Id == id.ToString());
            return exist;
        }

        public ICollection<Staff> FindAll()
        {
            var StaffList = _userManager.Users.ToList();
            return StaffList;
        }

        public Staff FindByID(int id)
        {
            var StaffList = _EmberMedicaldb.Staffs.Find(id);
            return StaffList;
        }

        public bool Save()
        {
            var Changes = _EmberMedicaldb.SaveChanges();
            return Changes > 0;
        }

        public bool Update(Staff entity)
        {
            _EmberMedicaldb.Staffs.Update(entity);
            return Save();
        }
    }
}
