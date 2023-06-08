using ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace ClienteWeb.Pages.ReporteFPago
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
                var data = new { username = "develop" };



                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var respuesta = await HttpClient.PostAsync("http://localhost:5119/api/admin/fpago/getFpago",content);
                string texto = await respuesta.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(texto);
                string texto2 = responseObject.data;
                formaspago = JsonConvert.DeserializeObject<List<MFormaPago>>(texto2);

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
                
                var data = new { username = "develop", filtro = opcion };



                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync("http://localhost:5119/api/reporte/admin/ventasAdicionalesByFpago", content);

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
        public List<MFormaPago> formaspago;

        [BindProperty]
        public string opcion { get; set; }

        [BindProperty]
        public string cantidad { get; set; }
    }
}
