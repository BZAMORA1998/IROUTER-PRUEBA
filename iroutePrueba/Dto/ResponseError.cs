using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iroutePrueba.DTO
{
    public class ResponseError
    {
        private bool procesoExitoso;
        private string mensaje;

        public ResponseError(string message)
        {
            this.procesoExitoso = false;
            this.mensaje = message;
        }

        public bool ProcesoExitoso { get => procesoExitoso; set => procesoExitoso = value; }
        public string Mensaje { get => mensaje; set => mensaje = value; }
    }
}
