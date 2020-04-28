using Ember_Medical_Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ember_Medical_Service.Contracts
{
    public interface IMedicalRecordRepository : IRepositoryBase <MedicalRecord>
    {
       // ICollection<MedicalRecord> GetMedicalRecordsBy(DateTime date);
    }
}
