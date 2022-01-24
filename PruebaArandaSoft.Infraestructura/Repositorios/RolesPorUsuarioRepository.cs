using Microsoft.EntityFrameworkCore;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Infraestructura.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Infraestructura.Repositorios
{
    public class RolesPorUsuarioRepository : RepositoryBase<RolesPorUsuario>, IRolesPorUsuarioRepository
    {
        private readonly BD_ArandaSoftContext repositoryContext;

        public RolesPorUsuarioRepository(BD_ArandaSoftContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task<object> ObtenerToken(int usuarioId)
        {
            IEnumerable<RolesPorUsuario> rolesPorUsuario = await ObtenerRolesPorUsuario(usuarioId);
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

        public async Task<RolesPorUsuario> ConsularRolesPorUsuarioPorRolYUsuario(int usuarioId, int rolId)
        {
            return await repositoryContext.RolesPorUsuario
                .Where(x => x.RolId == rolId && x.UsuarioId == usuarioId).FirstOrDefaultAsync();
        }

        public async Task<RolesPorUsuario> ConsularRolesPorUsuarioPorUsuario(int usuarioId)
        {
            return await repositoryContext.RolesPorUsuario
                .Where(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RolesPorUsuario>> ObtenerRolesPorUsuario(int usuarioId)
        {
            return await repositoryContext.RolesPorUsuario
                .Include(x => x.Rol)
                .ThenInclude(x => x.PermisosPorRoles)
                .Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task CrearRolPorUsuario(RolesPorUsuario rolPorUsuario)
        {
            repositoryContext.RolesPorUsuario.Add(rolPorUsuario);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task ActualizarRolPorUsuario(RolesPorUsuario rolPorUsuario)
        {
            repositoryContext.Set<RolesPorUsuario>().Update(rolPorUsuario);
            await repositoryContext.SaveChangesAsync();
        }

        public async Task<bool> EliminarRolPorUsuario(RolesPorUsuario rolPorUsuario)
        {
            bool eliminoRegistro = false;
            if (rolPorUsuario != null)
            {
                repositoryContext.RolesPorUsuario.Remove(rolPorUsuario);
                await repositoryContext.SaveChangesAsync();
                eliminoRegistro = true;
            }

            return eliminoRegistro;
        }
    }
}
