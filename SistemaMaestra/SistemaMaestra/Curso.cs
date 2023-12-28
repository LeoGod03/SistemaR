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

        public Curso(String nombre)
        {
            Nombre = nombre;
            NumeroAlumnos = 0;
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
    }
}
