using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteriaCampus.Clases
{
    public class DetalleFactura
    {
        public int Id { get; set; }
        public string NroFactura { get; set; }
        public List<ProductList> ProductLists { get; set; }
    }
}