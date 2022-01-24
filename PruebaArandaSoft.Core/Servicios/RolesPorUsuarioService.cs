using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Servicios
{
    public class RolesPorUsuarioService : IRolesPorUsuarioService
    {
        private readonly IRolesPorUsuarioRepository _rolesPorUsuarioRepository;

        public RolesPorUsuarioService(IRolesPorUsuarioRepository rolesPorUsuarioRepository)
        {
            _rolesPorUsuarioRepository = rolesPorUsuarioRepository;
        }

        public async Task<object> ObtenerToken(int usuarioId)
        {
            IEnumerable<RolesPorUsuario> rolesPorUsuario = await _rolesPorUsuarioRepository.ObtenerRolesPorUsuario(usuarioId);
            string roles = string.Empty;
            foreach (RolesPorUsuario rol in rolesPorUsuario)
            {
                roles += rol.Rol.Nombre + ";";
            }

            roles = roles[0..^1];

            var response = new
            {
                roles
            };

            return response;
        }

        public async Task CrearRolPorUsuario(int usuarioId, int rolId)
        {
            RolesPorUsuario rolPorUsuarioExiste = await _rolesPorUsuarioRepository.ConsularRolesPorUsuarioPorRolYUsuario(usuarioId, rolId);

            if (rolPorUsuarioExiste != null)
            {
                RolesPorUsuario rolPorUsuario = new RolesPorUsuario
                {
                    RolId = rolId,
                    UsuarioId = usuarioId
                };

                await _rolesPorUsuarioRepository.Create(rolPorUsuario);
            }
        }

        public async Task ActualizarRolPorUsuario(int usuarioId, int rolId)
        {
            RolesPorUsuario rolPorUsuario = await _rolesPorUsuarioRepository.ConsularRolesPorUsuarioPorRolYUsuario(usuarioId, rolId);

            if (rolPorUsuario != null)
            {
                rolPorUsuario.RolId = rolId;
                await _rolesPorUsuarioRepository.Update(rolPorUsuario);
            }
        }

        public async Task<bool> EliminarRolPorUsuario(int usuarioId)
        {
            bool eliminoRegistro = false;
            RolesPorUsuario rolPorUsuario = await _rolesPorUsuarioRepository.ConsularRolesPorUsuarioPorUsuario(usuarioId);
            if (rolPorUsuario != null)
            {
                eliminoRegistro = await _rolesPorUsuarioRepository.Delete(rolPorUsuario);
            }

            return eliminoRegistro;
        }
    }
}
