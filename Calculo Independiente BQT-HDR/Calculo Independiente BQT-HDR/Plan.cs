using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class Plan
    {
        public string nombre { get; set; }
        public string ID { get; set; }
        public DateTime fecha { get; set; }
        public List<Aplicador> aplicadores { get; set; }
        public List<PuntoDosis> puntos { get; set; }
        public List<Linea> lineas { get; set; }
    }
}
