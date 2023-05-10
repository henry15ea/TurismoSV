namespace webApi_Turismo.models.customModels
{
    public class cUpFPagoModel
    {
        String idformapago;
        String metodopago;
        String descripcion;
        Boolean estado;
        String username;

        public string Idformapago { get => idformapago; set => idformapago = value; }
        public string Metodopago { get => metodopago; set => metodopago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public bool Estado { get => estado=false; set => estado = value; }
        public string Username { get => username; set => username = value; }
    }
}
