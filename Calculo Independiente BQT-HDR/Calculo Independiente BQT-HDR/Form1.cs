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
        Plan plan = new Plan();
        TablaHyT tabla = new TablaHyT();
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
                tabla.cargarValores();
                Calcular.calcularTodo(fid, plan, tabla);
                cargarDatosPaciente(fid, plan);
                DGV_Aplicadores.DataSource = plan.aplicadores;
                CHB_Aplicadores.Enabled = true;
                DGV_Puntos.DataSource = Calcular.todosLosPuntos(plan);
                CHB_DosisEnPuntos.Enabled = true;
                chequearTolerancia(DGV_Puntos, 3, 3);
            }
        }

        private void cargarLabel(Label label, string valor,CheckBox chb)
        {
            if (valor != "")
            {
                label.Text = valor;
                label.Visible = true;
                chb.Enabled = true;

            }
            else
            {
                label.Text = "";
                label.Visible = false;
                chb.Enabled = false;
            }
        }

        private void cargarDatosPaciente(string[] fid, Plan plan)
        {
            cargarLabel(L_Nombre,plan.nombre,CHB_Nombre);
            cargarLabel(L_ID, plan.ID,CHB_ID);
            cargarLabel(L_Prescripcion, plan.prescripcion.ToString()+" cGy",CHB_DosisPrescripta);
            chequeoPrescripcion(fid, plan);
        }

        private void chequeoPrescripcion(string[] fid, Plan plan)
        {
            string escribir = Calcular.calcularPrescripcion(plan).ToString() + " cGy (en" + plan.lineas[plan.lineas.Count() - 1].nombre + ")";
            cargarLabel(L_DosisPuntosA, escribir,CHB_DosisPrescripta);
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

        private void chequeos(Object sender, EventArgs e)
        {
            if (CHB_Nombre.Checked && CHB_ID.Checked && CHB_DosisPrescripta.Checked && CHB_Aplicadores.Checked && CHB_DosisEnPuntos.Checked)
            {
                BT_Guardar.Enabled = true;
            }
            else
            {
                BT_Guardar.Enabled = false;
            }
        }

        private void BT_Guardar_Click(object sender, EventArgs e)
        {
            try
            {
                Registro.guardarPlan(plan, Calcular.todosLosPuntos(plan));
                MessageBox.Show("Se ha guardado correctamente");
            }
            catch (Exception f)
            {
                MessageBox.Show("No se ha podido guardar\n" + f.ToString());
                throw;
            }
            
        }
    }
}
