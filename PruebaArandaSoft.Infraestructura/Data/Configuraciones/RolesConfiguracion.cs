using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaArandaSoft.Core.Data;

namespace PruebaArandaSoft.Infraestructura.Data.Configuraciones
{
    public class RolesConfiguracion : IEntityTypeConfiguration<Roles>
    {
        public void Configure(EntityTypeBuilder<Roles> builder)
        {
            builder.HasKey(e => e.RolId);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
