namespace webApi_Turismo.models.vistaModels
{
    public class vdetalleUsuarioModel
    {
        private string id;
        private string nombre;
        private string apellido;
        private string edad;
        private string telefono;
        private string direccion;
        private string correo;
        private string rol;
        private string estado;
        private string registro;

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Registro { get => registro; set => registro = value; }
    }
}
