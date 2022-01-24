namespace PruebaArandaSoft.Core.Utilidades
{
    public class ParametrosPaginacion
    {
        private const int MaxTamanoPagina = 50;
        public int NumeroPagina { get; set; }
        private int tamanoPagina = 5;
        public int TamanoPagina
        {
            get { return tamanoPagina; }
            set { tamanoPagina = (value > MaxTamanoPagina) ? MaxTamanoPagina : value; }
        }

        public string OrdenarPor { get; set; }
    }
}
