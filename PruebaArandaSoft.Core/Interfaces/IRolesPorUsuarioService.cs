using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Interfaces
{
    public interface IRolesPorUsuarioService
    {
        Task ActualizarRolPorUsuario(int usuarioId, int rolId);
        Task CrearRolPorUsuario(int usuarioId, int rolId);
        Task<bool> EliminarRolPorUsuario(int usuarioId);
        Task<object> ObtenerToken(int usuarioId);
    }
}