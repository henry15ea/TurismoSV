namespace webApi_Turismo.models.mododelsdb
{
    public class paquetesModel
    {
        String idpaquete;
        String nombre;
        String descripcion;
        String direccion;
        String idmunicipio;
        String idcategoria;
        String img;

        public string Idpaquete { get => idpaquete; set => idpaquete = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Idmunicipio { get => idmunicipio; set => idmunicipio = value; }
        public string Idcategoria { get => idcategoria; set => idcategoria = value; }
        public string Img { get => img; set => img = value; }
    }
}
