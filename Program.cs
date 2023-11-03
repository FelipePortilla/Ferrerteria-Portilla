using System.Text.RegularExpressions;
using Ferreteria_Portilla.Class;


internal class Program
{
    private static void Main(string[] args)
    {
        LinQ funciones = new();
        bool bandera = false;

        while (bandera == false){
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" Ferretería de acero ");
            Console.WriteLine("" );
            Console.WriteLine(" 1. Listar productos de inventario ");
            Console.WriteLine(" 2. Listar los productos por terminar ");
            Console.WriteLine(" 3. Enumere los productos que debe comprar ");
            Console.WriteLine(" 4. Lista de recibos de enero de 2023 ");
            Console.WriteLine(" 5. Enumerar productos de un recibo ");
            Console.WriteLine(" 6. Calcule el inventario total ");
            Console.WriteLine(" 7. Salir ");
            Console.WriteLine($"Elige una opción: ");
            var opcion = Console.ReadLine();
            
                switch (opcion)
                {
                    case "1":
                        Console.Clear();
                        funciones.ListProductos();
                        Console.ReadKey();
                        break;
                    case "2":
                        Console.Clear();
                        funciones.ListEndProductos();
                        Console.ReadKey();
                        break;
                    case "3":
                        Console.Clear();
                        funciones.ListProductosDebeComprar();
                        Console.ReadKey();
                        break;
                    case "4":
                        Console.Clear();
                        funciones.FacturasEnero();
                        Console.ReadKey();
                        break;
                    case "5":
                        Console.Clear();
                        funciones.GetProductosFromFacturas();
                        Console.ReadKey();
                        break;
                    case "6":
                        Console.Clear();
                        funciones.CalcularTotalPrecioStock();
                        Console.ReadKey();
                        break;
                    case "7":
                        Console.Clear();
                        Console.WriteLine("Gracias por usar nuestro Servicio");
                        bandera = true;
                        break;
                    default:
                        Console.WriteLine("No haz seleccionado ninguna de las opciones.");
                        Console.WriteLine($"Hasta luego mi Papacho:)");
                        bandera = true;
                        break;
                    }
        }
    }
}