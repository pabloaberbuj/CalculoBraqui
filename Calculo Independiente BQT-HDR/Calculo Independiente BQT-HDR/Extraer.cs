using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Globalization;
using System.Windows.Forms;

namespace Calculo_Independiente_BQT_HDR
{
    class Extraer
    {
        public static string[] cargar(string archivo)
        {
            try
            {
                return File.ReadAllLines(archivo);
            }
            catch (Exception e)
            {
                MessageBox.Show("No se ha podido abrir. Posiblemente el archivo esté en uso por otra aplicación\n\n" + e.ToString(),"Error abriendo el archivo");
                throw;
            }
            
        }

        public static string extraerString(string[] fid, int linea, char sep ='=' )
        {
            string aux = fid[linea]; string[] aux2 = aux.Split(sep); string salida = aux2[1];
            return salida;
        }
        public static double extraerDouble(string[] fid, int linea)
        {
            return Convert.ToDouble(extraerString(fid, linea));
        }

        public static double[] extraerLineaDouble(string[] fid, int linea)
        {
            string aux = extraerString(fid, linea);
            string[] auxLinea = aux.Split('\t');
            return auxLinea.Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
        }

        public static string extraerFecha(string[] fid, int linea)
        {
            string aux = extraerString(fid, linea);
            return aux.Split(',')[0];
        }

        public static double[,] extraerMatriz(string[] fid, int lineaI, int lineaF, int columnas)
        {
            int filas = lineaF - lineaI+1;
            double[,] M = new double[columnas, filas];
            for (int i = 0; i < filas; i++)
            {
                string[] stringLinea = fid[lineaI + i].Split('\t');
                double[] aux1 = stringLinea.Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray();
                for (int j = 0; j < columnas; j++)
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
            int inicio = buscarSubStringEnFid(fid, "Points:", lineaInicio);
            int fin = Array.IndexOf(fid, "", inicio);
            while (inicio<fin)
            {
                Aplicador aplicador = Aplicador.extraerAplicador(fid, inicio);
                aplicadores.Add(aplicador);
                inicio += aplicador.fuentes.Count()+2;
            }
            return fin;
        }

        public static string extraerNombre(string[] fid)
        {
            int linea = buscarSubStringEnFid(fid, "Patient Name: ");
            string[] sep = { "Source" } ;
            return (extraerString(fid, linea,':')).Split( sep,StringSplitOptions.None  )[0];
        }

        public static string extraerID(string[] fid)
        {
            int linea = buscarSubStringEnFid(fid, "Patient ID: ");
            string[] sep = { "Source" };
            return (extraerString(fid, linea, ':')).Split(sep, StringSplitOptions.None)[0];
        }

        public static double extraerPrescripcion(string[] fid)
        {
            int linea = buscarSubStringEnFid(fid, "Total prescription: ");
            string[] sep = { "cGy" };
            return Convert.ToDouble((extraerString(fid, linea, ':')).Split(sep, StringSplitOptions.None)[0]);
        }
    }
}
