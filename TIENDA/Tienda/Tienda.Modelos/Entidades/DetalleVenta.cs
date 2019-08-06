using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Modelos.Entidades
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        public string Producto { get; set; }
        public double Monto { get; set; }
    }
}
