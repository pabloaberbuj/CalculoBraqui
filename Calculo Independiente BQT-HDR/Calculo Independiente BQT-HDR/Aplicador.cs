using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class Aplicador
    {
        public string nombre { get; set; }
        public List<Fuente> fuentes { get; set; }

        public static Aplicador extraerAplicador(string[] fid, int lineaInicio)
        {
            int indNombre = Extraer.buscarSubStringEnFid(fid, "Points: ", lineaInicio);
            int finTotal = Array.IndexOf(fid, "", lineaInicio);
            Aplicador aplicador = new Aplicador()
            {
                nombre = (fid[indNombre].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))[1],
                fuentes = new List<Fuente>(),
            };

            int inicio = indNombre + 2;
            int fin = Extraer.buscarSubStringEnFid(fid, "Points: ", inicio) - 1;
            if (fin ==-1)
            {
                fin = finTotal - 1;
            }
            for (int i = inicio; i < fin + 1; i++)
            {
                string aux = fid[i];
                string[] partes = aux.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Fuente fuente = Calculo_Independiente_BQT_HDR.Fuente.extraer(partes);
                aplicador.fuentes.Add(fuente);
            }
            return aplicador;
        }

        public static Vector Fuente(Aplicador aplicador, int indiceFuente)
        {
            Vector directorFuente = new Vector();
            if (indiceFuente==0)
            {
                directorFuente = Vector.normalizar(Vector.difEntreFuentes(aplicador.fuentes[indiceFuente], aplicador.fuentes[indiceFuente + 1]));
            }
            else if (indiceFuente == aplicador.fuentes.Count()-1)
            {
                directorFuente = Vector.normalizar(Vector.difEntreFuentes(aplicador.fuentes[indiceFuente-1], aplicador.fuentes[indiceFuente]));
            }
            else
            {
                Vector director1 = Vector.difEntreFuentes(aplicador.fuentes[indiceFuente], aplicador.fuentes[indiceFuente + 1]);
                Vector director2 = Vector.difEntreFuentes(aplicador.fuentes[indiceFuente - 1], aplicador.fuentes[indiceFuente]);
                directorFuente = Vector.normalizar(Vector.promedio(director1, director2));
            }
            return directorFuente;
        }

        public static List<Vector> directoresTodasLasFuentes(Aplicador aplicador)
        {
            List<Vector> directores = new List<Vector>();
            for (int i=0;i<aplicador.fuentes.Count();i++)
            {
                Vector director = Fuente(aplicador, i);
                directores.Add(director);
            }
            return directores;
        }
    }


}
