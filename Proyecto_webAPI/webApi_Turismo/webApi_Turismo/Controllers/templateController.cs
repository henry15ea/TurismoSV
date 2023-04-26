using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace webApi_Turismo.Controllers
{
    /*
    [Route("api/[controller]")]
    [ApiController]
    public class templateController : ControllerBase {


        private readonly IConfiguration _configuration;


        public templateController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult LoginUser(String usuario, String clave)
        {
            var dataResp = new
            {
                user = "null",
                token_id = "null",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            if (usuario == null || clave == null)
            {
                dataResp = new
                {
                    user = "null",
                    token_id = "null",
                    InfoMsg = "Datos no recividos",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };

                return Json(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 

            }
        }//fin control LoginUser

    }*/
}
