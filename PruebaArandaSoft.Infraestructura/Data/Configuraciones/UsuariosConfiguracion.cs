using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PruebaArandaSoft.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaArandaSoft.Infraestructura.Data.Configuraciones
{
    public class UsuariosConfiguracion : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.HasKey(e => e.UsuarioId);

            builder.Property(e => e.Direccion)
                    .HasMaxLength(120)
                    .IsUnicode(false);

            builder.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(e => e.PrimerApellido)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.PrimerNombre)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.SegundoApellido)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.SegundoNombre)
                .HasMaxLength(80)
                .IsUnicode(false);

            builder.Property(e => e.Telefono)
                .HasMaxLength(12)
                .IsUnicode(false);
        }
    }
}
