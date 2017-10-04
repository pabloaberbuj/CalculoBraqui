using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculo_Independiente_BQT_HDR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos prn(.prn)|*.prn|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] fid = Extraer.cargar(openFileDialog1.FileName);
                //Linea.extraer(fid, 106, 109);
                List<Linea> lineas = new List<Linea>();
                List<PuntoDosis> puntos = new List<PuntoDosis>();
                Extraer.extraerPuntosYLineas(fid, puntos, lineas, 0);
                List<Aplicador> aplicadores = new List<Aplicador>();
                Extraer.extraerAplicadores(fid, aplicadores);
                List<Vector> vectores = new List<Vector>();
                vectores = Aplicador.directoresTodasLasParadas(aplicadores[0]);
            }
        }

        private void extraerPuntosYLineas(string[] fid)
        {
            
        }
    }
}
