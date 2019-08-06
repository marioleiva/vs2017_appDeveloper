using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tienda.Modelos.Extensiones
{
    public static class ExtensionDetalleVenta
    {
        public static DataTable ConvertirATablaDeDetalles(this List<NuevoDetalleVenta> detalles)
        {
            DataTable dataTable = new DataTable("DatosDelDetalle");
            dataTable.Columns.Add("Producto", typeof(string));
            dataTable.Columns.Add("Monto", typeof(double));
            detalles.ForEach(detalle =>
            {
                dataTable.Rows.Add(detalle.Producto,detalle.Monto);
            });
            return dataTable;
        }
    }
}
