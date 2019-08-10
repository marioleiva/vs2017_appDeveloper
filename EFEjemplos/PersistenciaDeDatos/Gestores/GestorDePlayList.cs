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
    public class GestorDePlayList
    {
        private FabricaDeConexiones fabricaDeConexiones = new FabricaDeConexiones();

        public Playlist RecuperarPlayListPorId(int id)
        {
            using (var conexion = this.fabricaDeConexiones.ConstruirConexionAChinook())
            {
                using (var queryMultiple = conexion.QueryMultiple(
                    "SacarPlayListConTrack",
                    new { Id = id },
                    commandType: CommandType.StoredProcedure))
                {
                    var playlist = queryMultiple.Read<Playlist>().Single();
                    playlist.Tracks = queryMultiple.Read<Track>().ToList();
                    return playlist;
                }
            }
        }
    }
}
