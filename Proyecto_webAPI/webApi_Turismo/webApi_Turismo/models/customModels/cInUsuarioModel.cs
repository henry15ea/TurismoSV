namespace webApi_Turismo.models.customModels
{
    public class cInUsuarioModel
    {
       
        private string nombre;
        private string apellido;
        private int edad;
        private string telefono;
        private string direccion;
        private string correo;
        private int id_rol;
        private bool estado;
        private String username;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public bool Estado { get => estado; set => estado = value; }
        public string Username { get => username; set => username = value; }
    }
}
