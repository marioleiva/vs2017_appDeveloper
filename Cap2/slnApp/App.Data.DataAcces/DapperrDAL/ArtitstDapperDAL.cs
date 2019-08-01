using App.Entities_Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperrDAL
{
    public class ArtitstDapperDAL : DALBase
    {
        public Artist GetArtistId(int id)
        {
            using (IDbConnection connection = this.getConnection())
            {
                using (var multi = connection.QueryMultiple("GetArtist", new { ArtistId = id }, commandType: CommandType.StoredProcedure))
                {
                    var artist = multi.Read<Artist>().Single();
                    artist.Album = multi.Read<Album>().ToList();
                    return artist;

                }
            }
        }

    }
}
