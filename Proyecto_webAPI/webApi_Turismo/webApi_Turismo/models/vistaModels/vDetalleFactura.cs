namespace webApi_Turismo.models.vistaModels
{
    public class vDetalleFactura
    {
        private String id_registro;
        private String id_factura;
        private String paquete;
        private String descripcion;
        private String direccion;
        private String img;
        private decimal precio;
        private decimal descuento;
        private decimal monto;
        private decimal total;
        private int cupos_reservados;


        public string Id_registro { get => id_registro; set => id_registro = value; }
        public string Id_factura { get => id_factura; set => id_factura = value; }
        public string Paquete { get => paquete; set => paquete = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Img { get => img; set => img = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public int Cupos_reservados { get => cupos_reservados; set => cupos_reservados = value; }
        public decimal Total { get => total; set => total = value; }
    }
}
