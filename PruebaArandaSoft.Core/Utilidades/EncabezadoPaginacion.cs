using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaArandaSoft.Core.Utilidades
{
    public class EncabezadoPaginacion
    {
        public int PaginaActual { get; set; }
        public int ElementosPorPagina { get; set; }
        public int TotalItems { get; set; }
        public int TotalPaginas { get; set; }

        public EncabezadoPaginacion(int paginaActual, int elementosPorPagina, int totalItems, int totalPaginas)
        {
            this.PaginaActual = paginaActual;
            this.ElementosPorPagina = elementosPorPagina;
            this.TotalItems = totalItems;
            this.TotalPaginas = totalPaginas;
        }
    }
}
