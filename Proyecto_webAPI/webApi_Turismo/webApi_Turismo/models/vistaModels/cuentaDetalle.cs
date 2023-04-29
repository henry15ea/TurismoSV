namespace webApi_Turismo.models.vistaModels.cuentaDetalle
{
    public class cuentaDetalle
    {
        private String id_cuenta;
        private String u_name;
        private String id_usuario;
        private String nombre;
        private String apellido;
        private String correo;
        private int id_rol;
        private bool u_state;

        public string Id_cuenta { get => id_cuenta; set => id_cuenta = value; }
        public string U_name { get => u_name; set => u_name = value; }
        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public bool U_state { get => u_state; set => u_state = value; }
    }
}
