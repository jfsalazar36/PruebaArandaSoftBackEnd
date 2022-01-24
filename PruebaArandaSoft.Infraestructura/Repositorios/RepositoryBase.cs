using Microsoft.EntityFrameworkCore;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Utilidades;
using PruebaArandaSoft.Infraestructura.Data;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Infraestructura.Repositorios
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected BD_ArandaSoftContext RepositoryContext { get; set; }

        public RepositoryBase(BD_ArandaSoftContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public async Task Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            await this.SaveAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            await this.SaveAsync();
            return true;
        }

        public async Task Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            await this.SaveAsync();
        }

        public async Task SaveAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }
    }
}
