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
                cargarDatosPaciente(fid, plan);
                DGV_Aplicadores.DataSource = plan.aplicadores;
                DGV_Puntos.DataSource = Calcular.todosLosPuntos(plan);
                chequearTolerancia(DGV_Puntos, 3, 3);
            }
        }

        private void cargarLabel(Label label, string valor)
        {
            if (valor != "")
            {
                label.Text = valor;
                label.Visible = true;
            }
            else
            {
                label.Text = "";
                label.Visible = false;
            }
        }

        private void cargarDatosPaciente(string[] fid, Plan plan)
        {
            cargarLabel(L_Nombre, Extraer.extraerNombre(fid));
            cargarLabel(L_ID, Extraer.extraerID(fid));
            cargarLabel(L_Prescripcion, Extraer.extraerPrescripcion(fid)+" cGy");
            chequeoPrescripcion(fid, plan);
        }

        private void chequeoPrescripcion(string[] fid, Plan plan)
        {
            double suma = 0;
            Linea lineaPrescripcion = plan.lineas[plan.lineas.Count() - 1];
            foreach (PuntoDosis p in lineaPrescripcion.puntos)
            {
                suma += p.dosisTPS;
            }
            double promedio = suma / lineaPrescripcion.puntos.Count();
            string escribir = promedio.ToString() + " cGy (en" + lineaPrescripcion.nombre + ")";
            cargarLabel(L_DosisPuntosA, escribir);
        }

        private void chequearTolerancia(DataGridView dgv, int numColumna, double tolerancia)
        {
            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (Math.Abs(Convert.ToDouble(fila.Cells[numColumna].Value)) <= tolerancia)
                {
                    fila.Cells[numColumna].Style.BackColor = Color.LightGreen;
                }
                else
                {
                    fila.Cells[numColumna].Style.BackColor = Color.Red;
                }
            }
        }
    }
}
