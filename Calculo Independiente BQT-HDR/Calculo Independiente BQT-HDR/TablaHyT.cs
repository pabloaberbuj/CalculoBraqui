using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class TablaHyT
    {
        //public static string file = @"..\..\tablaHyT.txt";
        public static string file = @"tablaHyT.txt";
        public double[] etiquetasH { get; set; }
        public double[] etiquetasT { get; set; }
        public double[,] valores { get; set; }
        public double factor { get; set; }

        public void cargarValores()
        {
            factor = 40700 / 3600;
            string[] fid = File.ReadAllLines(file);
            etiquetasH = Extraer.extraerLineaDouble(fid, 0);
            etiquetasT = Extraer.extraerLineaDouble(fid, 1);
            valores = Extraer.extraerMatriz(fid, 4, 38, 18);
        }
    }



}
