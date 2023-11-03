using System.Diagnostics;
using ferreteriaCampus.Clases;
using ferreteriaCampus.Methods;

internal class Program
{
    private static void Main(string[] args)
    {
        bool iniciar = true;
        while(iniciar == true){
        Principal _menu = new Principal();
        _menu.Menu();
        int opcion = Int32.Parse(Console.ReadLine());
        System.Console.WriteLine("Oprima una tecla para continuar");
        Console.ReadKey();
        Console.Clear();
        switch(opcion)
        {
            case 1:
                Principal method1 = new Principal();
                method1.ListProducts();
                Console.ReadKey();
                Console.Clear();
                break;
            case 2:
                Principal method2 = new Principal();
                method2.CriticProducts();
                Console.ReadKey();
                Console.Clear();
                break;
            case 3:
                Principal method3 = new Principal();
                method3.Purchase();
                Console.ReadKey();
                Console.Clear();
                break;
            case 4:
                Principal method4 = new Principal();
                method4.FacturasEnero();
                Console.ReadKey();
                Console.Clear();
                break;
            case 5:
                Principal method5 = new Principal();
                method5.ProductosVendidos();
                Console.ReadKey();
                Console.Clear();
                break;
            case 6:
                Principal method6 = new Principal();
                method6.ValorTotal();
                break;
            case 0:
                iniciar = false;
                break;
            default:
                Console.WriteLine("Ingrese una opcion valida");
                break;
        }
        }
    }
}