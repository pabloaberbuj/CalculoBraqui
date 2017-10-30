using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calculo_Independiente_BQT_HDR
{
    public partial class RegistrosForm : Form
    {
        public RegistrosForm()
        {
            InitializeComponent();
            cargarLista();
        }

        public void cargarLista()
        {
            LB_HC.DataSource = Registro.lista();
            LB_HC.DisplayMember = "ID";
        }

        public void cargarPuntos(Registro registro)
        {
            Label_Nombre.Text = "Nombre: " + registro.nombre;
            DGV_Puntos.DataSource = registro.Puntos;
        }

        private void BT_VerRegistro_Click(object sender, EventArgs e)
        {
            cargarPuntos((Registro)LB_HC.SelectedItem);
        }

        public void filtrarLista()
        {
            
            LB_HC.DataSource = Registro.lista().Where(r => r.ID.Contains(TB_HCFiltro.Text)).ToList() ;
        }

        private void TB_HCFiltro_TextChanged(object sender, EventArgs e)
        {
            filtrarLista();
        }
    }
}
