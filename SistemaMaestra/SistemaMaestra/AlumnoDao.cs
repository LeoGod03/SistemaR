using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMaestra
{
    public class AlumnoDao
    {
        private ConexionBD administrador;
        private SqlConnection? conexion;
        private String? query;
        private SqlCommand? comando;
        private const int DEFINIDAS = 5;
        public AlumnoDao()
        {
            administrador = new ConexionBD();
        }

        public List<Alumno> ObtenerDatosCurso(Curso curso)
        {
            conexion = administrador.EstablecerConexion();
            List<Alumno> listaResultado = new List<Alumno>();
            query = $"SELECT * FROM {Texto.NombreTablas(curso.Nombre)} " +
                    $"ORDER BY {Texto.NombreTablas(curso.Nombre)}.apellido_paterno ASC;";
            SqlDataReader lector;
            int contadorTareas;
            Alumno alumno;
            try
            {
                comando = new SqlCommand(query, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    alumno = new Alumno(lector.GetString(0), lector.GetString(1),
                                        lector.GetString(2), lector.GetString(3));

                    contadorTareas = 0;
                   while (contadorTareas < curso.Tareas)
                   {
                        if (!lector.IsDBNull(contadorTareas + DEFINIDAS))
                            alumno.Tareas.Add((float)lector.GetDouble(contadorTareas + DEFINIDAS));
                        else
                            alumno.Tareas.Add(0);
                        
                        contadorTareas++;
                    }


                    listaResultado.Add(alumno);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"¡Error al obtener los datos del curso '{curso.Nombre}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
            return listaResultado;
        }

        public void AgregarAlumno(Curso curso,Alumno alumno)
        {
            conexion = administrador.EstablecerConexion();
            query = $"INSERT INTO {Texto.NombreTablas(curso.Nombre)} VALUES (@Matricula,@Nombre,@ApP,@ApM,@Promedio";
            int contadorTareas = 0;
            while(contadorTareas < curso.Tareas) 
            {

                query += $",@T{contadorTareas+1}";
                contadorTareas++;
                
            }
            query += ");" +
                     "UPDATE Cursos " +
                     "SET alumnos = alumnos + 1 " +
                     $"WHERE nombre = @NombreCurso;";
            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                comando = new SqlCommand(query, conexion,transaccion);
                comando.Parameters.AddWithValue("@Matricula", alumno.Matricula);
                comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                comando.Parameters.AddWithValue("@ApP", alumno.ApellidoP);
                comando.Parameters.AddWithValue("@ApM", alumno.ApellidoM);
                comando.Parameters.AddWithValue("@Promedio", 0);
                comando.Parameters.AddWithValue("@NombreCurso", curso.Nombre);
                contadorTareas = 0;
                while (contadorTareas < curso.Tareas)
                {
                    comando.Parameters.AddWithValue($"@T{contadorTareas+1}",0);
                    contadorTareas ++;
                }
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Alumno '{alumno.Matricula}' agregado con exito!","¡Exito!",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                transaccion.Rollback();
                MessageBox.Show($"No se pudo agregar al Alumno '{alumno.Matricula}'","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            administrador.CerrarConexion();
        }

        public void EliminarAlumno(Curso curso,Alumno alumno)
        {
            conexion = administrador.EstablecerConexion();

            query = $"DELETE FROM {Texto.NombreTablas(curso.Nombre)} WHERE matricula = @Matricula; " +
                     "UPDATE Cursos " +
                     "SET alumnos = alumnos - 1 " +
                     $"WHERE nombre = @Nombre;";

            SqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                comando = new SqlCommand(query, conexion, transaccion);
                comando.Parameters.AddWithValue("@Matricula",alumno.Matricula);
                comando.Parameters.AddWithValue("@Nombre", curso.Nombre);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Alumno '{alumno.Matricula}' eliminado con exito!", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                transaccion.Rollback();
                MessageBox.Show($"¡No se pudo eliminar al\nalumno {alumno.Matricula}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            administrador.CerrarConexion();
        }

        public void ModificarAlumno(Curso curso,Alumno alumno, String matricula) 
        {
            conexion = administrador.EstablecerConexion();
            query = $"UPDATE {Texto.NombreTablas(curso.Nombre)} " +
                    $"SET matricula = @Matricula," +
                    $"nombre = @Nombre," +
                    $"apellido_paterno = @ApellidoP," +
                    $"apellido_materno = @ApellidoM " +
                    $"WHERE matricula = @MatriculaVieja;";
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Matricula", alumno.Matricula);
                comando.Parameters.AddWithValue("@Nombre", alumno.Nombre);
                comando.Parameters.AddWithValue("@ApellidoP", alumno.ApellidoP);
                comando.Parameters.AddWithValue("@ApellidoM", alumno.ApellidoM);
                comando.Parameters.AddWithValue("@MatriculaVieja", matricula);
                comando.ExecuteNonQuery();
                MessageBox.Show($"¡Alumno {alumno.Matricula}\nactualizado con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }catch (Exception e) 
            {
                MessageBox.Show($"¡Alumno {alumno.Matricula}\nno pudo actualizarse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            conexion.Close();
        }

        public List<Alumno> BuscarAlumno(Curso curso,Alumno alumno,String busqueda)
        {
            
            conexion = administrador.EstablecerConexion();
            List<Alumno> listaResultado = new List<Alumno>();
            query = $"SELECT * FROM {Texto.NombreTablas(curso.Nombre)} WHERE ";
            if (busqueda == "Matricula")
                query += $"matricula like @Valor ";

            else
                query += $"nombre + ' ' + apellido_paterno + ' ' + apellido_materno like @Valor ";

            query += $"ORDER BY {Texto.NombreTablas(curso.Nombre)}.apellido_paterno ASC;";

            SqlDataReader lector;
            int contadorTareas;
            try
            {
                comando = new SqlCommand (query, conexion);
                comando.Parameters.AddWithValue("@Valor",$"%{alumno.Nombre}%");
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    alumno = new Alumno(lector.GetString(0), lector.GetString(1),
                                        lector.GetString(2), lector.GetString(3));

                    contadorTareas = 0;
                    while (contadorTareas < curso.Tareas)
                    {
                        if (!lector.IsDBNull(contadorTareas + DEFINIDAS))
                            alumno.Tareas.Add((float)lector.GetDouble(contadorTareas + DEFINIDAS));
                        else
                            alumno.Tareas.Add(0);

                        contadorTareas++;
                    }


                    listaResultado.Add(alumno);
                }

            }catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error en la busqueda de alumnos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            administrador.CerrarConexion();

            return listaResultado;
        }

        public void ActualizarCalificaciones(Curso curso,Alumno alumno, String tarea, int numTarea)
        {
            conexion = administrador.EstablecerConexion();
            query = $"UPDATE {Texto.NombreTablas(curso.Nombre)} " +
                    $"SET {Texto.NombreColumnasABD(tarea)} = @Tarea," +
                    $"promedio = @Promedio " +
                    $"WHERE matricula = @Matricula;";
            try
            {
                comando = new SqlCommand(query,conexion);
                comando.Parameters.AddWithValue("@Matricula", alumno.Matricula);
                comando.Parameters.AddWithValue("@Tarea", alumno.Tareas[numTarea]);
                comando.Parameters.AddWithValue("@Promedio", alumno.Promedio);
                comando.ExecuteNonQuery();
            }catch(Exception e) 
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error en la actualización de calificaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            administrador.CerrarConexion();
        }

        public void ActualizarPromedio(Curso curso, Alumno alumno)
        {
            conexion = administrador.EstablecerConexion();
            query = $"UPDATE {Texto.NombreTablas(curso.Nombre)} " +
                    $"SET promedio = @Promedio " +
                    $"WHERE matricula = @Matricula;";
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Promedio", alumno.Promedio);
                comando.Parameters.AddWithValue("@Matricula", alumno.Matricula);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("Error en la actualización de promedio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            administrador.CerrarConexion();
        }
        public bool ExisteAlumno(Curso curso,Alumno alumno) 
        {
            bool existe = false;
            conexion = administrador.EstablecerConexion();
            query = $"SELECT COUNT(*) FROM {Texto.NombreTablas(curso.Nombre)} WHERE matricula = @Matricula";

            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Matricula",alumno.Matricula);
                int esta = (int) comando.ExecuteScalar();
                existe = esta > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("¡Error al buscar el alumno!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            administrador.CerrarConexion();
            return existe;
        }

        public List<Alumno> ObtenerAlumnosEspecificos(Curso curso, bool aprobados)
        {
            conexion = administrador.EstablecerConexion();
            List<Alumno> listaResultado = new List<Alumno>();
            query = $"SELECT * FROM {Texto.NombreTablas(curso.Nombre)} WHERE promedio";
            if (aprobados)
                query += " >= 7 ";
            else
                query += " < 7 ";

                 query += $"ORDER BY {Texto.NombreTablas(curso.Nombre)}.apellido_paterno ASC;";

            SqlDataReader lector;
            int contadorTareas;
            Alumno alumno;
            try
            {
                comando = new SqlCommand(query, conexion);
                lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    alumno = new Alumno(lector.GetString(0), lector.GetString(1),
                                        lector.GetString(2), lector.GetString(3));

                    contadorTareas = 0;
                    while (contadorTareas < curso.Tareas)
                    {
                        if (!lector.IsDBNull(contadorTareas + DEFINIDAS))
                            alumno.Tareas.Add((float)lector.GetDouble(contadorTareas + DEFINIDAS));
                        else
                            alumno.Tareas.Add(0);

                        contadorTareas++;
                    }


                    listaResultado.Add(alumno);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"¡Error al obtener los datos solicitados del curso '{curso.Nombre}'!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
            return listaResultado;
        }
    }
}
