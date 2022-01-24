using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Interfaces
{
    public interface IRepositoryBase<T>
    {
        Task Create(T entity);
        Task Update(T entity);
        Task<bool> Delete(T entity);
        Task SaveAsync();
    }
}
