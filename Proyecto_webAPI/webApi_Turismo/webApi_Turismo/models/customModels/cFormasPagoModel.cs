namespace webApi_Turismo.models.customModels
{
    public class cFormasPagoModel
    {
  
        String metodopago;
        String descripcion;
        String username;
        Boolean estado;


        public string Metodopago { get => metodopago; set => metodopago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Username { get => username; set => username = value; }
        public bool Estado { get => estado; set => estado = value; }
    }
}
