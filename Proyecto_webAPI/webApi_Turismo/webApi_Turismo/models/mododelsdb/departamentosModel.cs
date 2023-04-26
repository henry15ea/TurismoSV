namespace webApi_Turismo.models.mododelsdb
{
    public class departamentosModel
    {
        private String iddepartamento;
        private string nombre;

        public string Iddepartamento { get => iddepartamento; set => iddepartamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        /*
        public departamentosModel(string iddepartamento, string nombre)
        {
            this.Iddepartamento = iddepartamento;
            this.Nombre = nombre;
        }
        */
    }
}
