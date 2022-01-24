namespace PruebaArandaSoft.Core.DTOs
{
    public class UsuarioLoginDto
    {
        public int UsuarioId { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public object Token { get; set; }
    }
}
