using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Modelos;

namespace Venta.ConsolaDePruebas
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorDeVentas gestorDeVentas = new GestorDeVentas();
            var venta = gestorDeVentas.RegistrarVenta("Daniel Carbajal", new List<NuevoDetalleVenta>()
            {
                new NuevoDetalleVenta() { Producto = "Chocolate" , Monto = 10},
                new NuevoDetalleVenta() { Producto = "Caramelo" , Monto = 20},
            });


            Console.ReadKey();
        }
    }
}
