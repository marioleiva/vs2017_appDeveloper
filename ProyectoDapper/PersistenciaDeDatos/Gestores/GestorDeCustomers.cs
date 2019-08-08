using Dapper;
using PersistenciaDeDatos.Compartidos;
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

        public List<Customer> ListarCustomer()
        {
            using (var conexion = fabricaDeConexiones.ConstruirConexionAChinook())
            {
                //var listaDeCustomers = conexion.Query<Customer>(
                //    "Select * from Customer",  // where id = @Id
                //    //new {id = 1},    clase anonima
                //    commandType: CommandType.Text
                //    ).ToList();

                var listaDeCustomers = conexion.Query<Customer>(
                    "ListarCustomers",  // where id = @Id
                                               //new {id = 1},    clase anonima
                    commandType: CommandType.StoredProcedure
                    ).ToList();
                return listaDeCustomers;
            }
        }

        public void InsertarGenre(string nombreGenero)
        {
            using (var conexion = fabricaDeConexiones.ConstruirConexionAChinook())
            {
                conexion.Execute("INSERT INTO Genre(Name) values (@Name)"
                    , new { Name = nombreGenero }
                    , commandType: CommandType.Text
                    );
            }

            }
    }
}
