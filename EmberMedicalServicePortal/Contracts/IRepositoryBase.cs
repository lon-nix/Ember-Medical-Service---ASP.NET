using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmberMedicalServicePortal.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        ICollection<T> FindAll();
        T FindByID(int id);

        bool IsExist(int id);

        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
