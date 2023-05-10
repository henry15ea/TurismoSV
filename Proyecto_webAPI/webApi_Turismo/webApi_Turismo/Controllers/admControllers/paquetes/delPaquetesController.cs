using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.models.customModels;
using webApi_Turismo.functions.AdminApi;

namespace webApi_Turismo.Controllers.admControllers.paquetes
{
    [ApiController]
    [Route("api/admin/paquetes/[controller]")]
    public class delPaquetesController : Controller
    {
        private readonly IConfiguration _configuration;


        public delPaquetesController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult eliminarPaquetes([FromBody] cDeleteModel modelo)
        {
            var dataResp = new
            {
                token_paquete = "null",
                InfoMsg = "null",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            if (modelo == null)
            {
                dataResp = new
                {
                    token_paquete = "null",
                    InfoMsg = "null",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };
                return StatusCode(203, dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 


                paquetesFunc lv = new paquetesFunc();



                if (lv.fn_deletePaquete(modelo) == true)
                {


                    dataResp = new
                    {
                        token_paquete = lv.Id_Generado,
                        InfoMsg = "Se ha eliminado el elemento",
                        ServerApiStatus = "Elemento eliminado con exito Id generado :" + lv.Id_Generado

                    };

                    return StatusCode(201, dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        token_paquete = "null",
                        InfoMsg = "No se ha eliminado elemento",
                        ServerApiStatus = "Hubo un fallo al ingresar datos en el controlador"

                    };
                    return StatusCode(204, dataResp);

                }
            }
        }//fin control
    }//end class
}//end namespaces
