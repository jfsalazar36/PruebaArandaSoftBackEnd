using Microsoft.EntityFrameworkCore;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Infraestructura.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Infraestructura.Repositorios
{
    public class PermisosPorRolRepository : RepositoryBase<PermisosPorRol>, IPermisosPorRolRepository
    {
        private readonly BD_ArandaSoftContext repositoryContext;

        public PermisosPorRolRepository(BD_ArandaSoftContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
    }
}
