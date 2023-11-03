using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteriaCampus.Clases
{
    public class Factura
    {
        public string NroFactura { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdCliente { get; set; }
        public double TotalFactura { get; set; }
    }
}