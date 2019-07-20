using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using App.Entities_Base;



namespace App.Data.DataAcces
{
    public class ArtistDA : BaseDA
    {
        /// <summary>
        /// Obtiene la cantidad de registros
        /// </summary>
        /// <returns></returns>

        public int GetCount()
        {
            int Result = 0;
            try
            {    //1. Consulta SQL
                var sql = "SELECT COUNT(ArtistId) FROM Artist";
                
                // 2 creando objeto conexion
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo conexion
                    cnx.Open();
                    //3. Creando un objeto comand
                    var cmd = cnx.CreateCommand();
                    //Asignando la consulta SQL al objeto command
                    cmd.CommandText = sql;
                    Result = (int)cmd.ExecuteScalar();
                }
            }
            catch (Exception)
            {
                Result = -1;
            }
                return Result;
        }
        public List<Artist> GetArtist()
        {
            var result = new List<Artist>();
            var sql = "select * from Artist";
            using(IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                //var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var artist = new Artist();
                    // MAPEO DE DATOS
                    artist.ArtistId = reader.GetInt32(0);
                    //indice = reader.GetOrdinal("ArtistId");
                    //artist.ArtistId = reader.GetInt32(indice);  Valido
                    // artist.ArtistId = convert.ToInt32(reader["ArtistId"]);  genera un proceso adicional no recomendable
                    artist.Name = reader.GetString(1);
                    result.Add(artist);
                }  
            }
            return result;
        }

        public List<Artist> GetArtist(string filtroPorNombre) // Firma
        {
            var result = new List<Artist>();

            var sql = "usp_GetArtist";
            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                // COnfigurar parametros
                cmd.Parameters.Add(
                    new SqlParameter("@Nombre", filtroPorNombre)
                    );
                //var indice = 0;
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var artist = new Artist();
                    // MAPEO DE DATOS
                    artist.ArtistId = reader.GetInt32(0);
                    //indice = reader.GetOrdinal("ArtistId");
                    //artist.ArtistId = reader.GetInt32(indice);  Valido
                    // artist.ArtistId = convert.ToInt32(reader["ArtistId"]);  genera un proceso adicional no recomendable
                    artist.Name = reader.GetString(1);
                    result.Add(artist);
                }
            }
            return result;
        }

    }
}
