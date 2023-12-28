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
            splitContainer1 = new SplitContainer();
            btnModificarCurso = new Button();
            btnEliminarCurso = new Button();
            btnCrearCurso = new Button();
            tblCursos = new DataGridView();
            cursos = new DataGridViewTextBoxColumn();
            alumnos = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblCursos).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 12);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.AllowDrop = true;
            splitContainer1.Panel1.Controls.Add(btnModificarCurso);
            splitContainer1.Panel1.Controls.Add(btnEliminarCurso);
            splitContainer1.Panel1.Controls.Add(btnCrearCurso);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tblCursos);
            splitContainer1.Size = new Size(1027, 574);
            splitContainer1.SplitterDistance = 342;
            splitContainer1.TabIndex = 1;
            // 
            // btnModificarCurso
            // 
            btnModificarCurso.Location = new Point(67, 256);
            btnModificarCurso.Name = "btnModificarCurso";
            btnModificarCurso.Size = new Size(171, 47);
            btnModificarCurso.TabIndex = 4;
            btnModificarCurso.Text = "Modificar curso";
            btnModificarCurso.UseVisualStyleBackColor = true;
            // 
            // btnEliminarCurso
            // 
            btnEliminarCurso.Location = new Point(67, 350);
            btnEliminarCurso.Name = "btnEliminarCurso";
            btnEliminarCurso.Size = new Size(171, 47);
            btnEliminarCurso.TabIndex = 3;
            btnEliminarCurso.Text = "Eliminar curso";
            btnEliminarCurso.UseVisualStyleBackColor = true;
            // 
            // btnCrearCurso
            // 
            btnCrearCurso.Location = new Point(67, 170);
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
            tblCursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblCursos.Columns.AddRange(new DataGridViewColumn[] { cursos, alumnos });
            tblCursos.Dock = DockStyle.Fill;
            tblCursos.Location = new Point(0, 0);
            tblCursos.Name = "tblCursos";
            tblCursos.ReadOnly = true;
            tblCursos.RowHeadersWidth = 62;
            tblCursos.Size = new Size(681, 574);
            tblCursos.TabIndex = 0;
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
            // FrmMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1051, 610);
            Controls.Add(splitContainer1);
            Name = "FrmMenuPrincipal";
            Text = "Sistema";
            Load += Form1_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblCursos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private SplitContainer splitContainer1;
        private Button btnCrearCurso;
        private Button btnEliminarCurso;
        private Button btnModificarCurso;
        private DataGridView tblCursos;
        private DataGridViewTextBoxColumn cursos;
        private DataGridViewTextBoxColumn alumnos;
    }
}
