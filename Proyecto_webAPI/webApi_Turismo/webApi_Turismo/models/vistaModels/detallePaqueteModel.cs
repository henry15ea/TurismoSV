namespace webApi_Turismo.models.vistaModels
{
    public class detallePaqueteModel
    {

        String idpaqueted;
        String nombre;
        String descripcion;
        String direccion;
        String img;
        decimal precio;
        String cupos_disp;
        String cuposllenos;
        DateTime fechainicial;
        DateTime fechafinal;
        DateTime fechreg;
        bool   estado;

        public string Idpaqueted { get => idpaqueted; set => idpaqueted = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Img { get => img; set => img = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public String Cupos_disp { get => cupos_disp; set => cupos_disp = value; }
        public String Cuposllenos { get => cuposllenos; set => cuposllenos = value; }
        public DateTime Fechainicial { get => fechainicial; set => fechainicial = value; }
        public DateTime Fechafinal { get => fechafinal; set => fechafinal = value; }
        public bool Estado { get => estado; set => estado = value; }
        public DateTime Fechreg { get => fechreg; set => fechreg = value; }
    }
}
