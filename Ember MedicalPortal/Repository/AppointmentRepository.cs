using Ember_Medical_Service.Contracts;
using Ember_Medical_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContext _EmberMedicaldb;
        public AppointmentRepository(ApplicationDbContext EmberMedicaldb)
        {
            _EmberMedicaldb = EmberMedicaldb;

        }
        public bool Create(Appointment entity)
        {
            _EmberMedicaldb.Appointments.Add(entity);
            return Save();
        }

        public bool Delete(Appointment entity)
        {
            _EmberMedicaldb.Appointments.Remove(entity);
            return Save();
        }

        public bool IsExist(int id)
        {
            var exist = _EmberMedicaldb.Appointments.Any(q => q.ID == id);
            return exist;
        }

        public ICollection<Appointment> FindAll()
        {
            var Appointments = _EmberMedicaldb.Appointments.ToList();
            return Appointments;
        }

        public Appointment FindByID(int id)
        {
            var Appointments = _EmberMedicaldb.Appointments.Find(id);
            return Appointments; ;
        }

        public ICollection<Appointment> GetAppointmentsBy(DateTime date)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var Changes = _EmberMedicaldb.SaveChanges();
            return Changes > 0;
        }

        public bool Update(Appointment entity)
        {
            _EmberMedicaldb.Appointments.Update(entity);
            return Save();
        }
    }
}
