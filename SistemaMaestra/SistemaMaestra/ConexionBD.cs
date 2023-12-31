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

        private String servidor = "localhost";
        private String bd = "SistemaMaestra";
        private String usuario = "Leo";
        private String password = "12345";
        private String puerto = "51637";
        private String cadenaConexion;

        public ConexionBD() 
        {
            cadenaConexion = "Data Source = "+ servidor + "," + puerto + 
                             "; user id = " + usuario +";password = " + password + 
                             ";Initial Catalog =" + bd + ";Persist Security Info = false";
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
            }
        }
    }
}
