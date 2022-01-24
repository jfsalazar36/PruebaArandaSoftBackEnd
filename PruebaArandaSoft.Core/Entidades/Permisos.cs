using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaArandaSoft.Core.Data
{
    public partial class Permisos
    {
        public Permisos()
        {
            PermisosPorRoles = new HashSet<PermisosPorRol>();
        }

        public int PermisoId { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<PermisosPorRol> PermisosPorRoles { get; set; }
    }
}
