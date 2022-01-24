using Microsoft.EntityFrameworkCore;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Infraestructura.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Infraestructura.Repositorios
{
    public class RolesRepository : RepositoryBase<Roles>, IRolesRepository
    {
        private readonly BD_ArandaSoftContext repositoryContext;
        public RolesRepository(BD_ArandaSoftContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task<List<Roles>> ConsultarRoles()
        {
            return await repositoryContext.Roles.ToListAsync();
        }
    }
}
