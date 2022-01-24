using Microsoft.EntityFrameworkCore;
using PruebaArandaSoft.Core.Data;
using PruebaArandaSoft.Infraestructura.Data.Configuraciones;

namespace PruebaArandaSoft.Infraestructura.Data
{
    public partial class BD_ArandaSoftContext : DbContext
    {
        public BD_ArandaSoftContext()
        {
        }

        public BD_ArandaSoftContext(DbContextOptions<BD_ArandaSoftContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Acciones> Acciones { get; set; }
        public virtual DbSet<Permisos> Permisos { get; set; }
        public virtual DbSet<PermisosPorRol> PermisosPorRol { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RolesPorUsuario> RolesPorUsuario { get;  set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccionesConfiguracion());
            modelBuilder.ApplyConfiguration(new PermisosConfiguracion());
            modelBuilder.ApplyConfiguration(new PermisosPorRolConfiguracion());
            modelBuilder.ApplyConfiguration(new RolesConfiguracion());
            modelBuilder.ApplyConfiguration(new RolesPorUsuarioConfiguracion());
            modelBuilder.ApplyConfiguration(new UsuariosConfiguracion());
        }
    }
}
