using PersistenciaDeDatos.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            // ejecutar sql en el codigo
            GestorDeCustomers gestorDeCustomers = new GestorDeCustomers();
            gestorDeCustomers.ListarCustomer().ForEach(x =>
            {
                Console.WriteLine($" Lista dirección { x.Address} Lista ciudades {x.City } "    );
            });

            gestorDeCustomers.ListarCustomer()
                .Select(x => x.City)
                .Distinct()
                .ToList()
                .ForEach(x => gestorDeCustomers.InsertarGenre(x));

            Console.ReadKey();
        }
    }
}
