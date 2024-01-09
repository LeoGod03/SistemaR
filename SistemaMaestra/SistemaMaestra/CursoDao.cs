using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMaestra
{
    public class CursoDao
    {
        private ConexionBD administrador;
        private SqlConnection conexion;
        private String? query;
        private SqlCommand? comando;
        public CursoDao() 
        {
            administrador = new ConexionBD();
            conexion = new SqlConnection();
        }

        public void CrearTablaCursos()
        {
            conexion = administrador.EstablecerConexion();
            query = "IF OBJECT_ID('Cursos', 'U') IS NULL " +
                           "BEGIN " +
                           "CREATE TABLE Cursos( " +
                           "nombre NVARCHAR(50)," +
                           "alumnos INT," +
                           "tareas INT);" +
                           "END";
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();


            }catch (Exception e)
            {
                MessageBox.Show("¡Error al crear la tabla 'Cursos'!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();

        }
        public List<Curso> ObtenerTablaCursos()
        {
            conexion = administrador.EstablecerConexion();
            List<Curso> listaResultado = new List<Curso>();
            query = "SELECT * FROM Cursos";
            SqlDataReader lector;
            Curso curso;
            try
            {
                comando = new SqlCommand( query, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    curso = new Curso(lector.GetString(0),lector.GetInt32(1));
                    curso.Tareas = lector.GetInt32(2);
                    listaResultado.Add(curso);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("¡Error al obtener los datos de la tabla 'Cursos'!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
            return listaResultado;
        }
        public void AgregarCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            query = $"INSERT INTO Cursos (nombre, alumnos,tareas) VALUES (@Nombre, @Alumnos,@Tareas);" +
                    $"CREATE TABLE {Texto.NombreTablas(curso.Nombre)} ( " +
                    "matricula NVARCHAR(15) PRIMARY KEY," +
                    "nombre NVARCHAR(75)," +
                    "apellido_paterno NVARCHAR(75)," +
                    "apellido_materno NVARCHAR(75)," +
                    "promedio FLOAT );";
                    
            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                comando = new SqlCommand ( query, conexion,transaccion);    
                comando.Parameters.AddWithValue("@Nombre",curso.Nombre);
                comando.Parameters.AddWithValue("@Alumnos",curso.NumeroAlumnos);
                comando.Parameters.AddWithValue("@Tareas", curso.Tareas);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Curso '{curso.Nombre}' agregado con exito!", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception e) 
            {

                MessageBox.Show($"¡Error al agregar el curso '{curso.Nombre}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
                transaccion.Rollback();

            }
            administrador.CerrarConexion();
        }

        public List<String> ObtenerNombresColumnas(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            List<String> listaResultado = new List<String>();
            query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @Nombre;";
            SqlDataReader lector;
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre", curso.Nombre);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    listaResultado.Add(lector.GetString(0));
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al obtener los nombre de las columnas del curso '{curso.Nombre}'");
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
            return listaResultado;
        }
        public void ActualizarCurso(Curso curso,String nombre)
        {
            conexion = administrador.EstablecerConexion();
            query = "UPDATE Cursos " +
                    $"SET nombre = @NombreNuevo " +
                    $"WHERE nombre = @Nombre; " +
                    $"EXEC sp_rename '{Texto.NombreTablas(nombre)}', '{Texto.NombreTablas(curso.Nombre)}';";

            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {

                comando = new SqlCommand(query, conexion,transaccion);
                comando.Parameters.AddWithValue("@NombreNuevo", curso.Nombre);
                comando.Parameters.AddWithValue("@Nombre",nombre);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Curso '{nombre}' modificado a '{curso.Nombre}' con exito!", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                MessageBox.Show($"¡Error al modificar el curso '{nombre}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); MessageBox.Show("¡Error al obtener los datos de la tabla 'Cursos'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();

        }

        public void EliminarCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            query = $"DELETE Cursos WHERE nombre  = @Nombre; " +
                    $"DROP TABLE {Texto.NombreTablas(curso.Nombre)}";

            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {

                comando = new SqlCommand(query, conexion, transaccion);
                comando.Parameters.AddWithValue("@Nombre", curso.Nombre);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Curso '{curso.Nombre}' eliminado con exito!", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                MessageBox.Show($"¡Error al eliminar el curso '{curso.Nombre}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
        }
        
        public List<Curso> BuscarCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            List<Curso> listaResultado = new List<Curso>();
            query = $"SELECT * FROM Cursos WHERE nombre like @Nombre;";
            SqlDataReader lector;
            Curso cursoNuevo;
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre",$"%{curso.Nombre}%");
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    cursoNuevo = new Curso(lector.GetString(0), lector.GetInt32(1));
                    listaResultado.Add(cursoNuevo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("¡Error al obtener los datos de la bsuqueda!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
            return listaResultado;
        }

        public bool ExisteCurso(Curso curso) 
        {
            bool existe = false;
            conexion = administrador.EstablecerConexion();
            query = $"SELECT COUNT(*) FROM Cursos WHERE Nombre = @Nombre";

            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre",curso.Nombre);
                int esta = (int) comando.ExecuteScalar();
                existe = esta > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("¡Error al buscar el curso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            administrador.CerrarConexion();
            return existe;
        }
    }
}
