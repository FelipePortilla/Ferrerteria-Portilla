using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferreteria_Portilla.Class
{
    public class LinQ
    {
        List<Productos> Productos = new(){
            new(){Id = 1, Nombre = "Tornillos", Cantidad = 40, PrecioUnit = 500, StockMin = 40, StockMax = 300},
            new(){Id = 2, Nombre = "Tuercas", Cantidad = 100, PrecioUnit = 400, StockMin = 50, StockMax = 400},
            new(){Id = 3, Nombre = "Cables", Cantidad = 50, PrecioUnit = 600, StockMin = 40, StockMax = 300},
            new(){Id = 4, Nombre = "Cadenas", Cantidad = 40, PrecioUnit = 500, StockMin = 500, StockMax = 400},
            new(){Id = 5, Nombre = "Brocas", Cantidad = 40, PrecioUnit = 1000, StockMin = 10, StockMax = 300},
        };
        List<Factura> Facturas =new(){
            new(){
                NroFact = 123, 
                Fecha = new DateOnly(2022,08,25), 
                IdCliente = 1, 
                TotalFactura = 50000
                },

                new(){NroFact = 234, Fecha = new DateOnly(2023,04,13), IdCliente = 2, TotalFactura = 100000},
                new(){NroFact = 432, Fecha = new DateOnly(2023,02,14), IdCliente = 3, TotalFactura = 30000},
                new(){NroFact = 567, Fecha = new DateOnly(2023,01,18), IdCliente = 5, TotalFactura = 150000},
                new(){NroFact = 765, Fecha = new DateOnly(2023,09,1), IdCliente = 1, TotalFactura = 70000},
                new(){NroFact = 890, Fecha = new DateOnly(2023,07,23), IdCliente = 4, TotalFactura = 10000},
                new(){NroFact = 234, Fecha = new DateOnly(2023,1,3), IdCliente = 2, TotalFactura = 200000},
        };
        List<DetalleFact> Detalles =new(){
                new(){Id = 1, NroFact = 123, IdProd = 1, Cantidad = 2},
                new(){Id = 1, NroFact = 123, IdProd = 1, Cantidad = 2},
                new(){Id = 1, NroFact = 123, IdProd = 1, Cantidad = 2},
                new(){Id = 1, NroFact = 123, IdProd = 1, Cantidad = 2},
                new(){Id = 1, NroFact = 123, IdProd = 1, Cantidad = 2},
        };

        public void ListProductos(){
            Productos.ForEach(x => Console.WriteLine($"Nombre: {x.Nombre}, Id: {x.Id}, Cantidad: {x.Cantidad}, PrecioUnit: {x.PrecioUnit}"));

        }

        public void ListEndProductos(){
            var FinalProduct = (from j in Productos where j.Cantidad < j.StockMin select j).ToList();
            Console.WriteLine($"Los Productos que están próximos a Estar Terminados son:");
            FinalProduct.ForEach(J => Console.WriteLine($"{J.Nombre}: Cantidad: {J.Cantidad}, StockMin: {J.StockMin}"));
        }

        public void ListProductosDebeComprar(){
            var ProductsToBuy = (from p in Productos where p.Cantidad < p.StockMin select p).ToList();
            ProductsToBuy.ForEach(P => Console.WriteLine($"Los {P.Nombre} estan serca de Terminarse (solo quedan {P.Cantidad}),debes {P.StockMax - P.Cantidad}  para llegar al stock máximo"));
        }

        public void FacturasEnero(){
            var FacturasEnero = (from d in Facturas where d.Fecha.Month == 01 && d.Fecha.Year == 2023 select d).ToList();
            foreach (var item in FacturasEnero )
            {
                Console.WriteLine($"{(FacturasEnero .IndexOf(item)+1)}. NumeroFactura: {item.NroFact}, TotalFactura: {item.TotalFactura}, Fecha: {item.Fecha.Day}/{item.Fecha.Month}/{item.Fecha.Year}");
            }
        }
        public void GetProductosFromFacturas(){
            Console.WriteLine("Pon el número del Factura: ");
            int number = Convert.ToInt32(Console.ReadLine());
            var list = (from q in Detalles 
                        join w in Facturas 
                        on q.NroFact equals w.NroFact
                        join e in Productos on q.IdProd equals e.Id
                        where w.NroFact == number
                        select new {
                            IdProd = q.IdProd,
                            Cantidad = q.Cantidad,
                            Factura = q.NroFact,
                            Nombre = e.Nombre,
                            PrecioUnit = e.PrecioUnit,
                            Total = q.Cantidad * e.PrecioUnit
                        }).ToList();
            Console.WriteLine($"Los productos del número de Factura. {number}");
            list.ForEach(z => Console.WriteLine($"{new{z.IdProd, z.Cantidad, z.Nombre, z.PrecioUnit, z.Total}}"));
        }
        public void CalcularTotalPrecioStock(){
            int total = 0;
            foreach (var item in Productos)
            {
                total+=(item.Cantidad*item.PrecioUnit);
                Console.WriteLine($"El Precio Total de {item.Nombre} en el inventario es: {item.PrecioUnit*item.Cantidad}");
            }
            Console.WriteLine($"El Precio Total de todo el inventario es: {total}");
        }
    }
}