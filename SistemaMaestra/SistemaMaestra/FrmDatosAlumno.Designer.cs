namespace SistemaMaestra
{
    partial class FrmDatosAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDatosAlumno));
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblMatricula = new Label();
            txtMatricula = new TextBox();
            txtApaterno = new TextBox();
            lblApaterno = new Label();
            lblAmaterno = new Label();
            pBoxUacm = new PictureBox();
            txtAmaterno = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)pBoxUacm).BeginInit();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(88, 234);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(82, 25);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(176, 234);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(224, 31);
            txtNombre.TabIndex = 3;
            // 
            // lblMatricula
            // 
            lblMatricula.AutoSize = true;
            lblMatricula.Location = new Point(82, 50);
            lblMatricula.Name = "lblMatricula";
            lblMatricula.Size = new Size(88, 25);
            lblMatricula.TabIndex = 2;
            lblMatricula.Text = "Matricula:";
            // 
            // txtMatricula
            // 
            txtMatricula.Location = new Point(180, 47);
            txtMatricula.Name = "txtMatricula";
            txtMatricula.Size = new Size(179, 31);
            txtMatricula.TabIndex = 0;
            // 
            // txtApaterno
            // 
            txtApaterno.Location = new Point(174, 103);
            txtApaterno.Name = "txtApaterno";
            txtApaterno.Size = new Size(226, 31);
            txtApaterno.TabIndex = 1;
            // 
            // lblApaterno
            // 
            lblApaterno.AutoSize = true;
            lblApaterno.Location = new Point(21, 106);
            lblApaterno.Name = "lblApaterno";
            lblApaterno.Size = new Size(149, 25);
            lblApaterno.TabIndex = 5;
            lblApaterno.Text = "Apellido paterno:";
            // 
            // lblAmaterno
            // 
            lblAmaterno.AutoSize = true;
            lblAmaterno.Location = new Point(12, 167);
            lblAmaterno.Name = "lblAmaterno";
            lblAmaterno.Size = new Size(154, 25);
            lblAmaterno.TabIndex = 6;
            lblAmaterno.Text = "Apellido materno:";
            // 
            // pBoxUacm
            // 
            pBoxUacm.Image = (Image)resources.GetObject("pBoxUacm.Image");
            pBoxUacm.Location = new Point(520, 41);
            pBoxUacm.Name = "pBoxUacm";
            pBoxUacm.Size = new Size(150, 150);
            pBoxUacm.TabIndex = 7;
            pBoxUacm.TabStop = false;
            // 
            // txtAmaterno
            // 
            txtAmaterno.Location = new Point(174, 164);
            txtAmaterno.Name = "txtAmaterno";
            txtAmaterno.Size = new Size(226, 31);
            txtAmaterno.TabIndex = 2;
            // 
            // btnAceptar
            // 
            btnAceptar.Cursor = Cursors.Hand;
            btnAceptar.Location = new Point(63, 336);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(112, 47);
            btnAceptar.TabIndex = 9;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Location = new Point(405, 336);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 47);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmDatosAlumno
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(740, 411);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtAmaterno);
            Controls.Add(pBoxUacm);
            Controls.Add(lblAmaterno);
            Controls.Add(lblApaterno);
            Controls.Add(txtApaterno);
            Controls.Add(txtMatricula);
            Controls.Add(lblMatricula);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmDatosAlumno";
            Text = "Datos Alumno";
            FormClosing += FrmDatosAlumno_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pBoxUacm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblMatricula;
        private TextBox txtMatricula;
        private TextBox txtApaterno;
        private Label lblApaterno;
        private Label lblAmaterno;
        private PictureBox pBoxUacm;
        private TextBox txtAmaterno;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}