using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaDeDatos.Compartidos
{
    public class FabricaDeConexiones
    {
        private string CadenaConexionChinook = "SERVER=S300-ST;DataBase=Chinook; USER ID=sa; PASSWORD=sql";
        public IDbConnection ConstruirConexionAChinook()
        {
            return new SqlConnection(this.CadenaConexionChinook);
        }
    }
}
