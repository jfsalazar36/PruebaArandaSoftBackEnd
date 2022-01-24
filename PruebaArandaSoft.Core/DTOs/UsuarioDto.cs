using PruebaArandaSoft.Core.Data;

namespace PruebaArandaSoft.Core.DTOs
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string NombreCompleto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int? Edad { get; set; }
        public int RolId { get; set; }
        public Roles Roles { get; set; }

    }
}
