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
        public List<Parada> paradas { get; set; }

        public static Aplicador extraerAplicador(string[] fid, int lineaInicio)
        {
            int indNombre = Extraer.buscarSubStringEnFid(fid, "Points: ", lineaInicio);
            int finTotal = Array.IndexOf(fid, "", lineaInicio);
            Aplicador aplicador = new Aplicador()
            {
                nombre = (fid[indNombre].Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries))[1],
                paradas = new List<Parada>(),
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
                Parada parada = Parada.extraer(partes);
                aplicador.paradas.Add(parada);
            }
            return aplicador;
        }
    }


}
