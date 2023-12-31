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
        private String query;
        private SqlCommand comando;
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
                           "nombre NVARCHAR(50),alumnos INT);" +
                           "END";
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();

            }catch (Exception e)
            {
                MessageBox.Show("Error al crear la tabla 'Cursos'");
                Console.WriteLine(e.Message);
            }
            conexion.Close();

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
                    listaResultado.Add(curso);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener los datos de la tabla 'Cursos'");
                Console.WriteLine(e.Message);
            }
            conexion.Close();
            return listaResultado;
        }
        public void AgregarCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            query = $"INSERT INTO Cursos (nombre, alumnos) VALUES (@Nombre, @Alumnos);" +
                    $"CREATE TABLE {curso.Nombre.ToUpper()} ( " +
                    $"matricula NVARCHAR PRIMARY KEY," +
                    $"nombre NVARCHAR(75)," +
                    $"apellido_paterno NVARCHAR(75)," +
                    $"apellido_materno NVARCHAR(75)," +
                    $"promedio DECIMAL );";
            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                comando = new SqlCommand ( query, conexion,transaccion);    
                comando.Parameters.AddWithValue("@Nombre",curso.Nombre);
                comando.Parameters.AddWithValue("@Alumnos",curso.NumeroAlumnos); 
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Curso {curso.Nombre} agregado con exito!");
            }
            catch(Exception e) 
            {
                
                MessageBox.Show($"Error al crear un nuevo curso {e.Message}");
                Console.WriteLine(e.Message);
                transaccion.Rollback();

            }
            conexion.Close();
        }

        // mover este metodo a futura clase alumnoDao
        public List<Alumno> ObtenerDatosCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            List<Alumno> listaResultado = new List<Alumno>();
            query = $"SELECT * FROM {curso.Nombre.ToUpper()}";
            SqlDataReader lector;
            int contadorTareas = 0;
            int tareas = curso.Tareas;
            Alumno alumno;
            try
            {
                comando = new SqlCommand(query, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    alumno = new Alumno(lector.GetString(0),lector.GetString(1),
                                        lector.GetString(2),lector.GetString(3));
                    while(contadorTareas < tareas)
                    {
                        alumno.Tareas.Add((float)lector.GetDecimal(contadorTareas + 4));
                        contadorTareas++;
                    }
                       

                    listaResultado.Add(alumno);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error al obtener los datos del curso '{curso.Nombre}'");
                Console.WriteLine(e.Message);
            }
            conexion.Close();
            return listaResultado;
        }

        public List<String> ObtenerNombresColumnas(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            List<String> listaResultado = new List<String>();
            query = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{curso.Nombre.ToUpper()}'";
            SqlDataReader lector;
            try
            {
                comando = new SqlCommand(query, conexion);
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
            conexion.Close();
            return listaResultado;
        }

        public void ActualizarCurso(Curso curso,String nombre)
        {
            conexion = administrador.EstablecerConexion();
            query = "UPDATE Cursos " +
                    $"SET nombre = '{curso.Nombre}' " +
                    $"WHERE nombre = '{nombre}'; " +
                    $"EXEC sp_rename '{nombre.ToUpper()}', '{curso.Nombre.ToUpper()}';";

            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {

                comando = new SqlCommand(query, conexion,transaccion);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Curso {nombre} modificado a {curso.Nombre}\ncon exito!");
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                MessageBox.Show($"Error al editar el curso '{nombre}' por {e.Message}");
                Console.WriteLine(e.Message);
            }
            conexion.Close();

        }

        public void EliminarCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            query = $"DELETE Cursos WHERE nombre  = '{curso.Nombre}'; " +
                    $"DROP TABLE {curso.Nombre.ToUpper()}";

            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {

                comando = new SqlCommand(query, conexion, transaccion);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Curso {curso.Nombre} eliminado\ncon exito!");
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                MessageBox.Show($"Error al editar el curso '{curso.Nombre}' por {e.Message}");
                Console.WriteLine(e.Message);
            }
            conexion.Close();
        }
        
        public List<Curso> BuscarCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            List<Curso> listaResultado = new List<Curso>();
            query = $"SELECT * FROM Cursos WHERE nombre like '%{curso.Nombre}%';";
            SqlDataReader lector;
            Curso cursoNuevo;
            try
            {
                comando = new SqlCommand(query, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    cursoNuevo = new Curso(lector.GetString(0), lector.GetInt32(1));
                    listaResultado.Add(cursoNuevo);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener los datos de la tabla 'Cursos'");
                Console.WriteLine(e.Message);
            }
            conexion.Close();
            return listaResultado;
        }
    }
}
