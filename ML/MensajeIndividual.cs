using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class MensajeIndividual
    {
        public int IdMensaje { get; set; }
        public ML.Usuario Usuario { get; set; }
        public string Mensaje { get; set; }

    }
}
