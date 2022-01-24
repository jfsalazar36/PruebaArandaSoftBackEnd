using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaArandaSoft.Core.Data
{
    public partial class PermisosPorRol
    {
        public int PermisoPorRolId { get; set; }
        public int RolId { get; set; }
        public int PermisoId { get; set; }

        public virtual Permisos Permiso { get; set; }
        public virtual Roles Rol { get; set; }
    }
}
