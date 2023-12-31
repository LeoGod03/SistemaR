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
        private Curso curso;
        public FrmDatosCurso(FrmMenuPrincipal menuPrincipal, Curso curso)
        {
            InitializeComponent();
            editar = curso != null;
            principal = menuPrincipal;

            if (editar)
            {
                this.curso = curso;
                txtNombreCurso.Text = curso.Nombre;
            }



        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Curso cursoNuevo;
            if (!editar)
            {
                cursoNuevo = new Curso(txtNombreCurso.Text, 0);
                principal.AgregarCursoTabla(cursoNuevo);
            }
            else
            {
                String nombreViejo = curso.Nombre;
                curso.Nombre = txtNombreCurso.Text;
                new CursoDao().ActualizarCurso(curso, nombreViejo);
            }
            List<Curso> listaCursos = new CursoDao().ObtenerTablaCursos();
            principal.LlenarTabla(listaCursos);
            principal.Show();
            this.Close();
        }

        private void FrmDatosCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            principal.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
