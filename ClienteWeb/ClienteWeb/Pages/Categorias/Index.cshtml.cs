using ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;


namespace ClienteWeb.Pages.Categorias
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


            using (var HttpClient = new HttpClient())
            {
                pruebaList= null;
                //var respuesta = await HttpClient.GetAsync("https://jsonplaceholder.typicode.com/posts");
                var respuesta = await HttpClient.GetAsync("http://localhost:5119/api/public/categorias");
                texto = await respuesta.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(texto);
                texto2 = responseObject.data;
                categorias = JsonConvert.DeserializeObject<List<MCategorias>>(texto2);

                //texto= await response.Content.ReadAsStringAsync();

                texto = "";

                //texto = TempData["dato"] as string;
                // Utiliza el valor de 'dato' aquí
                texto = HttpContext.Session.GetString("usuario");
                return Page();


            }
            
            return Page();

        }

        public async Task getr()
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                var data = new { username = "develop" };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5119/api/reporte/admin/listadoUsuarios", content);

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

                }
            }
        }

 

        public string texto = "";

        public string texto2 = "";

        public List<Prueba>? pruebaList;

        public List<MCategorias>? categorias=null;

        public string sesion { get; set; } = "";
        public string rol { get; set; } = "";

        public MemoryStream ms;



    }
}
