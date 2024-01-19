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
    public partial class FrmDatosAlumno : Form
    {
        private Alumno? alumno;
        private FrmCurso cursoInterfaz;
        private String? matriculaAntigua;
        private AlumnoDao alumnoDao;
        private bool editar;
        public FrmDatosAlumno(FrmCurso cursoInterfaz, Alumno alumno)
        {
            InitializeComponent();
            alumnoDao = new AlumnoDao();
            this.alumno = alumno;
            this.cursoInterfaz = cursoInterfaz;
            editar = alumno != null;
            if (editar)
            {
                List<Alumno> list = alumnoDao.BuscarAlumno(cursoInterfaz.curso,new Alumno("",alumno!.Matricula,"",""),"Matricula");
                if (list.Count == 1)
                {
                    this.alumno = list[0];
                    matriculaAntigua = this.alumno.Matricula;
                    txtMatricula.Text = matriculaAntigua;
                    txtNombre.Text = this.alumno.Nombre;
                    txtApaterno.Text = this.alumno.ApellidoP;
                    txtAmaterno.Text = this.alumno.ApellidoM;
                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmDatosAlumno_FormClosing(object sender, FormClosingEventArgs e)
        {
            cursoInterfaz.curso.ListaAlumnos = alumnoDao.ObtenerDatosCurso(cursoInterfaz.curso);
            cursoInterfaz.LlenarTabla(cursoInterfaz.curso.ListaAlumnos);
            cursoInterfaz.actualizarControles();
            cursoInterfaz.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            bool lleno = true;
            TextBox[] datos = {txtMatricula, txtNombre, txtApaterno,txtAmaterno};

            for(int indice = 0;  indice < datos.Length; indice++)
            {
                if (datos[indice].Text == "")
                {
                    lleno = false;
                    break;
                }
            }
            if (lleno)
            {
                if (Alumno.ValidarMatricula(txtMatricula.Text))
                {
                    Alumno alumno = new Alumno(txtMatricula.Text.Trim(), txtNombre.Text.Trim(), txtApaterno.Text.Trim(), txtAmaterno.Text.Trim());
                    if (!editar)
                    {
                        if(!new AlumnoDao().ExisteAlumno(cursoInterfaz.curso,new Alumno(txtMatricula.Text, "", "", "")))
                        {
                            alumnoDao.AgregarAlumno(cursoInterfaz.curso, alumno);
                            this.Close();
                        }  
                        else
                            MessageBox.Show("¡Matricula ya registrada con anterioridad,\nrevisa bien los datos!", "Datos existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    else
                    {
                        if(matriculaAntigua == txtMatricula.Text)
                        {
                            alumnoDao.ModificarAlumno(cursoInterfaz.curso, alumno, matriculaAntigua!);
                            this.Close();
                        }
                        else
                        {
                            if(!new AlumnoDao().ExisteAlumno(cursoInterfaz.curso, new Alumno(txtMatricula.Text, "", "", "")))
                            {
                                alumnoDao.ModificarAlumno(cursoInterfaz.curso, alumno, matriculaAntigua!);
                                this.Close();
                            }else
                                MessageBox.Show("¡Matricula ya registrada con anterioridad,\nrevisa bien los datos!", "Datos existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }
                        

                }else
                    MessageBox.Show("¡Matricula invalida!, revisa por favor", "Datos erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("¡Datos incompletos!, revisa por favor","Datos incompletos",MessageBoxButtons.OK,MessageBoxIcon.Error);
           
        }
    }
}
