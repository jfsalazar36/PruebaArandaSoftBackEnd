using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaArandaSoft.Core.Data;

namespace PruebaArandaSoft.Infraestructura.Data.Configuraciones
{
    public class PermisosConfiguracion : IEntityTypeConfiguration<Permisos>
    {
        public void Configure(EntityTypeBuilder<Permisos> builder)
        {
            builder.HasKey(e => e.PermisoId);

            builder.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
        }
    }
}
