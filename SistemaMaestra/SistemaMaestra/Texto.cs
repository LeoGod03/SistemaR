using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMaestra
{
    public class Texto
    {
        
        public static String NombreTablas(String cadena)
        {
            String[] partesCadena = cadena.Split(' ');
            String cadenaResultado = "";
            string palabra;
            for (int i = 0; i < partesCadena.Length; i++)
            {
                palabra = partesCadena[i].ToLower();
                palabra = char.ToUpper(palabra[0]) + palabra.Substring(1);
                cadenaResultado += palabra;
            }
            return cadenaResultado;
        }
        public static String NombreColumnasABD(String cadena) 
        {
            String cadenaResultado = "";
            String[] partesCadena = cadena.Split(' ');
            
            foreach(String parte in partesCadena)
            {
                
                if (parte != "")
                {
                    cadenaResultado += parte;
                    cadenaResultado += "_";

                }
               
            }

            return cadenaResultado.Substring(0,cadenaResultado.Length-1);
        }

        public static String NombreColumnasDBD(String cadena)
        {
            String cadenaResultado = "";
            String[] partesCadena = cadena.Split('_');
            foreach( String parte in partesCadena)
            {
                if(parte != "")
                {
                    cadenaResultado += parte;
                    cadenaResultado += " ";
                }
              
            }

            return cadenaResultado.TrimEnd();
        }
    }
}
