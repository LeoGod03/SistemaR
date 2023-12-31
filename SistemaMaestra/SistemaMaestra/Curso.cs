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
        public Curso(String nombre, int numeroAlumnos)
        {
            Nombre = nombre;
            NumeroAlumnos = numeroAlumnos;
            Tareas = 0;
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
                if (value != "") nombre = value;
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
    }
}
