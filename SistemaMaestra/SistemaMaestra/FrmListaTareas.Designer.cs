namespace SistemaMaestra
{
    partial class FrmListaTareas
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
            splitContainer1 = new SplitContainer();
            tblTareas = new DataGridView();
            numeroTarea = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            pictureBox1 = new PictureBox();
            btnCancelar = new Button();
            btnAceptar = new Button();
            txtTarea = new TextBox();
            lblTarea = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tblTareas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(tblTareas);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pictureBox1);
            splitContainer1.Panel2.Controls.Add(btnCancelar);
            splitContainer1.Panel2.Controls.Add(btnAceptar);
            splitContainer1.Panel2.Controls.Add(txtTarea);
            splitContainer1.Panel2.Controls.Add(lblTarea);
            splitContainer1.Size = new Size(742, 376);
            splitContainer1.SplitterDistance = 444;
            splitContainer1.TabIndex = 0;
            // 
            // tblTareas
            // 
            tblTareas.AllowUserToAddRows = false;
            tblTareas.AllowUserToDeleteRows = false;
            tblTareas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tblTareas.Columns.AddRange(new DataGridViewColumn[] { numeroTarea, nombre });
            tblTareas.Dock = DockStyle.Fill;
            tblTareas.Location = new Point(0, 0);
            tblTareas.Name = "tblTareas";
            tblTareas.ReadOnly = true;
            tblTareas.RowHeadersWidth = 62;
            tblTareas.Size = new Size(444, 376);
            tblTareas.TabIndex = 0;
            tblTareas.CellClick += tblTareas_CellClick;
            // 
            // numeroTarea
            // 
            numeroTarea.HeaderText = "#Tarea";
            numeroTarea.MinimumWidth = 8;
            numeroTarea.Name = "numeroTarea";
            numeroTarea.ReadOnly = true;
            numeroTarea.Width = 150;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.MinimumWidth = 8;
            nombre.Name = "nombre";
            nombre.ReadOnly = true;
            nombre.Width = 150;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoUACM;
            pictureBox1.Location = new Point(78, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(155, 311);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(13, 311);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(112, 34);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // txtTarea
            // 
            txtTarea.Location = new Point(25, 223);
            txtTarea.Name = "txtTarea";
            txtTarea.Size = new Size(203, 31);
            txtTarea.TabIndex = 1;
            // 
            // lblTarea
            // 
            lblTarea.AutoSize = true;
            lblTarea.Location = new Point(25, 181);
            lblTarea.Name = "lblTarea";
            lblTarea.Size = new Size(56, 25);
            lblTarea.TabIndex = 0;
            lblTarea.Text = "Tarea:";
            // 
            // FrmListaTareas
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(742, 376);
            Controls.Add(splitContainer1);
            Name = "FrmListaTareas";
            Text = "FrmListaTareas";
            FormClosing += FrmListaTareas_FormClosing;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tblTareas).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private DataGridView tblTareas;
        private DataGridViewTextBoxColumn numeroTarea;
        private DataGridViewTextBoxColumn nombre;
        private Label lblTarea;
        private PictureBox pictureBox1;
        private Button btnCancelar;
        private Button btnAceptar;
        private TextBox txtTarea;
    }
}