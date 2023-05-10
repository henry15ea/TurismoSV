namespace webApi_Turismo.models.vistaModels
{
    public class vPaqueteNota
    {
        private string id;
        private String usuario;
        private String nombre;
        private String apellido;
        private String correo;
        private String pkg;
        private String paquete;
        private String categoria;
        private int nota;
        private DateTime fecha;

        public string Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Pkg { get => pkg; set => pkg = value; }
        public string Paquete { get => paquete; set => paquete = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public int Nota { get => nota; set => nota = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
