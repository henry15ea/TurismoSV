using ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace ClienteWeb.Pages.ReporteVBNA
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



            return Page();
        }

        public async Task getr()
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {

                nom = Request.Query["nom"];
                ape = Request.Query["ape"];
                var data = new { username = "develop", nombre= nom, apellido = ape };



                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5119/api/reporte/admin/ventasAdicionalesByNombreApellido", content);

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
        public string nom { get; set; }

        [BindProperty]
        public string ape { get; set; }
    }
}
