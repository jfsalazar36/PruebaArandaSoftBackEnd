using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaArandaSoft.Core.Utilidades
{
    public class ListaPaginada<T> : List<T>
    {
        public int PaginaActual { get; set; }
        public int TotalPaginas { get; set; }
        public int TamanoPagina { get; set; }
        public int CuentaTotal { get; set; }

        public ListaPaginada()
        {
        }

        public ListaPaginada(List<T> items, int cantidad, int numeroPagina, int tamanoPagina)
        {
            CuentaTotal = cantidad;
            TamanoPagina = tamanoPagina;
            PaginaActual = numeroPagina;
            TotalPaginas = numeroPagina == 1 && tamanoPagina == 1 ? 1 : (int)Math.Ceiling(cantidad / (double)tamanoPagina);
            this.AddRange(items);
        }
    }
}
