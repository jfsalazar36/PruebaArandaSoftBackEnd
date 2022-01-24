using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaArandaSoft.Core.Data
{
    public partial class RolesPorUsuario
    {
        public int RolPorUsuarioId { get; set; }
        public int UsuarioId { get; set; }
        public int RolId { get; set; }

        public virtual Roles Rol { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
