using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
namespace SistemaMaestra
{
    public class Alumno
    {
        private String nombre;
        private String apellidoP;
        private String apellidoM;
        private String matricula;
        private List<float> tareas;
        private float promedio;

        public Alumno(String matricula, String nombre, String apellidoP, String apellidoM)
        {
            Nombre = nombre;
            ApellidoP = apellidoP;
            ApellidoM = apellidoM;
            Matricula = matricula;
            tareas = new List<float>();
            promedio = 0;
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
        
        public String ApellidoP
        {
            get { return apellidoP; }
            set
            {
                if (value != null)
                    apellidoP = value;
                else
                    apellidoP = "S/AP";
            }
        }

        public String ApellidoM
        {
            get { return apellidoM; }
            set
            {
                if (value != null)
                    apellidoM = value;
                else
                    apellidoM = "S/AM";
            }
        }

        public String Matricula
        {
            get { return matricula; }
            set
            {
                if (ValidarMatricula(value))
                    matricula = value;
                else
                    matricula = "XX-XXX-XXXX";
            }
        }

        public List<float> Tareas
        {
            get { return tareas; }
            set { tareas = value; }
        }

        public float Promedio
        {
            get { return promedio; }
        }

        public static bool ValidarMatricula(String matricula)
        {
            string expresion = @"^\d{2}-\d{3}-\d{4}$"; // XX-XXX-XXXX
            return Regex.IsMatch(matricula,expresion);
        }

        public void CalcularPromedio()
        {
            if (tareas.Count != 0)
            {
                float suma = 0;
                foreach (float tarea in tareas)
                    suma += tarea;

                promedio = suma / tareas.Count;

            }
            else
                promedio = 0;
        }
    }
}
