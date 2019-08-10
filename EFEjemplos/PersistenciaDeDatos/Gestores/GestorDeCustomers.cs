using Dapper;
using PersistenciaDeDatos.Compartido;
using PersistenciaDeDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaDeDatos.Gestores
{
    public class GestorDeCustomers
    {
        private FabricaDeConexiones fabricaDeConexiones = new FabricaDeConexiones();

        public List<Customer> ListarCustomers()
        {
            using (var conexion = fabricaDeConexiones.ConstruirConexionAChinook())
            {
                var listaDeCustomers = conexion.Query<Customer>(
                        "ListarCustomers",
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                return listaDeCustomers;
            }
        }

        public List<Customer> RecuperarCustomersPorId(List<int> ids)
        {
            using (var conexion = this.fabricaDeConexiones.ConstruirConexionAChinook())
            {
                DataTable listaDeEnteros = new DataTable("ListDeEnteros");
                listaDeEnteros.Columns.Add("Id", typeof(int));
                ids.ForEach(x => listaDeEnteros.Rows.Add(x));

                return conexion.Query<Customer>(
                    "ListarCustomerPorId",
                    new { Ids = listaDeEnteros },
                    commandType: CommandType.StoredProcedure                    
                ).ToList();
            }
        }


        public void InsertarGenre(string nombreDeGeneroMusical)
        {
            using (var conexion = fabricaDeConexiones.ConstruirConexionAChinook())
            {
                conexion.Execute(
                        "INSERT INTO Genre(Name) VALUES(@Name)"
                        , new { Name = nombreDeGeneroMusical }
                        , commandType: CommandType.Text
                    );
            }
        }

    }
}
