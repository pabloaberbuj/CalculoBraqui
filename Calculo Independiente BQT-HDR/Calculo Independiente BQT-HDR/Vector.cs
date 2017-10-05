using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class Vector
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }

        public static Vector difEntreFuentes(Fuente p1, Fuente p2)
        {
            Vector vector = new Vector()
            {
                x = p2.x - p1.x,
                y = p2.y - p1.y,
                z = p2.z - p1.z,
            };
            return vector;
        }

        public static Vector promedio(Vector v1, Vector v2)
        {
            Vector promedio = new Vector()
            {
                x = (v1.x + v2.x) / 2,
                y = (v1.y + v2.y) / 2,
                z = (v1.z + v2.z) / 2,
            };
            return promedio;
        }

        public static double modulo(Vector v1)
        {
            return Math.Sqrt(v1.x * v1.x + v1.y * v1.y + v1.z * v1.z);
        }
        public static Vector normalizar(Vector v1)
        {
            Vector vN = new Vector()
            {
                x = v1.x / modulo(v1),
                y = v1.y / modulo(v1),
                z = v1.z / modulo(v1),
            };
            return vN;
        }

        public static Vector vectorDistanciaFuentePunto(Fuente f, PuntoDosis p)
        {
            Vector distancia = new Vector()
            {
                x = f.x - p.x,
                y = f.y - p.y,
                z = f.z - p.z,
            };
            return distancia;
        }

        public static double distanciaFuentePunto(Fuente f,PuntoDosis p)
        {
            return modulo(vectorDistanciaFuentePunto(f, p));
        }
    }
}
