using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Utilidades;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuarios>
    {
        Task<UsuarioLoginDto> ValidarAutenticacion(LoginDto login);
        Task<Usuarios> ConsultarUsuarioNombre(string nombreUsuario);
        Task<Usuarios> ConsultarUsuarioPorId(int usuarioId);
        Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorNombre(ParametrosPaginacion param, string nombreUsuario);
        Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorRol(ParametrosPaginacion param, int rolId);
        Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioNombreRol(ParametrosPaginacion param, string nombreUsuario, int rolId);
        Task<Usuarios> CrearUsuario(Usuarios usuario);
        Task<Usuarios> ActualizarUsuario(Usuarios usuario);
        Task<bool> EliminarUsuario(Usuarios usuario);
    }
}
