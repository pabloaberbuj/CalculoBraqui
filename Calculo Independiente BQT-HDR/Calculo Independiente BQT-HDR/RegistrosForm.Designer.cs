namespace Calculo_Independiente_BQT_HDR
{
    partial class RegistrosForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LB_HC = new System.Windows.Forms.ListBox();
            this.DGV_Puntos = new System.Windows.Forms.DataGridView();
            this.BT_VerRegistro = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Label_Nombre = new System.Windows.Forms.Label();
            this.TB_HCFiltro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Puntos)).BeginInit();
            this.SuspendLayout();
            // 
            // LB_HC
            // 
            this.LB_HC.FormattingEnabled = true;
            this.LB_HC.Location = new System.Drawing.Point(23, 64);
            this.LB_HC.Name = "LB_HC";
            this.LB_HC.Size = new System.Drawing.Size(120, 173);
            this.LB_HC.TabIndex = 0;
            // 
            // DGV_Puntos
            // 
            this.DGV_Puntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Puntos.Location = new System.Drawing.Point(203, 31);
            this.DGV_Puntos.Name = "DGV_Puntos";
            this.DGV_Puntos.Size = new System.Drawing.Size(449, 206);
            this.DGV_Puntos.TabIndex = 1;
            // 
            // BT_VerRegistro
            // 
            this.BT_VerRegistro.Location = new System.Drawing.Point(23, 243);
            this.BT_VerRegistro.Name = "BT_VerRegistro";
            this.BT_VerRegistro.Size = new System.Drawing.Size(120, 23);
            this.BT_VerRegistro.TabIndex = 2;
            this.BT_VerRegistro.Text = "Ver Registro";
            this.BT_VerRegistro.UseVisualStyleBackColor = true;
            this.BT_VerRegistro.Click += new System.EventHandler(this.BT_VerRegistro_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "HC";
            // 
            // Label_Nombre
            // 
            this.Label_Nombre.AutoSize = true;
            this.Label_Nombre.Location = new System.Drawing.Point(200, 15);
            this.Label_Nombre.Name = "Label_Nombre";
            this.Label_Nombre.Size = new System.Drawing.Size(50, 13);
            this.Label_Nombre.TabIndex = 4;
            this.Label_Nombre.Text = "Nombre: ";
            // 
            // TB_HCFiltro
            // 
            this.TB_HCFiltro.Location = new System.Drawing.Point(23, 31);
            this.TB_HCFiltro.Name = "TB_HCFiltro";
            this.TB_HCFiltro.Size = new System.Drawing.Size(120, 20);
            this.TB_HCFiltro.TabIndex = 5;
            this.TB_HCFiltro.TextChanged += new System.EventHandler(this.TB_HCFiltro_TextChanged);
            // 
            // RegistrosForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 296);
            this.Controls.Add(this.TB_HCFiltro);
            this.Controls.Add(this.Label_Nombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_VerRegistro);
            this.Controls.Add(this.DGV_Puntos);
            this.Controls.Add(this.LB_HC);
            this.Name = "RegistrosForm";
            this.Text = "Registros";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Puntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LB_HC;
        private System.Windows.Forms.DataGridView DGV_Puntos;
        private System.Windows.Forms.Button BT_VerRegistro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Label_Nombre;
        private System.Windows.Forms.TextBox TB_HCFiltro;
    }
}