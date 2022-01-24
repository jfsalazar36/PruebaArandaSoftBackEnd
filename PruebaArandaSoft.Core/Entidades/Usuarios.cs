using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaArandaSoft.Core.Data
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            RolesPorUsuarios = new HashSet<RolesPorUsuario>();
        }

        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }

        public virtual ICollection<RolesPorUsuario> RolesPorUsuarios { get; set; }
    }
}
