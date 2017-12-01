using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nucleo.LaparisORM.Models;
using Nucleo.LaparisORM.EntitiesModelsLP;

namespace Nucleo.LaparisORM.EntitiesModelsLP
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new modelContextLp())
            {
                var detalle = new DetalleServicio
                {
                    _descripcion = "son los detalles",
                    _horaInicio = DateTime.Parse("2017-04-20"),
                    _horaTermino = DateTime.Parse("2017-04-29"),
                    _mensaje = "HOLA",
                    _precio = 39494,
                    _fechaInicio = DateTime.Parse("2017-04-20"),
                    _promocion = 23
                };
                db.Detalles.Add(detalle);
                db.SaveChanges();
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();
                var tot = Console.ReadLine();
               
                var servicio = new Servicio { _nombre = name, _total = Decimal.Parse(tot)};
                db.Servicios.Add(servicio);
              
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Servicios
                            orderby b._nombre, b._total
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item._nombre);
                    Console.WriteLine(item._total);
                    Console.WriteLine(item._detalles.ToList());
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
