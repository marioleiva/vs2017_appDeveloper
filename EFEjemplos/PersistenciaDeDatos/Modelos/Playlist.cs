using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaDeDatos.Modelos
{
    public class Playlist
    {
        public int PlaylistId { get; set; }
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
    }

    public class Track
    {
        public int TrackId { get; set; }
        public string Name { get;set;}
        public string Composer { get;set;}
    }
}
