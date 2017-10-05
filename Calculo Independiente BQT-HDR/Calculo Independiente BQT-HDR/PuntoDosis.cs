using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Calculo_Independiente_BQT_HDR
{
    public class PuntoDosis
    {
        [DisplayName("Nombre")]
        public string nombre { get; set; }
        [Browsable(false)]
        public Vector posicion { get; set; }
        [DisplayName("Dosis Plan")]
        public double dosisTPS { get; set; }
        [DisplayName("Dosis Cálculo")]
        public double dosisCalculo { get; set; }
        [DisplayName("Diferencia [%]")]
        public double diferenciaDosis { get; set; }

        public static PuntoDosis extraer(string[] partes)
        {
            PuntoDosis punto = new PuntoDosis()
            {
                nombre = partes[0],
                posicion = new Vector()
                {
                    x = Convert.ToDouble(partes[1]),
                    y = Convert.ToDouble(partes[2]),
                    z = Convert.ToDouble(partes[3]),
                },
                dosisTPS = Convert.ToDouble(partes[4]),
            };
            return punto;
        }
        
    }

    
}
