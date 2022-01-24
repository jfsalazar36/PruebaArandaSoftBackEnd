using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Utilidades;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorNombre(ParametrosPaginacion param, string nombreUsuario);
        Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioNombreRol(ParametrosPaginacion param, string nombreUsuario, int rolId);
        Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorRol(ParametrosPaginacion param, int rolId);
        Task<UsuarioLoginDto> ValidarAutenticacion(LoginDto login);
        Task<RespuestaDto<UsuarioDto>> CrearUsuario(Usuarios usuario);
        Task<RespuestaDto<UsuarioDto>> ActualizarUsuario(Usuarios usuario);
        Task<RespuestaDto<bool>> EliminarUsuario(int usuarioId);
    }
}