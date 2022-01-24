using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Utilidades;
using System;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IRolesPorUsuarioService _rolesPorUsuarioService;

        public UsuarioController(IUsuarioService usuarioService, IRolesPorUsuarioService rolesPorUsuarioService)
        {
            _usuarioService = usuarioService;
            _rolesPorUsuarioService = rolesPorUsuarioService;
        }

        [HttpPost("Login")]
        public async Task<RespuestaDto<UsuarioLoginDto>> ValidarInicioSesion([FromBody] LoginDto login)
        {
            UsuarioLoginDto usuarioDto;
            RespuestaDto<UsuarioLoginDto> resultado = new RespuestaDto<UsuarioLoginDto>();

            try
            {
                usuarioDto = await _usuarioService.ValidarAutenticacion(login);

                if (usuarioDto != null)
                {
                    object token = await _rolesPorUsuarioService.ObtenerToken(usuarioDto.UsuarioId);
                    if (token != null)
                    {
                        usuarioDto.Token = token;
                    }

                    resultado.Exitoso = true;
                    resultado.Resultado = usuarioDto;
                }
                else
                {
                    resultado.MensajeError = "Usuario y/o clave incorrecto, por favor revise la información.";
                }
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar iniciar sesión : " + ex.Message;
            }

            return resultado;
        }

        [HttpPost("Create")]
        public async Task<RespuestaDto<UsuarioDto>> CrearUsuario([FromBody] UsuarioDto usuarioDto)
        {
            RespuestaDto<UsuarioDto> resultado = new RespuestaDto<UsuarioDto>();
            Usuarios usuario = new Usuarios
            {
                Nombre = usuarioDto.Nombre,
                Password = usuarioDto.Password,
                PrimerNombre = usuarioDto.PrimerNombre,
                SegundoNombre = usuarioDto.SegundoNombre,
                PrimerApellido = usuarioDto.PrimerApellido,
                SegundoApellido = usuarioDto.SegundoApellido,
                Direccion = usuarioDto.Direccion,
                Telefono = usuarioDto.Telefono,
                Email = usuarioDto.Email,
                Edad = usuarioDto.Edad
            };

            try
            {
                resultado = await _usuarioService.CrearUsuario(usuario);
                if (resultado.Resultado != null && resultado.Resultado.UsuarioId != 0)
                {
                    await _rolesPorUsuarioService.CrearRolPorUsuario(resultado.Resultado.UsuarioId, usuarioDto.RolId);
                }
                resultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar crear el usuario : " + ex.Message;
            }

            return resultado;
        }

        [HttpPut("Update")]
        public async Task<RespuestaDto<UsuarioDto>> ActualizarUsuario([FromBody] UsuarioDto usuarioDto)
        {
            RespuestaDto<UsuarioDto> resultado = new RespuestaDto<UsuarioDto>();
            Usuarios usuario = new Usuarios
            {
                UsuarioId = usuarioDto.UsuarioId,
                PrimerNombre = usuarioDto.PrimerNombre,
                SegundoNombre = usuarioDto.SegundoNombre,
                PrimerApellido = usuarioDto.PrimerApellido,
                SegundoApellido = usuarioDto.SegundoApellido,
                Direccion = usuarioDto.Direccion,
                Telefono = usuarioDto.Telefono,
                Email = usuarioDto.Email,
                Edad = usuarioDto.Edad
            };

            try
            {
                resultado = await _usuarioService.ActualizarUsuario(usuario);
                if (resultado.Resultado.UsuarioId != 0)
                {
                    await _rolesPorUsuarioService.ActualizarRolPorUsuario(resultado.Resultado.UsuarioId, usuarioDto.RolId);
                }
                resultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar actualizar el usuario : " + ex.Message;
            }

            return resultado;
        }

        [HttpDelete("Delete/{usuarioId}")]
        public async Task<RespuestaDto<bool>> EliminarUsuario(int usuarioId)
        {
            RespuestaDto<bool> resultado = new RespuestaDto<bool>();
            try
            {
                bool eliminoRolPorUsuario = await _rolesPorUsuarioService.EliminarRolPorUsuario(usuarioId);
                if (eliminoRolPorUsuario)
                {
                    resultado = await _usuarioService.EliminarUsuario(usuarioId);
                    resultado.Exitoso = true;
                }
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar eliminar el usuario : " + ex.Message;
            }

            return resultado;
        }

        [HttpGet("Nombre/{nombreUsuario}")]
        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorNombre([FromQuery] ParametrosPaginacion param, string nombreUsuario)
        {
            RespuestaDto<ListaPaginada<UsuarioDto>> resultado = new RespuestaDto<ListaPaginada<UsuarioDto>>();

            try
            {
                resultado = await _usuarioService.ConsultarUsuarioPorNombre(param, nombreUsuario);
                Response.AddPagination(resultado.Resultado.PaginaActual, resultado.Resultado.TamanoPagina, resultado.Resultado.CuentaTotal, resultado.Resultado.TotalPaginas);
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar consultar los usuarios: " + ex.Message;
            }

            return resultado;
        }

        [HttpGet("Rol/{rolId}")]
        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorRol([FromQuery] ParametrosPaginacion param, int rolId)
        {
            RespuestaDto<ListaPaginada<UsuarioDto>> resultado = new RespuestaDto<ListaPaginada<UsuarioDto>>();

            try
            {
                resultado = await _usuarioService.ConsultarUsuarioPorRol(param, rolId);
                Response.AddPagination(resultado.Resultado.PaginaActual, resultado.Resultado.TamanoPagina, resultado.Resultado.CuentaTotal, resultado.Resultado.TotalPaginas);
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar consultar los usuarios: " + ex.Message;
            }

            return resultado;
        }

        [HttpGet("NombreRol/{nombreUsuario}/{rolId}")]
        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioNombreRol([FromQuery] ParametrosPaginacion param, string nombreUsuario, int rolId)
        {
            RespuestaDto<ListaPaginada<UsuarioDto>> resultado = new RespuestaDto<ListaPaginada<UsuarioDto>>();

            try
            {
                resultado = await _usuarioService.ConsultarUsuarioNombreRol(param, nombreUsuario, rolId);
                Response.AddPagination(resultado.Resultado.PaginaActual, resultado.Resultado.TamanoPagina, resultado.Resultado.CuentaTotal, resultado.Resultado.TotalPaginas);
            }
            catch (Exception ex)
            {
                resultado.MensajeError = "Se presentó un problema al intentar consultar los usuarios: " + ex.Message;
            }

            return resultado;
        }
    }
}
