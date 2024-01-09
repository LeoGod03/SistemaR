using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMaestra
{
    public class Curso
    {
        private String nombre;
        private int numeroAlumnos;
        private int tareas;
        private List<Alumno> listaAlumno;
        public Curso(String nombre, int numeroAlumnos)
        {
            Nombre = nombre;
            NumeroAlumnos = numeroAlumnos;
            Tareas = 0;
            listaAlumno = new List<Alumno>();
        }
        public int NumeroAlumnos
        {
            get { return numeroAlumnos; }
            set
            {
                if (value > 0) numeroAlumnos = value;
            }
        }
        public String Nombre
        {
            get { return nombre; }
            set
            {
                if (value != "")
                    nombre = value;
                else
                    nombre = "S/N";
            }
        }
        public int Tareas
        {
            get { return tareas; }
            set 
            {
                if (value >= 0) 
                    tareas = value;
                else
                    tareas = 0;
            }
        }
        public List<Alumno> ListaAlumnos
        {
            get { return listaAlumno; }
            set { listaAlumno = value; }
        }
    }
}
