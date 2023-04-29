namespace webApi_Turismo.models.mododelsdb.detalleFacturaModel
{
    public class detalleFacturaModel
    {
        String username;
        String iddetalle;
        String idencabezado;
        String idpaqueted;
        decimal precio;
        decimal descuento;
        decimal monto;
        int cupos;

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
