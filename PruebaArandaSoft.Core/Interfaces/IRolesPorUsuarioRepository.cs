using PruebaArandaSoft.Core.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Interfaces
{
    public interface IRolesPorUsuarioRepository: IRepositoryBase<RolesPorUsuario>
    {
        Task<object> ObtenerToken(int usuarioId);
        Task<RolesPorUsuario> ConsularRolesPorUsuarioPorRolYUsuario(int usuarioId, int rolId);
        Task<RolesPorUsuario> ConsularRolesPorUsuarioPorUsuario(int usuarioId);
        Task<IEnumerable<RolesPorUsuario>> ObtenerRolesPorUsuario(int usuarioId);
        Task CrearRolPorUsuario(RolesPorUsuario rolPorUsuario);
        Task ActualizarRolPorUsuario(RolesPorUsuario rolPorUsuario);
        Task<bool> EliminarRolPorUsuario(RolesPorUsuario rolPorUsuario);
    }
}
