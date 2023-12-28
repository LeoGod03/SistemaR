namespace SistemaMaestra
{
    partial class FrmDatosCurso
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
            lblNombreCurso = new Label();
            txtNombreCurso = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // lblNombreCurso
            // 
            lblNombreCurso.AutoSize = true;
            lblNombreCurso.Location = new Point(19, 29);
            lblNombreCurso.Name = "lblNombreCurso";
            lblNombreCurso.Size = new Size(159, 25);
            lblNombreCurso.TabIndex = 0;
            lblNombreCurso.Text = "Nombre del curso:";
            // 
            // txtNombreCurso
            // 
            txtNombreCurso.Location = new Point(24, 74);
            txtNombreCurso.Name = "txtNombreCurso";
            txtNombreCurso.Size = new Size(379, 31);
            txtNombreCurso.TabIndex = 1;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(28, 163);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(112, 34);
            btnAceptar.TabIndex = 2;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(282, 163);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 34);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmDatosCurso
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 254);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtNombreCurso);
            Controls.Add(lblNombreCurso);
            Name = "FrmDatosCurso";
            Text = "FrmDatosCurso";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombreCurso;
        private TextBox txtNombreCurso;
        private Button btnAceptar;
        private Button btnCancelar;
    }
}