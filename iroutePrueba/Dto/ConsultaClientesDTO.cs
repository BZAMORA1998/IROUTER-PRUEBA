using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iroutePrueba.Dto
{
    public class ConsultaClientesDTO
    {
        public int id { get; set; }
        public string primerNombre { get; set; }
        public string segundoNombre { get; set; }
        public string apellidos { get; set; }
        public string identificacion { get; set; }
        public string mail { get; set; }
        public int estado { get; set; }
        public string estadoDesc { get; set; }

    }
}
