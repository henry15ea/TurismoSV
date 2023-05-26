using ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace ClienteWeb.Pages.ReporteAdPaquetes
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


                var respuesta = await HttpClient.GetAsync("http://localhost:5119/api/public/categorias");
                string texto = await respuesta.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(texto);
                string texto2 = responseObject.data;
                categorias = JsonConvert.DeserializeObject<List<MCategorias>>(texto2);

                return Page();


            }

            return Page();
        }

        public async Task getr()
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {

                opcion = Request.Query["opcion"];
                cantidad = Request.Query["cantidad"];
                var data = new { username = "develop", nombreAdicional="" };



                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5119/api/reporte/admin/listadoAdicionales", content);

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
        public List<MCategorias> categorias;

        [BindProperty]
        public string opcion { get; set; }

        [BindProperty]
        public string cantidad { get; set; }
    }
}
