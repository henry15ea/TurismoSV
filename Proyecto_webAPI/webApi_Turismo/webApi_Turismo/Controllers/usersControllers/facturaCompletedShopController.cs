using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions.UsersApi;
using webApi_Turismo.models.customModels;

namespace webApi_Turismo.Controllers.usersControllers
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class facturaCompletedShopController : Controller
    {
        private readonly IConfiguration _configuration;


        public facturaCompletedShopController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult asignar([FromBody] cUpFacturaStateEmited modelo)
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
                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 


                facturaUpdateStatus lv = new facturaUpdateStatus();



                if (lv.fn_updatedFacturaState(modelo) == true)
                {


                    dataResp = new
                    {
                        token_paquete = lv.Id_paqueteGenerado,
                        InfoMsg = "Se ha realizado la compra del paquete reservado",
                        ServerApiStatus = "Todo el proceso de asignacion se ejecuto con ID generado :" + lv.Id_paqueteGenerado

                    };

                    return new OkObjectResult(dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        token_paquete = "null",
                        InfoMsg = "No se pudo generar la compra por falta de elementos o informacion",
                        ServerApiStatus = "Hubo un fallo al ingresar datos en el controlador"

                    };
                    return new OkObjectResult(dataResp);

                }
            }
        }//fin control asignarpaquete
        //end class controller

    }//end class
}//end namespaces
