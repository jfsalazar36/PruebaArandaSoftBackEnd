using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaArandaSoft.Core.Data;

namespace PruebaArandaSoft.Infraestructura.Data.Configuraciones
{
    public class PermisosPorRolConfiguracion : IEntityTypeConfiguration<PermisosPorRol>
    {
        public void Configure(EntityTypeBuilder<PermisosPorRol> builder)
        {
            builder.HasKey(e => e.PermisoPorRolId);

            builder.ToTable("PermisosPorRol");

            builder.HasOne(d => d.Permiso)
                .WithMany(p => p.PermisosPorRoles)
                .HasForeignKey(d => d.PermisoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermisosPorRol_Permisos");

            builder.HasOne(d => d.Rol)
                .WithMany(p => p.PermisosPorRoles)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermisosPorRol_Roles");
        }
    }
}
