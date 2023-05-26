using ClienteWeb.Modelos;
using ClienteWeb.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Text;



namespace ClienteWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        [BindProperty]
        public string usuario { get; set; }

        [BindProperty]
        public string contra { get; set; }
        public void OnGet()
        {

        }
        public string texto = "";
        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                LoginResponseModel md = new LoginResponseModel();
                await fn_loginUser(usuario, contra);
                md = GetDataAPI();

                texto = md.role_user;
                if(md.role_user != null && md.role_user!="0")
                {
                    string dato = "ejemplo";
                    TempData["dato"] = dato;

                    HttpContext.Session.SetString("usuario", md.user);
                    HttpContext.Session.SetString("rol", md.role_user);

                    string connectionString = Conexion.cadena;
                    string query = "select correo from usuarios as u inner join cuenta as c on u.idusuario=c.id_usuario where c.u_name='" + usuario + "'";
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

                                    string correo = reader["correo"].ToString();
                                    HttpContext.Session.SetString("correo",correo);


                                    // Hacer algo con los datos obtenidos
                                    Console.WriteLine(correo);
                                }
                            }
                        }
                    }

                    return RedirectToPage("Inicio/Index");
                }
            }

            

            return Page();
        }

        private String _responseJson;
        RoutesApi rt = new RoutesApi();
        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_loginUser(String username, String password)
        {
            bool resp = false;
            String uname = username.Trim();
            String pass = password.Trim();

            if (uname == null || pass == null)
            {
                //se ha recivido elementos vacios 
                return false;
            }
            else
            {
                //trabajando con los datos recividos
                var httpClient = new HttpClient();


                string apiAddress = RoutesApi.GetRoute("login");

                using (httpClient)
                {
                    var data = new { usuario = uname, clave = password };

                    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(apiAddress, content);

                    //reviso el status code que trae la api
                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                        var result = await response.Content.ReadAsStringAsync();
                        _responseJson = result;
                        // manejar la respuesta exitosa aquí
                        return true;
                    }
                    else
                    {
                        //no se obtuvo el resultado esperado 
                        return resp;
                    }
                }
            }
        }//fin fn_IsloggedIn

        public LoginResponseModel GetDataAPI()
        {
            return JsonConvert.DeserializeObject<LoginResponseModel>(_responseJson);

        }


    }
}