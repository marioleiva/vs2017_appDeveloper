using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tienda.Modelos.Entidades;
using Tienda.Modelos.Extensiones;

namespace Tienda.Modelos
{
    public class GestorDeVentas
    {
        private string conexionABaseDeDatos = "SERVER=S300-ST;DataBase=Tienda; USER ID=sa; PASSWORD=sql";


        public Venta RegistrarVenta(string nombreCliente, List<NuevoDetalleVenta> detalles)
        {
            using (var conexion = new SqlConnection(conexionABaseDeDatos))
            {
                using (var resultadoMultiple = conexion.QueryMultiple(
                    "RegistrarVenta", new
                    {
                        Cliente = nombreCliente,
                        Detalles = detalles.ConvertirATablaDeDetalles()
                    },
                    commandType:CommandType.StoredProcedure
                    ))
                {
                    var venta = resultadoMultiple.Read<Venta>().Single();
                    venta.Detalles = resultadoMultiple.Read<DetalleVenta>().ToList();
                    return venta;
                }
            }
        } 
    }
}
