namespace webApi_Turismo.models.vistaModels
{
    public class vencabezadoExt
    {
        private String id_factura;
        private String nombre;
        private String apellido;
        private String edad;
        private String telefono;
        private String direccion;
        private String correo;
        private String metodoPago;
        private String descuendo;
        private String monto;
        private String fecha;
        private String emitido;

        public string Id_factura { get => id_factura; set => id_factura = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Edad { get => edad; set => edad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string MetodoPago { get => metodoPago; set => metodoPago = value; }
        public string Descuendo { get => descuendo; set => descuendo = value; }
        public string Monto { get => monto; set => monto = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Emitido { get => emitido; set => emitido = value; }
    }
}
