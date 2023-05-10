namespace webApi_Turismo.models.mododelsdb.adicionalesModel
{
    public class formasPagoModel
    {
        private String idadicional;
        private String nombre = "adicional";
        private String descripcion = "descripcion default";
        private decimal precio = 0;
        private String username ;

        public string Idadicional { get => idadicional; set => idadicional = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Username { get => username; set => username = value; }
    }
}
