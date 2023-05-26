using ClienteWeb.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TurismoSV_client.models.UserModel;
using System.Data.SqlClient;

namespace ClienteWeb.Pages.Inicio
{
    public class IndexModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            
            sesion = HttpContext.Session.GetString("usuario");
            rol = HttpContext.Session.GetString("rol");

           
            if (sesion == null || sesion == "")
            {
                return RedirectToPage("/Index");
            }

           

            return Page();
        }

        public string sesion { get; set; } = "";
        public string rol = "";

        [BindProperty]
        public bool chk { get; set; }

        public void OnPost(string[][] nombre)
        {
                    
                texto = nombre[0].Length + " " ;

           
        }

        public string texto = "";






    }
}
