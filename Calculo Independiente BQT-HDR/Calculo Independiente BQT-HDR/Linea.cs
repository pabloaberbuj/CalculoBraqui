using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class Linea
    {
        public string nombre { get; set; }
        public List<PuntoDosis> puntos { get; set; }

        public static Linea extraer(string[] fid, int lineaInicial, int lineaFinal)
        {
            Linea linea = new Linea()
            {
                puntos = new List<PuntoDosis>(),
            };
            linea.nombre = fid[lineaInicial];
            for (int i = lineaInicial + 2; i < lineaFinal+1; i++)
            {
                string aux = fid[i];
                string[] partes = aux.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                PuntoDosis punto = new PuntoDosis()
                {
                    posicion = new Vector()
                    {
                        x = Convert.ToDouble(partes[0]),
                        y = Convert.ToDouble(partes[1]),
                        z = Convert.ToDouble(partes[2]),
                    },
                    dosisTPS = Convert.ToDouble(partes[3]),
                    nombre = linea.nombre +"_"+ (i-lineaInicial-1).ToString(),
                };
                linea.puntos.Add(punto);
            }
            return linea;
        }
    }
}

