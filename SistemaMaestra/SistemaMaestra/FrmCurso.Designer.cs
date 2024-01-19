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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCurso));
            txtBusqueda = new TextBox();
            lblBusquedaTexto = new Label();
            cBoxTipoBusqueda = new ComboBox();
            tblAlumnos = new DataGridView();
            splitContainer1 = new SplitContainer();
            lblAlumnos = new Label();
            btnPdf = new Button();
            cBoxCertificados = new ComboBox();
            lblTareas = new Label();
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
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(368, 31);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(490, 31);
            txtBusqueda.TabIndex = 0;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
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
            cBoxTipoBusqueda.Items.AddRange(new object[] { "Matricula", "Nombre" });
            cBoxTipoBusqueda.Location = new Point(167, 29);
            cBoxTipoBusqueda.Name = "cBoxTipoBusqueda";
            cBoxTipoBusqueda.Size = new Size(182, 33);
            cBoxTipoBusqueda.TabIndex = 2;
            // 
            // tblAlumnos
            // 
            tblAlumnos.AllowUserToAddRows = false;
            tblAlumnos.AllowUserToDeleteRows = false;
            tblAlumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblAlumnos.Dock = DockStyle.Fill;
            tblAlumnos.Location = new Point(0, 0);
            tblAlumnos.Name = "tblAlumnos";
            tblAlumnos.RowHeadersWidth = 62;
            tblAlumnos.Size = new Size(1258, 489);
            tblAlumnos.TabIndex = 4;
            tblAlumnos.CellBeginEdit += tblAlumnos_CellBeginEdit;
            tblAlumnos.CellClick += tblAlumnos_CellClick;
            tblAlumnos.CellEndEdit += tblAlumnos_CellEndEdit;
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
            splitContainer1.Panel1.Controls.Add(lblAlumnos);
            splitContainer1.Panel1.Controls.Add(btnPdf);
            splitContainer1.Panel1.Controls.Add(cBoxCertificados);
            splitContainer1.Panel1.Controls.Add(lblTareas);
            splitContainer1.Panel1.Controls.Add(btnEliminar);
            splitContainer1.Panel1.Controls.Add(btnModificar);
            splitContainer1.Panel1.Controls.Add(btnAgregar);
            splitContainer1.Panel1.Controls.Add(cBoxElemento);
            splitContainer1.Panel1.Controls.Add(lblNombreCurso);
            splitContainer1.Panel1.Controls.Add(lblBusquedaTexto);
            splitContainer1.Panel1.Controls.Add(txtBusqueda);
            splitContainer1.Panel1.Controls.Add(cBoxTipoBusqueda);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tblAlumnos);
            splitContainer1.Size = new Size(1258, 664);
            splitContainer1.SplitterDistance = 171;
            splitContainer1.TabIndex = 5;
            // 
            // lblAlumnos
            // 
            lblAlumnos.AutoSize = true;
            lblAlumnos.Location = new Point(21, 134);
            lblAlumnos.Name = "lblAlumnos";
            lblAlumnos.Size = new Size(83, 25);
            lblAlumnos.TabIndex = 12;
            lblAlumnos.Text = "Alumnos";
            // 
            // btnPdf
            // 
            btnPdf.Location = new Point(1118, 29);
            btnPdf.Name = "btnPdf";
            btnPdf.Size = new Size(74, 34);
            btnPdf.TabIndex = 11;
            btnPdf.Text = "PDF";
            btnPdf.UseVisualStyleBackColor = true;
            btnPdf.Click += btnPdf_Click;
            // 
            // cBoxCertificados
            // 
            cBoxCertificados.FormattingEnabled = true;
            cBoxCertificados.Items.AddRange(new object[] { "Todos", "Aprobados", "No aprobados" });
            cBoxCertificados.Location = new Point(1046, 114);
            cBoxCertificados.Name = "cBoxCertificados";
            cBoxCertificados.Size = new Size(182, 33);
            cBoxCertificados.TabIndex = 10;
            cBoxCertificados.SelectedValueChanged += cBoxCertificados_SelectedValueChanged;
            // 
            // lblTareas
            // 
            lblTareas.AutoSize = true;
            lblTareas.Location = new Point(928, 37);
            lblTareas.Name = "lblTareas";
            lblTareas.Size = new Size(64, 25);
            lblTareas.TabIndex = 9;
            lblTareas.Text = "Tareas:";
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Location = new Point(880, 110);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 37);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Cursor = Cursors.Hand;
            btnModificar.Location = new Point(727, 109);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(112, 37);
            btnModificar.TabIndex = 7;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Cursor = Cursors.Hand;
            btnAgregar.Location = new Point(575, 109);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(112, 37);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // cBoxElemento
            // 
            cBoxElemento.FormattingEnabled = true;
            cBoxElemento.Items.AddRange(new object[] { "Alumno", "Tarea" });
            cBoxElemento.Location = new Point(368, 113);
            cBoxElemento.Name = "cBoxElemento";
            cBoxElemento.Size = new Size(182, 33);
            cBoxElemento.TabIndex = 5;
            cBoxElemento.SelectedValueChanged += cBoxElemento_SelectedValueChanged;
            // 
            // lblNombreCurso
            // 
            lblNombreCurso.AutoSize = true;
            lblNombreCurso.Location = new Point(21, 95);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmCurso";
            Text = "Datos del curso";
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

        private TextBox txtBusqueda;
        private Label lblBusquedaTexto;
        private ComboBox cBoxTipoBusqueda;
        private DataGridView tblAlumnos;
        private SplitContainer splitContainer1;
        private Label lblNombreCurso;
        private ComboBox cBoxElemento;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnModificar;
        private Label lblTareas;
        private ComboBox cBoxCertificados;
        private Button btnPdf;
        private Label lblAlumnos;
    }
}