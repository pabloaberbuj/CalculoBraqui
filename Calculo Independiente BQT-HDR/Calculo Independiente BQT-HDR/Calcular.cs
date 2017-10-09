using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    class Calcular
    {
        public static Vector vectorDistanciaFuentePunto(Fuente f, PuntoDosis p)
        {
            return Vector.resta(p.posicion, f.posicion);
        }

        public static double distanciaFuentePunto(Fuente f, PuntoDosis p)
        {
            return Vector.modulo(vectorDistanciaFuentePunto(f, p));
        }

        public static Vector directorFuente(Aplicador aplicador, Fuente fuente)
        {
            Vector directorFuente = new Vector();
            int indiceFuente = aplicador.fuentes.IndexOf(fuente);
            if (indiceFuente == 0)
            {
                directorFuente = Vector.normalizar(difEntreFuentes(aplicador.fuentes[indiceFuente], aplicador.fuentes[indiceFuente + 1]));
            }
            else if (indiceFuente == aplicador.fuentes.Count() - 1)
            {
                directorFuente = Vector.normalizar(difEntreFuentes(aplicador.fuentes[indiceFuente - 1], aplicador.fuentes[indiceFuente]));
            }
            else
            {
                Vector director1 = difEntreFuentes(aplicador.fuentes[indiceFuente], aplicador.fuentes[indiceFuente + 1]);
                Vector director2 = difEntreFuentes(aplicador.fuentes[indiceFuente - 1], aplicador.fuentes[indiceFuente]);
                directorFuente = Vector.normalizar(Vector.promedio(director1, director2));
            }
            return directorFuente;
        }

        public static Vector dF(Aplicador aplicador, Fuente fuente)
        {
            Vector directorFuente = new Vector();
            int indiceFuente = aplicador.fuentes.IndexOf(fuente);
            if (indiceFuente == 0)
            {
                directorFuente = difEntreFuentes(aplicador.fuentes[indiceFuente], aplicador.fuentes[indiceFuente + 1]);
            }
            else if (indiceFuente == aplicador.fuentes.Count() - 1)
            {
                directorFuente = difEntreFuentes(aplicador.fuentes[indiceFuente - 1], aplicador.fuentes[indiceFuente]);
            }
            else
            {
                Vector director1 = difEntreFuentes(aplicador.fuentes[indiceFuente], aplicador.fuentes[indiceFuente + 1]);
                Vector director2 = difEntreFuentes(aplicador.fuentes[indiceFuente - 1], aplicador.fuentes[indiceFuente]);
                directorFuente = Vector.promedio(director1, director2);
            }
            return directorFuente;
        }

        public static List<Vector> directoresAplicador(Aplicador aplicador)
        {
            List<Vector> directores = new List<Vector>();
            foreach (Fuente fuente in aplicador.fuentes)
            {
                Vector director = directorFuente(aplicador, fuente);
                directores.Add(director);
            }
            return directores;
        }

        public static Vector difEntreFuentes(Fuente p1, Fuente p2)
        {
            return Vector.resta(p1.posicion, p2.posicion);
        }

        public static double paramT(Aplicador ap, Fuente f, PuntoDosis p)
        {
            return Vector.productoEscalar(vectorDistanciaFuentePunto(f, p), directorFuente(ap, f));
        }

        public static double paramH(Aplicador ap, Fuente f, PuntoDosis p)
        {
            return Math.Sqrt(Math.Pow(distanciaFuentePunto(f, p), 2) - Math.Pow(paramT(ap, f, p), 2));
        }

        public static double interpolar1D(double x1, double x2, double z1, double z2, double x)
        {
            double z;
            if (x == x1) { z = z1; }
            else if (x == x2) { z = z2; }

            else { z = z1 + (z2 - z1) / (x2 - x1) * (x - x1); }
            return z;
        }

        public static double buscaEnTabla(double X, double Y, double[] etiquetasX, double[] etiquetasY, double[,] valores)
        {
            int iX = Array.IndexOf(etiquetasX, X);
            int iY = Array.IndexOf(etiquetasY, Y);
            double XY = valores[iX, iY]; //ver que es así y no al revés
            return XY;
        }


        public static double interpolar2DValores(double x1, double x2, double y1, double y2, double x, double y, double[] etiquetasX, double[] etiquetasY, double[,] valores)
        {
            double z; double z1; double z2;
            if (x == x1 || x == x2)
            {
                z1 = buscaEnTabla(x, y1, etiquetasX, etiquetasY, valores);
                z2 = buscaEnTabla(x, y2, etiquetasX, etiquetasY, valores);
                z = interpolar1D(y1, y2, z1, z2, y);
            }
            else if (y == y1 || y == y2)
            {
                z1 = buscaEnTabla(x1, y, etiquetasX, etiquetasY, valores);
                z2 = buscaEnTabla(x2, y, etiquetasX, etiquetasY, valores);
                z = interpolar1D(x1, x2, z1, z2, x);
            }
            else
            {
                double z11 = buscaEnTabla(x1, y1, etiquetasX, etiquetasY, valores);
                double z21 = buscaEnTabla(x2, y1, etiquetasX, etiquetasY, valores);
                double z12 = buscaEnTabla(x1, y2, etiquetasX, etiquetasY, valores);
                double z22 = buscaEnTabla(x2, y2, etiquetasX, etiquetasY, valores);
                z1 = interpolar1D(x1, x2, z11, z21, x);
                z2 = interpolar1D(x1, x2, z12, z22, x);
                z = interpolar1D(y1, y2, z1, z2, y);
            }
            return z;
        }

        public static int buscarIndiceSiguiente(double x, double[] etiquetasX)
        {
            return Array.FindIndex(etiquetasX, X => X > x);

        }
        public static double interpolar2DTabla(double x, double y, double[] etiquetasX, double[] etiquetasY, double[,] valores)
        {
            double x1; double x2; double y1; double y2;
            if (etiquetasX[0] < etiquetasX[1]) //X Creciente
            {
                int iX2 = Array.FindIndex(etiquetasX, X => X > x);
                x2 = etiquetasX[iX2]; x1 = etiquetasX[iX2 - 1];
            }
            else //X Decreciente
            {
                int iX2 = Array.FindIndex(etiquetasX, X => X < x);
                x2 = etiquetasX[iX2]; x1 = etiquetasX[iX2 - 1];
            }

            if (etiquetasY[0] < etiquetasY[1]) //Y Creciente
            {
                int iY2 = Array.FindIndex(etiquetasY, Y => Y > y);
                y2 = etiquetasY[iY2]; y1 = etiquetasY[iY2 - 1];
            }
            else //Y Decreciente
            {
                int iY2 = Array.FindIndex(etiquetasY, Y => Y < y);
                y2 = etiquetasY[iY2]; y1 = etiquetasY[iY2 - 1];
            }
            return interpolar2DValores(x1, x2, y1, y2, x, y, etiquetasX, etiquetasY, valores);

        }

        public static double tasaDosisHT(double H, double T, TablaHyT tabla)
        {
            return interpolar2DTabla(H, T, tabla.etiquetasH, tabla.etiquetasT, tabla.valores);
        }

        public static double tasaDosisPuntoFuente(Aplicador ap, Fuente f, PuntoDosis p, TablaHyT tabla)
        {
            double H = paramH(ap, f, p);
            double T = paramT(ap, f, p);
            return tasaDosisHT(H,T,tabla);
        }

        public static double dosisPuntoFuente(Aplicador ap, Fuente f, PuntoDosis p, TablaHyT tabla)
        {
            return tasaDosisPuntoFuente(ap, f, p, tabla) * f.tiempo*tabla.factor;
        }

        public static void dosisPunto(Plan plan, PuntoDosis p, TablaHyT tabla)
        {
            double dosisSinRedondear = 0;
            foreach (Aplicador ap in plan.aplicadores)
            {
                foreach (Fuente f in ap.fuentes)
                {
                    dosisSinRedondear+= dosisPuntoFuente(ap, f, p, tabla);
                }
            }
            p.dosisCalculo = Math.Round(dosisSinRedondear, 1);
            p.diferenciaDosis = Math.Round((p.dosisCalculo - p.dosisTPS) / p.dosisTPS * 100,1);
        }

        public static void dosisLinea(Plan plan, Linea l, TablaHyT tabla)
        {
            foreach (PuntoDosis p in l.puntos)
            {
                dosisPunto(plan, p, tabla);
            }
        }

        public static void tasasDosis(Plan plan, TablaHyT tabla)
        {
            foreach (PuntoDosis p in plan.puntos)
            {
                dosisPunto(plan, p, tabla);
            }
            foreach (Linea l in plan.lineas)
            {
                dosisLinea(plan, l, tabla);
            }
        }
        public static double calcularPrescripcion(Plan plan)
        {
            double suma = 0;
            Linea lineaPrescripcion = plan.lineas[plan.lineas.Count() - 1];
            foreach (PuntoDosis p in lineaPrescripcion.puntos)
            {
                suma += p.dosisTPS;
            }
            return suma / lineaPrescripcion.puntos.Count();
        }

        public static void calcularTodo(string[] fid, Plan plan, TablaHyT tabla)
        {
            plan.nombre = Extraer.extraerNombre(fid);
            plan.ID = Extraer.extraerID(fid);
            plan.prescripcion = Extraer.extraerPrescripcion(fid);
            plan.fecha = DateTime.Today;
            plan.aplicadores = new List<Aplicador>();
            plan.lineas = new List<Linea>();
            plan.puntos = new List<PuntoDosis>();
            Extraer.extraerAplicadores(fid, plan.aplicadores);
            Extraer.extraerPuntosYLineas(fid, plan.puntos, plan.lineas);
            tasasDosis(plan, tabla);
        }

        public static List<HyT> listaHsyTs(Plan plan, TablaHyT tabla)
        {
            List<HyT> lista = new List<HyT>();
            foreach (Aplicador ap in plan.aplicadores)
            {
                foreach (Fuente f in ap.fuentes)
                {
                    foreach (PuntoDosis p in todosLosPuntos(plan))
                    {
                        if (p.nombre == "  recto3_1")
                        {
                            HyT hyt = new HyT()
                            {
                                directorSNx = Math.Round(dF(ap, f).x,2),
                                directorSNy = Math.Round(dF(ap, f).y,2),
                                directorSNz = Math.Round(dF(ap, f).z,2),
                                aplicador = ap.nombre,
                                fuente = ap.fuentes.IndexOf(f),
                                punto = p.nombre,
                                H = Math.Round(paramH(ap, f, p), 2),
                                T = Math.Round(paramT(ap, f, p), 2),
                                tasaDosis = Math.Round(tasaDosisHT(Math.Round(paramH(ap, f, p), 2), Math.Round(paramT(ap, f, p), 2),tabla),4),
                            };
                            lista.Add(hyt);
                        }
                        
                    }
                }
            }
            return lista;
        }

        public static List<PuntoDosis> todosLosPuntos(Plan plan)
        {
            List<PuntoDosis> todosLosPuntos = new List<PuntoDosis>();
            foreach (PuntoDosis p in plan.puntos)
            {
                todosLosPuntos.Add(p);
            }
            foreach (Linea l in plan.lineas)
            {
                foreach (PuntoDosis p in l.puntos)
                {
                    todosLosPuntos.Add(p);
                }
            }
            return todosLosPuntos;
        }
    }
}
