using System.Windows.Forms;

namespace SistemaMaestra
{
    public partial class FrmMenuPrincipal : Form
    {
        private CursoDao cursoDao;
        private List<Curso> listaCursos;
        public FrmMenuPrincipal()
        {
            cursoDao = new CursoDao();
            InitializeComponent();
            cursoDao.CrearTablaCursos();
            listaCursos = cursoDao.ObtenerTablaCursos();
            LlenarTabla(listaCursos);
            btnModificarCurso.Enabled = listaCursos.Count > 0;
            btnEliminarCurso.Enabled = listaCursos.Count > 0;

        }


        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            FrmDatosCurso datosCurso = new FrmDatosCurso(this, null);
            datosCurso.Visible = true;
            Hide();
        }
        public void AgregarCursoTabla(Curso curso)
        {
            cursoDao.AgregarCurso(curso);
            int numeroFila = tblCursos.Rows.Add();
            tblCursos.Rows[numeroFila].Cells[0].Value = curso.Nombre;
            tblCursos.Rows[numeroFila].Cells[1].Value = curso.NumeroAlumnos;
            btnModificarCurso.Enabled = true;
            btnEliminarCurso.Enabled = true;
        }


        private void tblCursos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            Curso curso = new Curso((String)tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[0].Value, (int)tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[1].Value);
            FrmCurso interfazCurso = new FrmCurso(curso, this);
            interfazCurso.Visible = true;
            Hide();
            //MessageBox.Show($"Curso: {tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[0].Value}");
        }

        private void btnModificarCurso_MouseClick(object sender, MouseEventArgs e)
        {
            Curso curso = new Curso((String)tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[0].Value,
                                    (int)tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[1].Value);
            FrmDatosCurso datosCurso = new FrmDatosCurso(this, curso);
            datosCurso.Visible = true;
            Hide();
        }
        public void LlenarTabla(List<Curso> lista)
        {
            tblCursos.Rows.Clear();
            int numeroFila;
            foreach (Curso curso in lista)
            {
                numeroFila = tblCursos.Rows.Add();
                tblCursos.Rows[numeroFila].Cells[0].Value = curso.Nombre;
                tblCursos.Rows[numeroFila].Cells[1].Value = curso.NumeroAlumnos;
            }
        }

        private void btnEliminarCurso_MouseClick(object sender, MouseEventArgs e)
        {
            Curso curso = new Curso((String)tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[0].Value,
                                    (int)tblCursos.Rows[tblCursos.SelectedCells[0].RowIndex].Cells[1].Value);
            DialogResult resultado = MessageBox.Show($"¿Estas seguro de eliminar el\ncurso {curso.Nombre}?", "Eliminar curso", MessageBoxButtons.OKCancel);

            if (resultado == DialogResult.OK)
            {
                cursoDao.EliminarCurso(curso);
                listaCursos = cursoDao.ObtenerTablaCursos();
                LlenarTabla(listaCursos);
                btnModificarCurso.Enabled = listaCursos.Count > 0;
                btnEliminarCurso.Enabled = listaCursos.Count > 0;
            }

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (txtBusqueda.Text != "")
            {
                Curso curso = new Curso(txtBusqueda.Text, 0);
                listaCursos = cursoDao.BuscarCurso(curso);

            }
            else
                listaCursos = cursoDao.ObtenerTablaCursos();


           LlenarTabla(listaCursos);
        }
    }
}
