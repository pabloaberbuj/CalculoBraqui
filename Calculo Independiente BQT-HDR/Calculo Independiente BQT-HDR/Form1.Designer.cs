namespace Calculo_Independiente_BQT_HDR
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_Cargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.L_Prescripcion = new System.Windows.Forms.Label();
            this.L_ID = new System.Windows.Forms.Label();
            this.L_Nombre = new System.Windows.Forms.Label();
            this.DGV_Aplicadores = new System.Windows.Forms.DataGridView();
            this.DGV_Puntos = new System.Windows.Forms.DataGridView();
            this.L_DosisPuntosA = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CHB_Nombre = new System.Windows.Forms.CheckBox();
            this.CHB_ID = new System.Windows.Forms.CheckBox();
            this.CHB_DosisPrescripta = new System.Windows.Forms.CheckBox();
            this.CHB_Aplicadores = new System.Windows.Forms.CheckBox();
            this.CHB_DosisEnPuntos = new System.Windows.Forms.CheckBox();
            this.BT_Guardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Aplicadores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Puntos)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_Cargar
            // 
            this.BT_Cargar.Location = new System.Drawing.Point(21, 12);
            this.BT_Cargar.Name = "BT_Cargar";
            this.BT_Cargar.Size = new System.Drawing.Size(92, 33);
            this.BT_Cargar.TabIndex = 0;
            this.BT_Cargar.Text = "Cargar";
            this.BT_Cargar.UseVisualStyleBackColor = true;
            this.BT_Cargar.Click += new System.EventHandler(this.BT_CargarClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "HC";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Prescripción";
            // 
            // L_Prescripcion
            // 
            this.L_Prescripcion.AutoSize = true;
            this.L_Prescripcion.Cursor = System.Windows.Forms.Cursors.Default;
            this.L_Prescripcion.Location = new System.Drawing.Point(137, 130);
            this.L_Prescripcion.Name = "L_Prescripcion";
            this.L_Prescripcion.Size = new System.Drawing.Size(35, 13);
            this.L_Prescripcion.TabIndex = 6;
            this.L_Prescripcion.Text = "label4";
            this.L_Prescripcion.Visible = false;
            // 
            // L_ID
            // 
            this.L_ID.AutoSize = true;
            this.L_ID.Cursor = System.Windows.Forms.Cursors.Default;
            this.L_ID.Location = new System.Drawing.Point(137, 93);
            this.L_ID.Name = "L_ID";
            this.L_ID.Size = new System.Drawing.Size(35, 13);
            this.L_ID.TabIndex = 5;
            this.L_ID.Text = "label5";
            this.L_ID.Visible = false;
            // 
            // L_Nombre
            // 
            this.L_Nombre.AutoSize = true;
            this.L_Nombre.Cursor = System.Windows.Forms.Cursors.Default;
            this.L_Nombre.Location = new System.Drawing.Point(137, 60);
            this.L_Nombre.Name = "L_Nombre";
            this.L_Nombre.Size = new System.Drawing.Size(35, 13);
            this.L_Nombre.TabIndex = 4;
            this.L_Nombre.Text = "label6";
            this.L_Nombre.Visible = false;
            // 
            // DGV_Aplicadores
            // 
            this.DGV_Aplicadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Aplicadores.Location = new System.Drawing.Point(21, 229);
            this.DGV_Aplicadores.Name = "DGV_Aplicadores";
            this.DGV_Aplicadores.ReadOnly = true;
            this.DGV_Aplicadores.Size = new System.Drawing.Size(316, 189);
            this.DGV_Aplicadores.TabIndex = 7;
            // 
            // DGV_Puntos
            // 
            this.DGV_Puntos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Puntos.Location = new System.Drawing.Point(381, 229);
            this.DGV_Puntos.Name = "DGV_Puntos";
            this.DGV_Puntos.ReadOnly = true;
            this.DGV_Puntos.Size = new System.Drawing.Size(446, 189);
            this.DGV_Puntos.TabIndex = 8;
            // 
            // L_DosisPuntosA
            // 
            this.L_DosisPuntosA.AutoSize = true;
            this.L_DosisPuntosA.Cursor = System.Windows.Forms.Cursors.Default;
            this.L_DosisPuntosA.Location = new System.Drawing.Point(137, 169);
            this.L_DosisPuntosA.Name = "L_DosisPuntosA";
            this.L_DosisPuntosA.Size = new System.Drawing.Size(35, 13);
            this.L_DosisPuntosA.TabIndex = 10;
            this.L_DosisPuntosA.Text = "label4";
            this.L_DosisPuntosA.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "Dosis promedio en\r\nlinea de prescripción: ";
            // 
            // CHB_Nombre
            // 
            this.CHB_Nombre.AutoSize = true;
            this.CHB_Nombre.Enabled = false;
            this.CHB_Nombre.Location = new System.Drawing.Point(342, 60);
            this.CHB_Nombre.Name = "CHB_Nombre";
            this.CHB_Nombre.Size = new System.Drawing.Size(187, 17);
            this.CHB_Nombre.TabIndex = 12;
            this.CHB_Nombre.Text = "El nombre coincide con la carpeta";
            this.CHB_Nombre.UseVisualStyleBackColor = true;
            this.CHB_Nombre.CheckedChanged += new System.EventHandler(this.chequeos);
            // 
            // CHB_ID
            // 
            this.CHB_ID.AutoSize = true;
            this.CHB_ID.Enabled = false;
            this.CHB_ID.Location = new System.Drawing.Point(342, 93);
            this.CHB_ID.Name = "CHB_ID";
            this.CHB_ID.Size = new System.Drawing.Size(170, 17);
            this.CHB_ID.TabIndex = 13;
            this.CHB_ID.Text = "La HC coincide con la carpeta";
            this.CHB_ID.UseVisualStyleBackColor = true;
            this.CHB_ID.CheckedChanged += new System.EventHandler(this.chequeos);
            // 
            // CHB_DosisPrescripta
            // 
            this.CHB_DosisPrescripta.AutoSize = true;
            this.CHB_DosisPrescripta.Enabled = false;
            this.CHB_DosisPrescripta.Location = new System.Drawing.Point(342, 139);
            this.CHB_DosisPrescripta.Name = "CHB_DosisPrescripta";
            this.CHB_DosisPrescripta.Size = new System.Drawing.Size(237, 43);
            this.CHB_DosisPrescripta.TabIndex = 14;
            this.CHB_DosisPrescripta.Text = "La dosis prescripta coincide con la\r\ndosis promedio en los puntos de prescripción" +
    "\r\ny con la carpeta";
            this.CHB_DosisPrescripta.UseVisualStyleBackColor = true;
            this.CHB_DosisPrescripta.CheckedChanged += new System.EventHandler(this.chequeos);
            // 
            // CHB_Aplicadores
            // 
            this.CHB_Aplicadores.AutoSize = true;
            this.CHB_Aplicadores.Enabled = false;
            this.CHB_Aplicadores.Location = new System.Drawing.Point(21, 430);
            this.CHB_Aplicadores.Name = "CHB_Aplicadores";
            this.CHB_Aplicadores.Size = new System.Drawing.Size(314, 17);
            this.CHB_Aplicadores.TabIndex = 15;
            this.CHB_Aplicadores.Text = "El número de aplicadores y paradas por aplicador es correcta";
            this.CHB_Aplicadores.UseVisualStyleBackColor = true;
            this.CHB_Aplicadores.CheckedChanged += new System.EventHandler(this.chequeos);
            // 
            // CHB_DosisEnPuntos
            // 
            this.CHB_DosisEnPuntos.AutoSize = true;
            this.CHB_DosisEnPuntos.Enabled = false;
            this.CHB_DosisEnPuntos.Location = new System.Drawing.Point(381, 430);
            this.CHB_DosisEnPuntos.Name = "CHB_DosisEnPuntos";
            this.CHB_DosisEnPuntos.Size = new System.Drawing.Size(420, 17);
            this.CHB_DosisEnPuntos.TabIndex = 16;
            this.CHB_DosisEnPuntos.Text = "La diferencia de dosis entre planificación y cálculo independiente está en tolera" +
    "ncia";
            this.CHB_DosisEnPuntos.UseVisualStyleBackColor = true;
            this.CHB_DosisEnPuntos.CheckedChanged += new System.EventHandler(this.chequeos);
            // 
            // BT_Guardar
            // 
            this.BT_Guardar.Enabled = false;
            this.BT_Guardar.Location = new System.Drawing.Point(729, 466);
            this.BT_Guardar.Name = "BT_Guardar";
            this.BT_Guardar.Size = new System.Drawing.Size(95, 44);
            this.BT_Guardar.TabIndex = 18;
            this.BT_Guardar.Text = "Aceptar y guardar";
            this.BT_Guardar.UseVisualStyleBackColor = true;
            this.BT_Guardar.Click += new System.EventHandler(this.BT_Guardar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 514);
            this.Controls.Add(this.BT_Guardar);
            this.Controls.Add(this.CHB_DosisEnPuntos);
            this.Controls.Add(this.CHB_Aplicadores);
            this.Controls.Add(this.CHB_DosisPrescripta);
            this.Controls.Add(this.CHB_ID);
            this.Controls.Add(this.CHB_Nombre);
            this.Controls.Add(this.L_DosisPuntosA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DGV_Puntos);
            this.Controls.Add(this.DGV_Aplicadores);
            this.Controls.Add(this.L_Prescripcion);
            this.Controls.Add(this.L_ID);
            this.Controls.Add(this.L_Nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BT_Cargar);
            this.Name = "Form1";
            this.Text = "Cálculo independiente BQT-HDR";
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Aplicadores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Puntos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Cargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label L_Prescripcion;
        private System.Windows.Forms.Label L_ID;
        private System.Windows.Forms.Label L_Nombre;
        private System.Windows.Forms.DataGridView DGV_Aplicadores;
        private System.Windows.Forms.DataGridView DGV_Puntos;
        private System.Windows.Forms.Label L_DosisPuntosA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox CHB_Nombre;
        private System.Windows.Forms.CheckBox CHB_ID;
        private System.Windows.Forms.CheckBox CHB_DosisPrescripta;
        private System.Windows.Forms.CheckBox CHB_Aplicadores;
        private System.Windows.Forms.CheckBox CHB_DosisEnPuntos;
        private System.Windows.Forms.Button BT_Guardar;
    }
}

