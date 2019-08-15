using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{

    public class Evento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime? FechaMaximaInscripcion { get; set; }
    }
}
