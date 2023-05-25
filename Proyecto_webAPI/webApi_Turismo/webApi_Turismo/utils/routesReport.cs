using webApi_Turismo.models.modelsUtils;

namespace webApi_Turismo.utils
{
    //esta clase es necesaria para establecer las rutas de los reportes 
    public class routesReport
    {
        public static List<String> routes;

        public routesReport() 
        {
            routes = new List<String>();
            Routes.Add("\\reports\\demo.frx");
            Routes.Add("\\reports\\factura_report.frx");
            Routes.Add("\\reports\\listado_usuarios.frx");
            Routes.Add("\\reports\\ListadoPaquetes.frx");
            Routes.Add("\\reports\\listadoAdicionalesByNombre.frx");
            Routes.Add("\\reports\\ListadoCategorias.frx");
            Routes.Add("\\reports\\ListadoAdicionalesDispByPaquete.frx");
            Routes.Add("\\reports\\PaquetesDisponibles.frx");
            Routes.Add("\\reports\\ListadoUsuariosAll.frx");

        }

        public List<String> GetRoutes() { 
            return routes;
        }

        public static List<string> Routes { get => routes; set => routes = value; }
    }
}
