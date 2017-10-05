using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Calculo_Independiente_BQT_HDR
{
    public class Aplicador
    {
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Browsable(false)]
        public List<Fuente> fuentes { get; set; }
        [DisplayName("Nº de fuentes")]
        public int numeroFuentes { get; set; }

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
            aplicador.numeroFuentes = aplicador.fuentes.Count();
            return aplicador;
        }

        
    }


}
