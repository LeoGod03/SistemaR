namespace SistemaMaestra
{
    partial class FrmMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenuPrincipal));
            btnModificarCurso = new Button();
            btnEliminarCurso = new Button();
            btnCrearCurso = new Button();
            tblCursos = new DataGridView();
            cursos = new DataGridViewTextBoxColumn();
            alumnos = new DataGridViewTextBoxColumn();
            tareas = new DataGridViewTextBoxColumn();
            splitContainer1 = new SplitContainer();
            txtBusqueda = new TextBox();
            lblBusqueda = new Label();
            ((System.ComponentModel.ISupportInitialize)tblCursos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // btnModificarCurso
            // 
            btnModificarCurso.Cursor = Cursors.Hand;
            btnModificarCurso.Location = new Point(100, 320);
            btnModificarCurso.Name = "btnModificarCurso";
            btnModificarCurso.Size = new Size(171, 47);
            btnModificarCurso.TabIndex = 4;
            btnModificarCurso.Text = "Modificar curso";
            btnModificarCurso.UseVisualStyleBackColor = true;
            btnModificarCurso.MouseClick += btnModificarCurso_MouseClick;
            // 
            // btnEliminarCurso
            // 
            btnEliminarCurso.Cursor = Cursors.Hand;
            btnEliminarCurso.Location = new Point(100, 408);
            btnEliminarCurso.Name = "btnEliminarCurso";
            btnEliminarCurso.Size = new Size(171, 47);
            btnEliminarCurso.TabIndex = 3;
            btnEliminarCurso.Text = "Eliminar curso";
            btnEliminarCurso.UseVisualStyleBackColor = true;
            btnEliminarCurso.MouseClick += btnEliminarCurso_MouseClick;
            // 
            // btnCrearCurso
            // 
            btnCrearCurso.Cursor = Cursors.Hand;
            btnCrearCurso.Location = new Point(100, 229);
            btnCrearCurso.Name = "btnCrearCurso";
            btnCrearCurso.Size = new Size(171, 47);
            btnCrearCurso.TabIndex = 2;
            btnCrearCurso.Text = "Crear curso";
            btnCrearCurso.UseVisualStyleBackColor = true;
            btnCrearCurso.Click += btnCrearCurso_Click;
            // 
            // tblCursos
            // 
            tblCursos.AllowUserToAddRows = false;
            tblCursos.AllowUserToDeleteRows = false;
            tblCursos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            tblCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblCursos.Columns.AddRange(new DataGridViewColumn[] { cursos, alumnos, tareas });
            tblCursos.Dock = DockStyle.Fill;
            tblCursos.Location = new Point(0, 0);
            tblCursos.Name = "tblCursos";
            tblCursos.RowHeadersWidth = 62;
            tblCursos.Size = new Size(835, 664);
            tblCursos.TabIndex = 0;
            tblCursos.CellDoubleClick += tblCursos_CellDoubleClick;
            // 
            // cursos
            // 
            cursos.HeaderText = "Nombre del curso";
            cursos.MinimumWidth = 8;
            cursos.Name = "cursos";
            cursos.ReadOnly = true;
            cursos.Width = 150;
            // 
            // alumnos
            // 
            alumnos.HeaderText = "#Alumnos";
            alumnos.MinimumWidth = 8;
            alumnos.Name = "alumnos";
            alumnos.ReadOnly = true;
            alumnos.Width = 150;
            // 
            // tareas
            // 
            tareas.HeaderText = "#Tareas";
            tareas.MinimumWidth = 8;
            tareas.Name = "tareas";
            tareas.Width = 150;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AutoScroll = true;
            splitContainer1.Panel1.Controls.Add(lblBusqueda);
            splitContainer1.Panel1.Controls.Add(txtBusqueda);
            splitContainer1.Panel1.Controls.Add(btnCrearCurso);
            splitContainer1.Panel1.Controls.Add(btnEliminarCurso);
            splitContainer1.Panel1.Controls.Add(btnModificarCurso);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tblCursos);
            splitContainer1.Size = new Size(1258, 664);
            splitContainer1.SplitterDistance = 419;
            splitContainer1.TabIndex = 5;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(100, 38);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(222, 31);
            txtBusqueda.TabIndex = 5;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            // 
            // lblBusqueda
            // 
            lblBusqueda.AutoSize = true;
            lblBusqueda.Location = new Point(29, 38);
            lblBusqueda.Name = "lblBusqueda";
            lblBusqueda.Size = new Size(67, 25);
            lblBusqueda.TabIndex = 6;
            lblBusqueda.Text = "Buscar:";
            // 
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.Disable;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1258, 664);
            Controls.Add(splitContainer1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMenuPrincipal";
            Text = "Sistema";
            ((System.ComponentModel.ISupportInitialize)tblCursos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button btnCrearCurso;
        private Button btnEliminarCurso;
        private Button btnModificarCurso;
        private DataGridView tblCursos;
        private SplitContainer splitContainer1;
        private TextBox txtBusqueda;
        private DataGridViewTextBoxColumn cursos;
        private DataGridViewTextBoxColumn alumnos;
        private DataGridViewTextBoxColumn tareas;
        private Label lblBusqueda;
    }
}
