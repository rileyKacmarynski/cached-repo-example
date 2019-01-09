using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        Task<T> GetByIdAsync(int id);
        //Task<T> GetSingleBySpecAsync()
        Task<IEnumerable<T>> ListAllAsync();
        //IEnumerable<T> List()
        T Add(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        //Task<int> CountAsync(ISpecification<T> spec);
    }
}
