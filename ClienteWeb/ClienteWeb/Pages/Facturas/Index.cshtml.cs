using ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Contracts;


namespace ClienteWeb.Pages.Facturas
{
    public class IndexModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            sesion = HttpContext.Session.GetString("usuario");
            rol = HttpContext.Session.GetString("rol");
            correo = HttpContext.Session.GetString("correo");



            if (sesion == null || sesion == "")
            {
                return RedirectToPage("/Index");

            }

            using (var HttpClient = new HttpClient())
            {
                var data = new { username="develop"};
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

                var response = await HttpClient.PostAsync("http://localhost:5119/api/admin/facturasEnc/getEncabezadoF", content);
                
                facturas = await response.Content.ReadAsStringAsync();
                dynamic responseObject = JsonConvert.DeserializeObject(facturas);
                System.Console.WriteLine(responseObject.data);
                string texto = responseObject.data;
                facturaEncabezadoModel=JsonConvert.DeserializeObject<List<facturaEncabezadoModel>>(texto);

                if (rol != "1")
                {
                    facturaEncabezadoModel=facturaEncabezadoModel.Where(p => p.Correo == correo).ToList();
                }

                return Page();


            }

            return Page();


        }
        public async Task<IActionResult> OnPost()
        {
  

   
                  
                TempData["idf"] = idf;

                return RedirectToPage("../ReporteFactura/Index");


            //return Page();
        }

        [BindProperty]
        public string idf { get; set; }

        public string sesion { get; set; } = "";
        public string rol = "";
        public string correo = "";
        public string facturas{ get; set; }

        public List<facturaEncabezadoModel>? facturaEncabezadoModel = null;
    }
}
