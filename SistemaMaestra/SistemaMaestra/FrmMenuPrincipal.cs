namespace SistemaMaestra
{
    public partial class FrmMenuPrincipal : Form
    {
        public FrmMenuPrincipal()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCrearCurso_Click(object sender, EventArgs e)
        {
            FrmDatosCurso datosCurso = new FrmDatosCurso(this);
            datosCurso.Visible = true;
            Visible = false;
        }
        public void AgregarCursoTabla(Curso curso)
        {
            int numeroFila = tblCursos.Rows.Add();
            tblCursos.Rows[numeroFila].Cells[0].Value = curso.Nombre;
            tblCursos.Rows[numeroFila].Cells[1].Value = curso.NumeroAlumnos;
        }
    }
}
