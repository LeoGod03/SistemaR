namespace SistemaMaestra
{
    partial class FrmDatosTarea
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
            lblTarea = new Label();
            txtTarea = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTarea
            // 
            lblTarea.AutoSize = true;
            lblTarea.Location = new Point(27, 87);
            lblTarea.Name = "lblTarea";
            lblTarea.Size = new Size(169, 25);
            lblTarea.TabIndex = 0;
            lblTarea.Text = "Nombre de la tarea:";
            // 
            // txtTarea
            // 
            txtTarea.Location = new Point(27, 132);
            txtTarea.Name = "txtTarea";
            txtTarea.Size = new Size(322, 31);
            txtTarea.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(35, 229);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(112, 45);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(293, 229);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 45);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.logoUACM;
            pictureBox1.Location = new Point(425, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(150, 150);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // FrmDatosTarea
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(618, 304);
            Controls.Add(pictureBox1);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtTarea);
            Controls.Add(lblTarea);
            Name = "FrmDatosTarea";
            Text = "FrmDatosTarea";
            FormClosing += FrmDatosTarea_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTarea;
        private TextBox txtTarea;
        private Button btnAceptar;
        private Button btnCancelar;
        private PictureBox pictureBox1;
    }
}