using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaArandaSoft.Core.Data
{
    public partial class Roles
    {
        public Roles()
        {
            PermisosPorRoles = new HashSet<PermisosPorRol>();
            RolesPorUsuarios = new HashSet<RolesPorUsuario>();
        }

        public int RolId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PermisosPorRol> PermisosPorRoles { get; set; }
        public virtual ICollection<RolesPorUsuario> RolesPorUsuarios { get; set; }
    }
}
