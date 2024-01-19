using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace SistemaMaestra
{
    public class ConexionBD
    {
        SqlConnection conexion = new SqlConnection();

        private String? servidor;
        private String? bd;
        private String? usuario;
        private String? password;
        private String? puerto;
        private String? cadenaConexion;

        public ConexionBD()
        {
            string directorioDeLaAplicacion = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(directorioDeLaAplicacion, "datos.txt");
            List<String> datos = new List<String>();
            try
            {

                using (StreamReader sr = new StreamReader(filePath))
                { 
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                        datos.Add(line);


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocurrió un error: " + e.Message);
            }
            if (datos.Count == 5)
            {
                servidor = datos[0];
                bd = datos[1];
                usuario = datos[2];
                password = datos[3];
                puerto = datos[4];

                cadenaConexion = "Data Source = " + servidor + "," + puerto +
                                  "; user id = " + usuario + ";password = " + password +
                                  ";Initial Catalog =" + bd + ";Persist Security Info = false";
            }
        }

        public SqlConnection EstablecerConexion()
        {
            try
            {
                conexion.ConnectionString = cadenaConexion;
                conexion.Open();
               // MessageBox.Show("Se establecio conexion con la base de datos");
            }catch (Exception e)
            {
                MessageBox.Show("Error al conectar a la base: "+e.Message,"Error");
            }
            return conexion;
        }

        public void CerrarConexion()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al cerrar la conexión");
                Console.WriteLine(e.Message);
            }
        }
    }
}
