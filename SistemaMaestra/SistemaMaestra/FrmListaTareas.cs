using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaMaestra
{
    public partial class FrmListaTareas : Form
    {
        private bool editar;
        private String? nombreViejo;
        private FrmCurso cursoInterfaz;
        private const int DEFINIDAS = 5;
        public FrmListaTareas(FrmCurso cursoInterfaz, bool editar)
        {
            InitializeComponent();
            this.editar = editar;
            this.cursoInterfaz = cursoInterfaz;
            List<String> listaTareas = new CursoDao().ObtenerNombresColumnas(cursoInterfaz.curso);
            int numeroFila;
            for (int i = DEFINIDAS; i < listaTareas.Count; i++)
            {
                numeroFila = tblTareas.Rows.Add();
                tblTareas.Rows[numeroFila].Cells[0].Value = numeroFila + 1;
                tblTareas.Rows[numeroFila].Cells[1].Value = Texto.NombreColumnasDBD(listaTareas[i]);
            }

            nombreViejo = (String)tblTareas.Rows[0].Cells[1].Value;

            if (editar)
                txtTarea.Text = nombreViejo;
            else
            {
                txtTarea.Enabled = false;
                lblTarea.Enabled = false;
            }
        }





        private void FrmListaTareas_FormClosing(object sender, FormClosingEventArgs e)
        {
            cursoInterfaz.curso.ListaAlumnos = new AlumnoDao().ObtenerDatosCurso(cursoInterfaz.curso);
            cursoInterfaz.LlenarTabla(cursoInterfaz.curso.ListaAlumnos);
            cursoInterfaz.actualizarControles();
            cursoInterfaz.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tblTareas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            nombreViejo = (String)tblTareas.Rows[tblTareas.SelectedCells[0].RowIndex].Cells[1].Value;

            if (editar)
                txtTarea.Text = nombreViejo;

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (editar)
            {
                if(txtTarea.Text != nombreViejo)
                {
                    if (txtTarea.Text != "")
                    {
                        if(!new TareaDao().ExisteTarea(cursoInterfaz.curso,txtTarea.Text))
                        {
                            new TareaDao().ModificarTarea(cursoInterfaz.curso, txtTarea.Text, nombreViejo!);
                            this.Close();
                           
                        }                            
                        else
                            MessageBox.Show("¡Tarea ya existente, elige otra!", "Datos existentes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }     
                    else
                        MessageBox.Show("Favor de llenar bien el nombre de la nueva tarea", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                    this.Close();

            }
            else
            {
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de elimar la\ntarea '{nombreViejo}'?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    new TareaDao().EliminarTarea(cursoInterfaz.curso, nombreViejo!);
                    this.Close();
                }
            }
        }
    }
}
