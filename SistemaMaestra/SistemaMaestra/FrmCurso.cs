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
    public partial class FrmCurso : Form
    {
        private Curso curso;
        private FrmMenuPrincipal principal;
        private CursoDao cursoDao;
        private List<Alumno> listaAlumnos;
        public FrmCurso(Curso curso,FrmMenuPrincipal principal)
        {
            InitializeComponent();
            cBoxTipoBusqueda.Text = "Matricula";
            cBoxElemento.Text = "Alumno";
            tblAlumnos.Columns.Clear();
            cursoDao = new CursoDao();
            this.curso = curso;
            this.principal = principal;
            lblNombreCurso.Text += " " + curso.Nombre;
            int numeroFila;
            int numeroColumna = 0;
            List<String> nombreColumnas = cursoDao.ObtenerNombresColumnas(curso);

            listaAlumnos = cursoDao.ObtenerDatosCurso(curso);
            tblAlumnos.Columns.Add("matriula", "Matricula");
            tblAlumnos.Columns.Add("nombre", "Nombre");

            while(numeroColumna < nombreColumnas.Count - 5)
            {
                tblAlumnos.Columns.Add(nombreColumnas[numeroColumna + 5], nombreColumnas[numeroColumna + 5].ToUpper());
                numeroColumna++;   
            }

            tblAlumnos.Columns.Add("promedio", "Promedio");
            int numeroTareas;
            foreach (Alumno alumno in listaAlumnos)
            {
                numeroTareas = 0;
                numeroFila = tblAlumnos.Rows.Add();
                tblAlumnos.Rows[numeroFila].Cells[0].Value = alumno.Matricula;
                tblAlumnos.Rows[numeroFila].Cells[1].Value = $"{alumno.Nombre} {alumno.ApellidoP} {alumno.ApellidoM}";
                while(alumno.Tareas.Count < numeroTareas)
                {
                    tblAlumnos.Rows[numeroFila].Cells[numeroTareas + 2].Value = alumno.Tareas[numeroTareas];
                }
                alumno.CalcularPromedio();
                tblAlumnos.Rows[numeroFila].Cells[nombreColumnas.Count - 1].Value = alumno.Promedio;


            }
        }

        private void FrmCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            principal.Show();
        }
    }
}
