using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMaestra
{
    public partial class FrmDatosTarea : Form
    {
        private TareaDao tareaDao;
        private FrmCurso? cursoInterfaz;
        public FrmDatosTarea(FrmCurso cursoInterfaz)
        {

            InitializeComponent();
            tareaDao = new TareaDao();
            this.cursoInterfaz = cursoInterfaz;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (txtTarea.Text != "")
            {
                if(!new TareaDao().ExisteTarea(cursoInterfaz!.curso, txtTarea.Text))
                {
                    tareaDao.AgregarTarea(cursoInterfaz!.curso, txtTarea.Text);
                    this.Close();
                }else
                    MessageBox.Show("¡Tarea ya existente, elige otra!", "Datos existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
                MessageBox.Show("¡Llena el campo del nombre de la tarea!", "Datos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FrmDatosTarea_FormClosing(object sender, FormClosingEventArgs e)
        {
            cursoInterfaz!.curso.ListaAlumnos = new AlumnoDao().ObtenerDatosCurso(cursoInterfaz.curso);
            cursoInterfaz.LlenarTabla(cursoInterfaz.curso.ListaAlumnos);
            cursoInterfaz.actualizarControles();
            cursoInterfaz.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
