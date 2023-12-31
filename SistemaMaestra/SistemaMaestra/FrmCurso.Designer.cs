namespace SistemaMaestra
{
    partial class FrmCurso
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
            textBox1 = new TextBox();
            lblBusquedaTexto = new Label();
            cBoxTipoBusqueda = new ComboBox();
            btnBusvar = new Button();
            tblAlumnos = new DataGridView();
            splitContainer1 = new SplitContainer();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            cBoxElemento = new ComboBox();
            lblNombreCurso = new Label();
            ((System.ComponentModel.ISupportInitialize)tblAlumnos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(368, 31);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(490, 31);
            textBox1.TabIndex = 0;
            // 
            // lblBusquedaTexto
            // 
            lblBusquedaTexto.AutoSize = true;
            lblBusquedaTexto.Location = new Point(21, 32);
            lblBusquedaTexto.Name = "lblBusquedaTexto";
            lblBusquedaTexto.Size = new Size(127, 25);
            lblBusquedaTexto.TabIndex = 1;
            lblBusquedaTexto.Text = "Busqueda por:";
            // 
            // cBoxTipoBusqueda
            // 
            cBoxTipoBusqueda.Cursor = Cursors.Hand;
            cBoxTipoBusqueda.FormattingEnabled = true;
            cBoxTipoBusqueda.Items.AddRange(new object[] { "Matricula", "Nombre", "Calificacion" });
            cBoxTipoBusqueda.Location = new Point(167, 29);
            cBoxTipoBusqueda.Name = "cBoxTipoBusqueda";
            cBoxTipoBusqueda.Size = new Size(182, 33);
            cBoxTipoBusqueda.TabIndex = 2;
            // 
            // btnBusvar
            // 
            btnBusvar.Location = new Point(876, 30);
            btnBusvar.Name = "btnBusvar";
            btnBusvar.Size = new Size(112, 34);
            btnBusvar.TabIndex = 3;
            btnBusvar.Text = "Buscar";
            btnBusvar.UseVisualStyleBackColor = true;
            // 
            // tblAlumnos
            // 
            tblAlumnos.AllowUserToAddRows = false;
            tblAlumnos.AllowUserToDeleteRows = false;
            tblAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblAlumnos.Dock = DockStyle.Fill;
            tblAlumnos.Location = new Point(0, 0);
            tblAlumnos.Name = "tblAlumnos";
            tblAlumnos.ReadOnly = true;
            tblAlumnos.RowHeadersWidth = 62;
            tblAlumnos.Size = new Size(1258, 489);
            tblAlumnos.TabIndex = 4;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnEliminar);
            splitContainer1.Panel1.Controls.Add(btnModificar);
            splitContainer1.Panel1.Controls.Add(btnAgregar);
            splitContainer1.Panel1.Controls.Add(cBoxElemento);
            splitContainer1.Panel1.Controls.Add(lblNombreCurso);
            splitContainer1.Panel1.Controls.Add(lblBusquedaTexto);
            splitContainer1.Panel1.Controls.Add(btnBusvar);
            splitContainer1.Panel1.Controls.Add(textBox1);
            splitContainer1.Panel1.Controls.Add(cBoxTipoBusqueda);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tblAlumnos);
            splitContainer1.Size = new Size(1258, 664);
            splitContainer1.SplitterDistance = 171;
            splitContainer1.TabIndex = 5;
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Location = new Point(1007, 110);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 37);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.Location = new Point(854, 109);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(112, 37);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.Location = new Point(702, 109);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 37);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // cBoxElemento
            // 
            cBoxElemento.FormattingEnabled = true;
            cBoxElemento.Items.AddRange(new object[] { "Alumno", "Tarea" });
            cBoxElemento.Location = new Point(495, 113);
            cBoxElemento.Name = "cBoxElemento";
            cBoxElemento.Size = new Size(182, 33);
            cBoxElemento.TabIndex = 5;
            // 
            // lblNombreCurso
            // 
            lblNombreCurso.AutoSize = true;
            lblNombreCurso.Location = new Point(10, 121);
            lblNombreCurso.Name = "lblNombreCurso";
            lblNombreCurso.Size = new Size(62, 25);
            lblNombreCurso.TabIndex = 4;
            lblNombreCurso.Text = "Curso:";
            // 
            // FrmCurso
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1258, 664);
            Controls.Add(splitContainer1);
            Name = "FrmCurso";
            Text = "FrmCurso";
            FormClosing += FrmCurso_FormClosing;
            ((System.ComponentModel.ISupportInitialize)tblAlumnos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TextBox textBox1;
        private Label lblBusquedaTexto;
        private ComboBox cBoxTipoBusqueda;
        private Button btnBusvar;
        private DataGridView tblAlumnos;
        private SplitContainer splitContainer1;
        private Label lblNombreCurso;
        private ComboBox cBoxElemento;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
    }
}