using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T GetById(int id);
        //T GetSingleBySpec()
        IEnumerable<T> ListAll();
        //IEnumerable<T> List()
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        //int Count(ISpecification<T> spec);
    }
}
