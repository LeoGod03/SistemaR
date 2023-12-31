﻿using System;
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
        public Curso curso;
        private FrmMenuPrincipal principal;
        private CursoDao cursoDao;
        private AlumnoDao alumnoDao;
        private int numeroTareas;
        private List<String> nombreColumnas;
        private float valorAntiguo = 0.0f;
        private int columna = -1;
        private const int PRINCIPALES = 2;
        public FrmCurso(Curso curso, FrmMenuPrincipal principal)
        {
            InitializeComponent();
            cursoDao = new CursoDao();
            alumnoDao = new AlumnoDao();
            nombreColumnas = new List<string>();
            cBoxTipoBusqueda.Text = "Matricula";
            cBoxElemento.Text = "Alumno";
            this.curso = curso;
            this.principal = principal;

            lblNombreCurso.Text += " " + curso.Nombre;
            curso.ListaAlumnos = alumnoDao.ObtenerDatosCurso(curso);

            btnModificar.Enabled = curso.ListaAlumnos.Count > 0;
            btnEliminar.Enabled = curso.ListaAlumnos.Count > 0;

            LlenarTabla(curso.ListaAlumnos);
        }


        public void LlenarTabla(List<Alumno> lista)
        {
            nombreColumnas = cursoDao.ObtenerNombresColumnas(curso);
            tblAlumnos.Columns.Clear();
            tblAlumnos.Columns.Add("matricula", "Matricula");
            tblAlumnos.Columns.Add("nombre", "Nombre");

            int numeroColumnas = 5;

            while (numeroColumnas < nombreColumnas.Count)
            {
                DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
                columna.Name =  nombreColumnas[numeroColumnas];
                columna.HeaderText = Texto.NombreColumnasDBD(nombreColumnas[numeroColumnas]);
                columna.ValueType = typeof(String); 


                tblAlumnos.Columns.Add(columna);
                numeroColumnas++;
            }




            tblAlumnos.Columns.Add("promedio", "Promedio");


            tblAlumnos.Columns["matricula"].ReadOnly = true;
            tblAlumnos.Columns["nombre"].ReadOnly = true;
            tblAlumnos.Columns["promedio"].ReadOnly = true;
            numeroTareas = 0;
            int numeroFila;

            foreach (Alumno alumno in lista)
            {
                numeroTareas = 0;
                numeroFila = tblAlumnos.Rows.Add();
                tblAlumnos.Rows[numeroFila].Cells[0].Value = alumno.Matricula;
                tblAlumnos.Rows[numeroFila].Cells[1].Value = $"{alumno.Nombre} {alumno.ApellidoP} {alumno.ApellidoM}";
                while (numeroTareas < curso.Tareas)
                {
                    tblAlumnos.Rows[numeroFila].Cells[numeroTareas + PRINCIPALES].Value = alumno.Tareas[numeroTareas];
                    numeroTareas++;

                }
                alumno.CalcularPromedio();
                tblAlumnos.Rows[numeroFila].Cells[tblAlumnos.ColumnCount - 1].Value = alumno.Promedio;
                alumnoDao.ActualizarPromedio(curso, alumno);


            }
            lblTareas.Text = $"Tareas: {curso.Tareas}";
        }

        private void FrmCurso_FormClosing(object sender, FormClosingEventArgs e)
        {
            principal.listaCursos = new CursoDao().ObtenerTablaCursos();
            principal.LlenarTabla(principal.listaCursos);
            principal.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cBoxElemento.Text == "Alumno")
            {
                FrmDatosAlumno datosAlumno = new FrmDatosAlumno(this, null!);
                datosAlumno.Visible = true;

            }
            else
            {
                FrmDatosTarea datosTarea = new FrmDatosTarea(this);
                datosTarea.Visible = true;
                Hide();
            }
            Hide();
        }

        private void cBoxElemento_SelectedValueChanged(object sender, EventArgs e)
        {
            actualizarControles();
        }

        public void actualizarControles()
        {
            if (curso != null)
            {
                if (cBoxElemento.Text == "Alumno")
                {
                    btnModificar.Enabled = curso.ListaAlumnos.Count > 0;
                    btnEliminar.Enabled = curso.ListaAlumnos.Count > 0;
                }
                else
                {
                    btnModificar.Enabled = curso.Tareas > 0;
                    btnEliminar.Enabled = curso.Tareas > 0;
                }
            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cBoxElemento.Text == "Alumno")
            {
                Alumno alumno = new Alumno((String)tblAlumnos.Rows[tblAlumnos.SelectedCells[0].RowIndex].Cells[0].Value, "", "", "");
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de elimar al\nalumno {alumno.Matricula}?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    alumnoDao.EliminarAlumno(curso, alumno);
                    curso.ListaAlumnos = alumnoDao.ObtenerDatosCurso(curso);
                    LlenarTabla(curso.ListaAlumnos);
                }
            }
            else
            {
                FrmListaTareas tareas = new FrmListaTareas(this, false);
                tareas.Visible = true;
                Hide();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cBoxElemento.Text == "Alumno")
            {
                String nombre = (String)tblAlumnos.Rows[tblAlumnos.SelectedCells[0].RowIndex].Cells[1].Value;
                String[] partesNombres = nombre.Split(' ');
                Alumno alumno = new Alumno((String)tblAlumnos.Rows[tblAlumnos.SelectedCells[0].RowIndex].Cells[0].Value,
                                           partesNombres[0], partesNombres[1], partesNombres[2]);
                FrmDatosAlumno datosAlumno = new FrmDatosAlumno(this, alumno);
                datosAlumno.Visible = true;
            }
            else
            {
                FrmListaTareas tareas = new FrmListaTareas(this, true);
                tareas.Visible = true;
            }

            Hide();

        }


        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                curso.ListaAlumnos = alumnoDao.BuscarAlumno(curso, new Alumno("", txtBusqueda.Text, "", ""), cBoxTipoBusqueda.Text);
                LlenarTabla(curso.ListaAlumnos);

            }
            else
            {
                curso.ListaAlumnos = alumnoDao.ObtenerDatosCurso(curso);
                LlenarTabla(curso.ListaAlumnos);
            }
        }

        private void tblAlumnos_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            columna = tblAlumnos.CurrentCell.ColumnIndex;
            valorAntiguo = float.Parse(tblAlumnos.Rows[tblAlumnos.SelectedCells[0].RowIndex].Cells[columna].Value.ToString()!);
        }

        private void tblAlumnos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            float nuevaCalificacion;

            // la columna de tareas debe de ser texto para verificar si es float y mandar mensaje de error a la maestra en caso contrario
            if (float.TryParse(tblAlumnos.Rows[tblAlumnos.CurrentCell.RowIndex].Cells[columna].Value.ToString(),out nuevaCalificacion))
            {
                if(nuevaCalificacion != (float)valorAntiguo)
                {
                    Alumno alumno = new Alumno((String)tblAlumnos.Rows[tblAlumnos.CurrentCell.RowIndex].Cells[0].Value, "", "", "");
                    int numeroTareas = 0;
                    float calificacion;
                    while (numeroTareas < curso.Tareas)
                    {


                        calificacion = float.Parse(tblAlumnos.Rows[tblAlumnos.CurrentCell.RowIndex].Cells[numeroTareas + PRINCIPALES].Value.ToString()!);
                        alumno.Tareas.Add(calificacion);
                        numeroTareas++;
                    }
                    alumno.CalcularPromedio();

                    alumnoDao.ActualizarCalificaciones(curso, alumno, tblAlumnos.Columns[columna].Name, columna - PRINCIPALES);
                    tblAlumnos.Rows[tblAlumnos.CurrentCell.RowIndex].Cells[tblAlumnos.ColumnCount - 1].Value = alumno.Promedio;
                }   
            }
        }
    }
}
