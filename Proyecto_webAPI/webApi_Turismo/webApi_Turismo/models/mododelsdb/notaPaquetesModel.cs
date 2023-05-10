namespace webApi_Turismo.models.mododelsdb
{
    public class notaPaquetesModel
    {
        private String id_calificacion;
        private String id_usuario;
        private String id_paquete;
        private Int16 nota;
        private DateTime fecha;

        public string Id_calificacion { get => id_calificacion; set => id_calificacion = value; }
        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Id_paquete { get => id_paquete; set => id_paquete = value; }
        public short Nota { get => nota; set => nota = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
    }
}
