namespace webApi_Turismo.models.customModels
{
    public class cUpDetalleFacturaModel
    {
        private String iddetalle;
        private String idencabezado;
        private String idpaqueted;
        private Decimal precio;
        private decimal descuento;
        private decimal monto;
        private int cupos;
        private string username;

        public string Iddetalle { get => iddetalle; set => iddetalle = value; }
        public string Idencabezado { get => idencabezado; set => idencabezado = value; }
        public string Idpaqueted { get => idpaqueted; set => idpaqueted = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public int Cupos { get => cupos; set => cupos = value; }
        public string Username { get => username; set => username = value; }
    }
}
