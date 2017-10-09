using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Calculo_Independiente_BQT_HDR
{
    public class Registro
    {
        //public static string file = @"..\..\registro.txt";
        public static string file = @"registro.txt";
        public string nombre;
        public string ID;
        public double prescripcion;
        public DateTime fecha;
        public List<PuntoDosis> Puntos;

        public static Registro crear(string _nombre, string _ID, double _prescripcion, DateTime _fecha, List<PuntoDosis> _puntos)
        {
            return new Registro()
            {
                nombre = _nombre,
                ID = _ID,
                prescripcion = _prescripcion,
                fecha = _fecha,
                Puntos = _puntos,
            };
        }

        public static BindingList<Registro> lista()
        {
            return IO.readJsonList<Registro>(file);
        }

        public static void guardarPlan(Plan plan, List<PuntoDosis> puntos)
        {
            Registro _nuevo = crear(plan.nombre, plan.ID, plan.prescripcion, plan.fecha, puntos);
            IO.appendObjectAsJson<Registro>(file, _nuevo);
        }
    }
}
