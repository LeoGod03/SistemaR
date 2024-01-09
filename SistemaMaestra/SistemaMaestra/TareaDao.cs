using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaMaestra
{
    public class TareaDao
    {
        private ConexionBD administrador;
        private SqlConnection? conexion;
        private SqlCommand? comando;
        private String? query;
        public TareaDao()
        {
            administrador = new ConexionBD();
        }


        public void AgregarTarea(Curso curso,String tarea)
        {
            conexion = administrador.EstablecerConexion();
            query = $"ALTER TABLE {Texto.NombreTablas(curso.Nombre)} ADD {Texto.NombreColumnasABD(tarea)} FLOAT;" +
                    $"UPDATE Cursos " +
                    $"SET tareas = tareas + 1 " +
                    $"WHERE nombre = @Nombre;";
            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                comando = new SqlCommand(query, conexion,transaccion);
                comando.Parameters.AddWithValue("@Nombre", curso.Nombre);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                curso.Tareas++;
                MessageBox.Show($"¡Tarea '{tarea}' agregada con exito!", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e)
            {
                transaccion.Rollback();
                MessageBox.Show($"Error al crear la tarea '{tarea}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();

        }
        public void ModificarTarea(Curso curso,String tareaNuevo,String tareaViejo)
        {
            conexion = administrador.EstablecerConexion();
            query = $"EXEC sp_rename '{Texto.NombreTablas(curso.Nombre)}.{Texto.NombreColumnasABD(tareaViejo)}', '{Texto.NombreColumnasABD(tareaNuevo)}', 'COLUMN'";
            try
            {
                comando = new SqlCommand(query, conexion);
                comando.ExecuteNonQuery();
                MessageBox.Show($"¡Tarea '{tareaViejo}' modificada a {tareaNuevo} con exito!", "¡Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception e) 
            {
                MessageBox.Show($"Error al modificar la tarea '{e.Message}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(e.Message);
            }
            administrador.CerrarConexion();
        }

        public void EliminarTarea(Curso curso,String tarea)
        {
            conexion = administrador.EstablecerConexion();
            query = $"ALTER TABLE {Texto.NombreTablas(curso.Nombre)} DROP COLUMN {Texto.NombreColumnasABD(tarea)};" +
                    "UPDATE Cursos " +
                    "SET tareas = tareas -1 " +
                    $"WHERE nombre = @Nombre;";
            SqlTransaction transaccion = conexion.BeginTransaction();
            try
            {
                comando = new SqlCommand (query, conexion,transaccion);
                comando.Parameters.AddWithValue("@Nombre", curso.Nombre);
                comando.ExecuteNonQuery();
                transaccion.Commit();
                MessageBox.Show($"¡Tarea '{tarea}' eliminada con exito!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                curso.Tareas--;
            }
            catch (Exception e) 
            {
                transaccion.Rollback();
                Console.WriteLine (e.Message);  
                MessageBox.Show($"Error al eliminar la tarea '{tarea}'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            administrador.CerrarConexion();
        }

        public bool ExisteTarea(Curso curso,String tarea)
        {
            bool existe = false;
            conexion = administrador.EstablecerConexion();
            query = $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @Nombre AND COLUMN_NAME = @Tarea;";

            try
            {
                comando = new SqlCommand(query, conexion);
                comando.Parameters.AddWithValue("@Nombre",Texto.NombreTablas(curso.Nombre));
                comando.Parameters.AddWithValue("@Tarea", Texto.NombreColumnasABD(tarea));
                int esta = (int)comando.ExecuteScalar();
                existe = esta > 0;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                MessageBox.Show("¡Error al buscar el tarea!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            administrador.CerrarConexion();
            return existe;
        }
    }
}
