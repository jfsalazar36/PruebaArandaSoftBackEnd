using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaArandaSoft.Core.Data;

namespace PruebaArandaSoft.Infraestructura.Data.Configuraciones
{
    public class AccionesConfiguracion : IEntityTypeConfiguration<Acciones>
    {
        public void Configure(EntityTypeBuilder<Acciones> builder)
        {
            builder.HasKey(e => e.AccionId);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
        }
    }
}
