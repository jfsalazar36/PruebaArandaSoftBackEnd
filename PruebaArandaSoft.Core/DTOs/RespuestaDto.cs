namespace PruebaArandaSoft.Core.DTOs
{
    public class RespuestaDto<TResult>
    {
        public bool Exitoso { get; set; }
        public string MensajeError { get; set; }
        public TResult Resultado { get; set; }

    }
}
