using System;

namespace App.Data.DataAccess
{
    public class ArtistDA
    {
        /// <summary>
        /// Obtiene la cantidad de registros
        /// </summary>
        /// <returns></returns>

        public int GetCount()
        {
            var sql = "select count (artistid) from artist";


        }

    }
}
