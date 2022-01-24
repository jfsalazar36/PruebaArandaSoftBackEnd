using Microsoft.EntityFrameworkCore;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Core.DTOs;
using PruebaArandaSoft.Core.Interfaces;
using PruebaArandaSoft.Core.Utilidades;
using PruebaArandaSoft.Infraestructura.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Infraestructura.Repositorios
{
    public class UsuarioRepository : RepositoryBase<Usuarios>, IUsuarioRepository
    {
        private readonly BD_ArandaSoftContext repositoryContext;

        public UsuarioRepository(BD_ArandaSoftContext repositoryContext) : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorNombre(ParametrosPaginacion param, string nombreUsuario)
        {
            var fitroCompleto = repositoryContext.Usuarios
                    .Include(x => x.RolesPorUsuarios)
                    .ThenInclude(x => x.Rol)
                    .Where(x => x.Nombre == nombreUsuario).Select(x => new UsuarioDto { 
                        UsuarioId = x.UsuarioId,
                        PrimerNombre = x.PrimerNombre,
                        SegundoNombre = x.SegundoNombre,
                        PrimerApellido = x.PrimerApellido,
                        SegundoApellido = x.SegundoApellido,
                        NombreCompleto = x.PrimerNombre + " " + x.SegundoNombre + " " + x.PrimerApellido + " " + x.SegundoApellido,
                        Direccion = x.Direccion,
                        Telefono = x.Telefono,
                        Email = x.Email,
                        Edad = x.Edad
                    });

            return new RespuestaDto<ListaPaginada<UsuarioDto>>
            {
                Exitoso = true,
                Resultado = await this.CreateAsync(fitroCompleto, param.NumeroPagina, param.TamanoPagina)
            };
        }

        public async Task<Usuarios> ConsultarUsuarioNombre(string nombreUsuario)
        {
            return await repositoryContext.Usuarios
                .Where(x => x.Nombre == nombreUsuario).FirstOrDefaultAsync();
        }

        public async Task<Usuarios> ConsultarUsuarioPorId(int usuarioId)
        {
            return await repositoryContext.Usuarios
                .Where(x => x.UsuarioId == usuarioId).FirstOrDefaultAsync();
        }

        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioPorRol(ParametrosPaginacion param, int rolId)
        {
            var fitroCompleto = repositoryContext.RolesPorUsuario
                    .Include(x => x.Usuarios)
                    .Include(x => x.Rol)
                    .Where(x => x.RolId == rolId).Select(x => new UsuarioDto
                    {
                        UsuarioId = x.UsuarioId,
                        PrimerNombre = x.Usuarios.PrimerNombre,
                        SegundoNombre = x.Usuarios.SegundoNombre,
                        PrimerApellido = x.Usuarios.PrimerApellido,
                        SegundoApellido = x.Usuarios.SegundoApellido,
                        NombreCompleto = x.Usuarios.PrimerNombre + " " + x.Usuarios.SegundoNombre + " " + x.Usuarios.PrimerApellido + " " + x.Usuarios.SegundoApellido,
                        Direccion = x.Usuarios.Direccion,
                        Telefono = x.Usuarios.Telefono,
                        Email = x.Usuarios.Email,
                        Edad = x.Usuarios.Edad
                    });

            return new RespuestaDto<ListaPaginada<UsuarioDto>>
            {
                Exitoso = true,
                Resultado = await this.CreateAsync(fitroCompleto, param.NumeroPagina, param.TamanoPagina)
            };
        }

        public async Task<RespuestaDto<ListaPaginada<UsuarioDto>>> ConsultarUsuarioNombreRol(ParametrosPaginacion param, string nombreUsuario, int rolId)
        {
            var fitroCompleto = repositoryContext.RolesPorUsuario
                    .Include(x => x.Usuarios)
                    .Include(x => x.Rol)
                    .Where(x => x.Usuarios.Nombre == nombreUsuario && x.RolId == rolId).Select(x => new UsuarioDto
                    {
                        UsuarioId = x.UsuarioId,
                        PrimerNombre = x.Usuarios.PrimerNombre,
                        SegundoNombre = x.Usuarios.SegundoNombre,
                        PrimerApellido = x.Usuarios.PrimerApellido,
                        SegundoApellido = x.Usuarios.SegundoApellido,
                        NombreCompleto = x.Usuarios.PrimerNombre + " " + x.Usuarios.SegundoNombre + " " + x.Usuarios.PrimerApellido + " " + x.Usuarios.SegundoApellido,
                        Direccion = x.Usuarios.Direccion,
                        Telefono = x.Usuarios.Telefono,
                        Email = x.Usuarios.Email,
                        Edad = x.Usuarios.Edad
                    });

            return new RespuestaDto<ListaPaginada<UsuarioDto>>
            {
                Exitoso = true,
                Resultado = await this.CreateAsync(fitroCompleto, param.NumeroPagina, param.TamanoPagina)
            };
        }

        public async Task<UsuarioLoginDto> ValidarAutenticacion(LoginDto login)
        {
            UsuarioLoginDto usuarioDto = null;
            Usuarios usuario = await repositoryContext.Usuarios.Where(x => x.Nombre == login.Nombre && x.Password == login.Password).FirstOrDefaultAsync();

            if (usuario != null)
            {
                usuarioDto = new UsuarioLoginDto
                {
                    UsuarioId = usuario.UsuarioId,
                    PrimerNombre = usuario.PrimerNombre,
                    SegundoNombre = usuario.SegundoNombre,
                    PrimerApellido = usuario.PrimerApellido,
                    SegundoApellido = usuario.SegundoApellido
                };
            }

            return usuarioDto;

        }

        public async Task<Usuarios> CrearUsuario(Usuarios usuario)
        {
            repositoryContext.Usuarios.Add(usuario);
            await repositoryContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<Usuarios> ActualizarUsuario(Usuarios usuario)
        {
            repositoryContext.Set<Usuarios>().Update(usuario);
            await repositoryContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> EliminarUsuario(Usuarios usuario)
        {
            bool eliminoRegistro = false;
            if (usuario != null)
            {
                repositoryContext.Usuarios.Remove(usuario);
                await repositoryContext.SaveChangesAsync();
                eliminoRegistro = true;
            }

            return eliminoRegistro;
        }

        public async Task<ListaPaginada<UsuarioDto>> CreateAsync(IQueryable<UsuarioDto> source,
            int numeroPagina, int tamanoPagina)
        {
            var count = await source.CountAsync();
            if (numeroPagina >= 1 && tamanoPagina > 1)
            {
                var items = await source.Skip((numeroPagina - 1) * tamanoPagina).Take(tamanoPagina).ToListAsync();
                return new ListaPaginada<UsuarioDto>(items, count, numeroPagina, tamanoPagina);
            }
            else
            {
                var items = await source.ToListAsync();
                return new ListaPaginada<UsuarioDto>(items, count, numeroPagina, tamanoPagina);
            }
        }
    }
}
