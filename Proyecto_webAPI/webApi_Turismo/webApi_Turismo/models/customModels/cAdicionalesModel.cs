namespace webApi_Turismo.models.customModels.cAdicionalesModel
{
    public class cAdicionalesModel
    {
        private String nombre = "adicional";
        private String descripcion = "descripcion default";
        private decimal precio = 0;
        private string username;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio { get => precio; set => precio = value; }
        public string Username { get => username; set => username = value; }
    }
}
