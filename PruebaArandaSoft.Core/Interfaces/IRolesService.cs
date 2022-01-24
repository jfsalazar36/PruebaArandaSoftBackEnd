using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Interfaces
{
    public interface IRolesService
    {
        Task<RespuestaDto<List<Roles>>> ObtenerRoles();
    }
}