using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;

namespace Calculo_Independiente_BQT_HDR
{
    class Extraer
    {
        public static string[] cargar(string archivo)
        {
            return File.ReadAllLines(archivo);
        }

        public static string extraerString(string[] fid, int linea)
        {
            string aux = fid[linea]; string[] aux2 = aux.Split('='); string salida = aux2[1];
            return salida;
        }
        public static double extraerDouble(string[] fid, int linea)
        {
            return Convert.ToDouble(extraerString(fid, linea));
        }

        public static string extraerFecha(string[] fid, int linea)
        {
            string aux = extraerString(fid, linea);
            return aux.Split(',')[0];
        }

        public static double[,] extraerMatriz(string[] fid, int lineaI, int lineaF, int Tam1, int Tam2)
        {
            double[,] M = new double[Tam1, Tam2];
            for (int i = 0; i < Tam2; i++)
            {
                string[] stringLinea = fid[lineaI + i].Split('\t');
                double[] aux1 = stringLinea.Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
                for (int j = 0; j < Tam1; j++)
                {
                    M[j, i] = aux1[j];
                }
            }
            return M;
        }
        public static int buscarSubStringEnFid(string[] fid, string SubString, int Inicio=0)
        {
            int indice = 0;
            for (int i=Inicio;i<fid.Length;i++)
            {
                if (fid[i].Contains(SubString))
                {
                    indice = i;
                    break;
                }
            }
            return indice;
        }

        public static int extraerPuntosYLineas(string[] fid, List<PuntoDosis> puntos, List<Linea> lineas, int lineaInicio=0)
        {
            int inicio = buscarSubStringEnFid(fid, "Reference point", lineaInicio);
            inicio = buscarSubStringEnFid(fid, "x [cm] y [cm] z [cm] Total dose [cGy]", inicio);
            int fin = Array.IndexOf(fid, "", inicio);
            while (inicio<fin)
            {
                inicio++;
                string aux = fid[inicio];
                string[] partes = aux.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (partes.Length == 5)
                {
                    PuntoDosis punto = PuntoDosis.extraer(partes);
                    puntos.Add(punto);
                }
                else if (partes.Length == 1)
                {
                    int finLinea = buscarSubStringEnFid(fid, "x [cm] y [cm] z [cm] Total dose [cGy]", inicio+2)-2;
                    if (finLinea == -2)
                    {
                        finLinea = fin - 1;
                    }
                    Linea linea = Linea.extraer(fid, inicio, finLinea);
                    lineas.Add(linea);
                    inicio = finLinea;
                }
            }
            return inicio;
        }

        public static int extraerAplicadores(string[] fid, List<Aplicador> aplicadores, int lineaInicio=0)
        {
            int inicio = buscarSubStringEnFid(fid, "Geometrical information", lineaInicio)+1;
            int fin = Array.IndexOf(fid, "", inicio);
            while (inicio<fin)
            {
                Aplicador aplicador = Aplicador.extraerAplicador(fid, inicio);
                aplicadores.Add(aplicador);
                inicio += aplicador.paradas.Count()+2;
            }
            return fin;
        }


       
    }
}
