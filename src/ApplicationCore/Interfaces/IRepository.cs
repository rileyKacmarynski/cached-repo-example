using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> : IReadonlyRepository<T> where T : BaseEntity
    {
        T Add(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
