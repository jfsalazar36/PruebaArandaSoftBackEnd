using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Servicios
{
    public class RolesService : IRolesService
    {
        private readonly IRolesRepository _rolesRepository;

        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public async Task<RespuestaDto<List<Roles>>> ObtenerRoles()
        {
            RespuestaDto<List<Roles>> resultado = new RespuestaDto<List<Roles>>
            {
                Resultado = await _rolesRepository.ConsultarRoles()
            };

            return resultado;
        }
    }
}
