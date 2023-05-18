namespace webApi_Turismo.models.customModels
{
    public class cInPersonasExtrasUser
    {
        private String nombre;
        private String apellido;
        private String n_doc;
        private int edad;
        private String iddetalle;
        private String username;
        private String id_paquete;


        // public string Idagregado { get => idagregado; set => idagregado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string N_doc { get => n_doc; set => n_doc = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Iddetalle { get => iddetalle; set => iddetalle = value; }
        public string Username { get => username; set => username = value; }
        public string Id_paquete { get => id_paquete; set => id_paquete = value; }
    }
}
