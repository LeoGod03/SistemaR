using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMaestra
{
    public partial class FrmDatosCurso : Form
    {
        private FrmMenuPrincipal principal;
        private bool editar = false;
        private Curso? curso;
        public FrmDatosCurso(FrmMenuPrincipal menuPrincipal, Curso curso)
        {
            InitializeComponent();
            editar = curso != null;
            principal = menuPrincipal;

            if (editar)
            {
                this.curso = curso;
                txtNombreCurso.Text = curso!.Nombre;
            }



        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(txtNombreCurso.Text != "")
            {
                if (!editar)
                {
                    if(! new CursoDao().ExisteCurso(new Curso(txtNombreCurso.Text.Trim(),0)))
                    {
                        new CursoDao().AgregarCurso(new Curso(txtNombreCurso.Text.Trim(), 0));
                        this.Close();
                    }
                    else
                        MessageBox.Show("¡Curso ya existente, elige otro!", "Datos existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                {
                    String nombreViejo = curso!.Nombre;
                     curso.Nombre = txtNombreCurso.Text;
                    if (nombreViejo == curso.Nombre)
                    {
                        this.Close();
                    }
                    else
                    {
                        if (!new CursoDao().ExisteCurso(new Curso(txtNombreCurso.Text.Trim(), 0)))
                        {
                            new CursoDao().ActualizarCurso(curso, nombreViejo.Trim());
                            this.Close();
                        }
                        else
                            MessageBox.Show("¡Curso ya existente, elige otro!", "Datos existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
                MessageBox.Show("¡Datos incompletos!, revisa por favor", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void FrmDatosCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            List<Curso> listaCursos = new CursoDao().ObtenerTablaCursos();
            principal.LlenarTabla(listaCursos);
            principal.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
