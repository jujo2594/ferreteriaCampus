using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ferreteriaCampus.Clases;

namespace ferreteriaCampus.Methods
{
    public class Principal
    {
        public void Menu(){
            Console.WriteLine("---------------MENU------------------");
            Console.WriteLine("Ingrese la opción que desea realizar");
            Console.WriteLine("1.Listar la informacion de productos");
            Console.WriteLine("2.Listar productos a punto de agotarse");
            Console.WriteLine("3.Listar productos para comprar y cantidad a comprar");
            Console.WriteLine("4.Listar el total de facturas del mes de enero 2023");
            Console.WriteLine("5.Listar los productos vendidos en una factura");
            Console.WriteLine("6.Calcular el valor total del inventario");
            Console.WriteLine("0.Salir");
        }
        List<Productos> _productos = new List<Productos>{
            new Productos(){Id = 1, Nombre = "Cemento", PrecioUnit = 65.35, Cantidad = 350, StockMin = 300, StockMax = 900},
            new Productos(){Id = 2, Nombre = "Acero", PrecioUnit = 55.35, Cantidad = 600, StockMin = 500, StockMax = 800},
            new Productos(){Id = 3, Nombre = "Yeso", PrecioUnit = 16.26, Cantidad = 300, StockMin = 100, StockMax = 900},
            new Productos(){Id = 4, Nombre = "Tornillos", PrecioUnit = 60.25, Cantidad = 1900, StockMin = 1000, StockMax = 3000},
            new Productos(){Id = 5, Nombre = "Martillo", PrecioUnit = 30.10, Cantidad = 10, StockMin = 30, StockMax = 100}
        };
        List<Cliente> _clientes = new List<Cliente>{
            new Cliente() {Id = 1, Nombre = "Pedro", Email = "pedro@gmail.com"  },
            new Cliente() {Id = 2, Nombre = "Andres", Email = "andres@gmail.com"  },
            new Cliente() {Id = 3, Nombre = "Guillermo", Email = "guillermo@gmail.com"  },
            new Cliente() {Id = 4, Nombre = "Camilo", Email = "camilo@gmail.com"  },
            new Cliente() {Id = 5, Nombre = "Santiago", Email = "santiago@gmail.com"  }
        };
        List<DetalleFactura> _detalleFactura = new List<DetalleFactura>{
            new DetalleFactura() {Id = 1, NroFactura = "001", ProductLists = new List<ProductList>{
                new ProductList(){IdProducto = 1, Cantidad = 15, Valor = 263.2},
                new ProductList(){IdProducto = 3, Cantidad = 8, Valor = 99.99},
                new ProductList(){IdProducto = 5, Cantidad = 50, Valor = 560.87}}},

            new DetalleFactura() {Id = 2, NroFactura = "002", ProductLists = new List<ProductList>{
                new ProductList(){IdProducto = 4, Cantidad = 18, Valor = 846.23},
                new ProductList(){IdProducto = 2, Cantidad = 36, Valor = 4896.45},
                new ProductList(){IdProducto = 1, Cantidad = 81, Valor = 300.65}}},

            new DetalleFactura() {Id = 3, NroFactura = "003", ProductLists = new List<ProductList>{
                new ProductList(){IdProducto = 3, Cantidad = 26, Valor = 212.36},
                new ProductList(){IdProducto = 5, Cantidad = 89, Valor = 564.31},
                new ProductList(){IdProducto = 4, Cantidad = 19, Valor = 461.35}
            }}};

        List<Factura> _factura = new List<Factura>{
            new Factura(){NroFactura = "001", Fecha = DateOnly.Parse("10-05-2023"), IdCliente = 1, TotalFactura = 323.56},
            new Factura(){NroFactura = "002", Fecha = DateOnly.Parse("16-01-2023"), IdCliente = 3, TotalFactura = 89.36},
            new Factura(){NroFactura = "003", Fecha = DateOnly.Parse("22-09-2023"), IdCliente = 4, TotalFactura = 236.65},
            new Factura(){NroFactura = "004", Fecha = DateOnly.Parse("18-01-2023"), IdCliente = 2, TotalFactura = 167.21},
            new Factura(){NroFactura = "005", Fecha = DateOnly.Parse("18-01-2023"), IdCliente = 5, TotalFactura = 89.33},
            new Factura(){NroFactura = "006", Fecha = DateOnly.Parse("30-07-2023"), IdCliente = 4, TotalFactura = 214.36}
        };

        public void ListProducts(){
            var result = from e in _productos
                select new{
                    e.Id,
                    e.Nombre
                };
            foreach(var item in result){
                Console.WriteLine($"Id: {item.Id} - Nombre: {item.Nombre}");
            } 
        }

        public void CriticProducts(){
            var result = _productos.Where(e => e.Cantidad < e.StockMin);
            foreach(var item in result){
                Console.WriteLine("Los productos cercanos a agotarse son");
                Console.WriteLine($"Id: {item.Id} - Nombre: {item.Nombre}");
            }
        }

        public void Purchase(){
            var result = _productos.Where(e => e.Cantidad < e.StockMin)
                .Select(e => new ProductoDto{Nombre = e.Nombre, Cantidad = e.StockMax - e.Cantidad});
            foreach(var item in result){
                Console.WriteLine("La cantidad a comprar es la siguiente");
                Console.WriteLine($"Nombre: {item.Nombre} - Cantidad a comprar:{item.Cantidad}");
            }
        }

        public void FacturasEnero(){
            var result = _factura.Where(e => e.Fecha.Month == 1);
            foreach(var item in result)
            {
                Console.WriteLine("Lista de facturas del mes de enero");
                Console.WriteLine($"Nro Factura: {item.NroFactura} - Fecha: {item.Fecha} - IdCliente: {item.IdCliente}");
            }
        }

        public void ProductosVendidos(){
            Console.WriteLine("Listado de Facturas");
            foreach(var item in _detalleFactura)
            {
                Console.WriteLine($"Nro Factura: {item.NroFactura}");
            }
            Console.WriteLine("Ingrese un Nro de factura para listar los Productos");
            string searchFactura = Console.ReadLine();
            var result = _detalleFactura.Where(e => e.NroFactura == searchFactura).ToList();
            foreach(var item in result){
                foreach(var res in item.ProductLists){
                    Console.WriteLine("Productos relacionados a una factura");
                    Console.WriteLine($"Producto: {res.IdProducto} - Cantidad {res.Cantidad} - Valor Total: {res.Valor}");
                }
            }          
        }

        public void ValorTotal(){
            double total = 0;
            foreach(var item in _productos)
            {
                double acumulado;
                acumulado = item.PrecioUnit * item.Cantidad;
                total = acumulado + total;
            }
            Console.WriteLine($"El valo total del inventario es de: ${total}");
        }
    }
}