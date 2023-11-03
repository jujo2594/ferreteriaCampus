using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteriaCampus.Clases
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnit { get; set; }
        public int Cantidad { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        
    }
}