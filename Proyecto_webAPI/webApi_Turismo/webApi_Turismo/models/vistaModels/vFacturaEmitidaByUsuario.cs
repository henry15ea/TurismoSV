namespace webApi_Turismo.models.vistaModels
{
    public class vFacturaEmitidaByUsuarioModel
    {
        String id_factura;
        String paquete;
        String pasarela;
        String descuento;
        String monto;
        String total;
        String cupos;
        String usuario;
        String estado;

        public string Id_factura { get => id_factura; set => id_factura = value; }
        public string Paquete { get => paquete; set => paquete = value; }
        public string Pasarela { get => pasarela; set => pasarela = value; }
        public string Descuento { get => descuento; set => descuento = value; }
        public string Monto { get => monto; set => monto = value; }
        public string Total { get => total; set => total = value; }
        public string Cupos { get => cupos; set => cupos = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Estado { get => estado; set => estado = value; }
    }//end class
}//end namespaces
