﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculo_Independiente_BQT_HDR
{
    public class PuntoDosis
    {
        public string nombre { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public double dosis { get; set; }

        public static PuntoDosis extraer(string[] partes)
        {
            PuntoDosis punto = new PuntoDosis()
            {
                nombre = partes[0],
                x = Convert.ToDouble(partes[1]),
                y = Convert.ToDouble(partes[2]),
                z = Convert.ToDouble(partes[3]),
                dosis = Convert.ToDouble(partes[4]),
            };
            return punto;
        }
        
    }

    
}