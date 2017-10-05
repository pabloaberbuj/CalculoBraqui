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

        private void BT_CargarClick(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Archivos prn(.prn)|*.prn|All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string[] fid = Extraer.cargar(openFileDialog1.FileName);
                TablaHyT tabla = new TablaHyT();
                tabla.cargarValores();
                Plan plan = new Plan();
                Calcular.calcularTodo(fid, plan, tabla);
                DGV_Aplicadores.DataSource = plan.aplicadores;
                DGV_Puntos.DataSource = todosLosPuntos(plan);
            }
        }

        private List<PuntoDosis> todosLosPuntos(Plan plan)
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
