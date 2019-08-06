using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Modelos.Entidades
{
    public class Venta
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public List<DetalleVenta> Detalles { get; set; }
    }
}
