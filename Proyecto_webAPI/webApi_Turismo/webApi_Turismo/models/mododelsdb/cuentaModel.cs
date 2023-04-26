namespace webApi_Turismo.models.mododelsdb.cuentaModel
{
    public class cuentaModel
    {
        String id_cuenta;
        String id_usuario;
        String u_name;
        String u_pass;
        int u_state;

        public string Id_cuenta { get => id_cuenta; set => id_cuenta = value; }
        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string U_name { get => u_name; set => u_name = value; }
        public string U_pass { get => u_pass; set => u_pass = value; }
        public int U_state { get => u_state; set => u_state = value; }
    }
}
