using ClienteWeb.Modelos;
using ClienteWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;

namespace ClienteWeb.Pages.ReporteADPIDP
{
    public class IndexModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            sesion = HttpContext.Session.GetString("usuario");
            rol = HttpContext.Session.GetString("rol");
            await getr();

            if (sesion == null || sesion == "")
            {
                return RedirectToPage("/Index");
            }

            string connectionString = Conexion.cadena;
            string query = "select idpaqueted,nombre from paquetesdisponible as pd inner join paquetes as p on pd.idpaquete=p.idpaquete";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Crear un comando SQL con la consulta y la conexión
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Ejecutar la consulta y obtener un lector de datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Recorrer los resultados
                        while (reader.Read())
                        {
                            // Acceder a los valores de las columnas por su nombre o índice

                            diccionario.Add(reader["idpaqueted"].ToString(), reader["nombre"].ToString());
                            

                            // Hacer algo con los datos obtenidos
                            //Console.WriteLine(correo);
                        }
                    }
                }
            }



            return Page();
        }

        public async Task getr()
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {

                opcion = Request.Query["opcion"];
                
                var data = new { username = "develop", id_paquete = opcion };



                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5119/api/reporte/admin/adicionalesDisponiblesIdPkg", content);

                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                    var result = await response.Content.ReadAsByteArrayAsync();
                    var memoryStream = new MemoryStream(result);
                    ms = memoryStream;


                }
                else
                {
                    ms = null;
                }

            }
        }



        public string sesion { get; set; } = "";
        public string rol = "";
        public MemoryStream ms = null;
        public Dictionary<string, string> diccionario = new Dictionary<string,string>();

        [BindProperty]
        public string opcion { get; set; }

    }
}
