using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace ClienteWeb.Pages.ReporteVA
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
                var data = new { username = "develop" };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5119/api/reporte/admin/ventasAdicionales", content);

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

        public string sesion { get; set; } = "";
        public string rol = "";
        public MemoryStream ms = null;

    }
}

