using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class Fuente
    {
        public Vector posicion { get; set; }
        public double tiempo { get; set; }

        public static Fuente extraer(string[] partes)
        {
            Fuente fuente = new Fuente()
            {
                posicion = new Vector()
                {
                    x = Convert.ToDouble(partes[0]),
                    y = Convert.ToDouble(partes[1]),
                    z = Convert.ToDouble(partes[2]),
                },
                tiempo = Convert.ToDouble(partes[5]), //tiempo
            };
            return fuente;
        }

        
    }
}
