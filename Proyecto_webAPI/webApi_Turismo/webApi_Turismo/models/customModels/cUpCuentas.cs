namespace webApi_Turismo.models.customModels
{
    public class cUpCuentas
    {
        private String id_cuenta;
        private String id_usuario;
        private String u_name;
        private String u_pass;
        private bool u_state;
        private String username;


        public string Id_cuenta { get => id_cuenta; set => id_cuenta = value; }
        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string U_name { get => u_name; set => u_name = value; }
        public string U_pass { get => u_pass; set => u_pass = value; }
        public bool U_state { get => u_state; set => u_state = value; }
        public string Username { get => username; set => username = value; }
    }
}
