using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Utilidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorNombre(ParametrosPaginacion param, string nombreUsuario)
        {
            return await _usuarioRepository.ConsultarUsuarioPorNombre(param, nombreUsuario);
        }

        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorRol(ParametrosPaginacion param, int rolId)
        {
            return await _usuarioRepository.ConsultarUsuarioPorRol(param, rolId);
        }

        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioNombreRol(ParametrosPaginacion param, string nombreUsuario, int rolId)
        {
            return await _usuarioRepository.ConsultarUsuarioNombreRol(param, nombreUsuario, rolId);
        }

        public async Task<UsuarioLoginDto> ValidarAutenticacion(LoginDto login)
        {
            return await _usuarioRepository.ValidarAutenticacion(login);
        }

        public async Task<RespuestaDto<UsuarioDto>> CrearUsuario(Usuarios usuario)
        {
            RespuestaDto<UsuarioDto> resultado = new RespuestaDto<UsuarioDto>();
            Usuarios usuarioExistente = await _usuarioRepository.ConsultarUsuarioNombre(usuario.Nombre);

            if (usuarioExistente == null)
            {
                Usuarios usuarioCreado = await _usuarioRepository.CrearUsuario(usuario);

                if (usuarioCreado != null)
                {
                    resultado.Resultado = new UsuarioDto
                    {
                        UsuarioId = usuarioCreado.UsuarioId,
                        Nombre = usuarioCreado.Nombre,
                        Password = usuarioCreado.Password,
                        PrimerNombre = usuarioCreado.PrimerNombre,
                        SegundoNombre = usuarioCreado.SegundoNombre,
                        PrimerApellido = usuarioCreado.PrimerApellido,
                        SegundoApellido = usuarioCreado.SegundoApellido,
                        Direccion = usuarioCreado.Direccion,
                        Telefono = usuarioCreado.Telefono,
                        Email = usuarioCreado.Email,
                        Edad = usuarioCreado.Edad,
                        NombreCompleto = usuarioCreado.PrimerNombre + " " + usuarioCreado.SegundoNombre + " " + usuarioCreado.PrimerApellido + " " + usuarioCreado.SegundoApellido
                    };
                }
            }
            else
            {
                resultado.MensajeError = "El usuario que se intenta crear ya existe";
            }

            return resultado;
        }

        public async Task<RespuestaDto<UsuarioDto>> ActualizarUsuario(Usuarios usuario)
        {
            RespuestaDto<UsuarioDto> resultado = new RespuestaDto<UsuarioDto>();

            Usuarios usuarioModificado = await _usuarioRepository.ActualizarUsuario(usuario);

            resultado.Resultado = new UsuarioDto
            {
                UsuarioId = usuarioModificado.UsuarioId,
                PrimerNombre = usuarioModificado.PrimerNombre,
                SegundoNombre = usuarioModificado.SegundoNombre,
                PrimerApellido = usuarioModificado.PrimerApellido,
                SegundoApellido = usuarioModificado.SegundoApellido,
                Direccion = usuarioModificado.Direccion,
                Telefono = usuarioModificado.Telefono,
                Email = usuarioModificado.Email,
                Edad = usuarioModificado.Edad,
                NombreCompleto = usuarioModificado.PrimerNombre + " " + usuarioModificado.SegundoNombre + " " + usuarioModificado.PrimerApellido + " " + usuarioModificado.SegundoApellido
            };

            return resultado;
        }

        public async Task<RespuestaDto<bool>> EliminarUsuario(int usuarioId)
        {
            RespuestaDto<bool> resultado = new RespuestaDto<bool>();
            Usuarios usuario = await _usuarioRepository.ConsultarUsuarioPorId(usuarioId);

            if (usuario != null)
            {
                resultado.Resultado = await _usuarioRepository.EliminarUsuario(usuario);
            }
            return resultado;
        }
    }
}
