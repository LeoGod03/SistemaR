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
        public FrmDatosCurso(FrmMenuPrincipal menuPrincipal)
        {
            InitializeComponent();
            principal = menuPrincipal;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso(txtNombreCurso.Text);
            principal.AgregarCursoTabla(curso);
            principal.Visible = true;
            Hide();

        }
    }
}
