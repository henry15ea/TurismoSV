namespace webApi_Turismo.models.vistaModels
{
    public class vPersonasExtrasExt
    {
        private string id_registro;
        private String invitado;
        private String n_documento;
        private int edad;
        private String cuenta_titular;
        private String titular;
        private String correo;
        private String telefono;
        private String paquete;
        private String registro;

        public string Id_registro { get => id_registro; set => id_registro = value; }
        public string Invitado { get => invitado; set => invitado = value; }
        public string N_documento { get => n_documento; set => n_documento = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Cuenta_titular { get => cuenta_titular; set => cuenta_titular = value; }
        public string Titular { get => titular; set => titular = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Paquete { get => paquete; set => paquete = value; }
        public string Registro { get => registro; set => registro = value; }
    }
}
