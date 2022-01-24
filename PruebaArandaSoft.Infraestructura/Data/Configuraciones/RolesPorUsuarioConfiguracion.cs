using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaArandaSoft.Core.Data;

namespace PruebaArandaSoft.Infraestructura.Data.Configuraciones
{
    public class RolesPorUsuarioConfiguracion : IEntityTypeConfiguration<RolesPorUsuario>
    {
        public void Configure(EntityTypeBuilder<RolesPorUsuario> builder)
        {
            builder.HasKey(e => e.RolPorUsuarioId);

            builder.ToTable("RolesPorUsuario");

            builder.HasOne(d => d.Rol)
                .WithMany(p => p.RolesPorUsuarios)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesPorUsuario_Roles");

            builder.HasOne(d => d.Usuarios)
                .WithMany(p => p.RolesPorUsuarios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RolesPorUsuario_Usuarios");
        }
    }
}
