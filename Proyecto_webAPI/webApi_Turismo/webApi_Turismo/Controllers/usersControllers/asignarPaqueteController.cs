using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.dapartamentList;
using webApi_Turismo.functions.UsersApi.paquetesUsuario;
using webApi_Turismo.models;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.encabezadoModel;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers.usersControllers
{

    [ApiController]
    [Route("api/user/[controller]")]
    public class asignarPaqueteController : Controller
    {
        private readonly IConfiguration _configuration;


        public asignarPaqueteController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult asignar([FromBody] encabezadoModel modelo)
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


                paquetesUsuario lv = new paquetesUsuario();

                if (lv.NuevoEncabezado(modelo) == true)
                {
                    
                   
                    dataResp = new
                    {
                        token_paquete = lv.Id_paqueteGenerado,
                        InfoMsg = "Se ha creado una nueva asignacion de paquete",
                        ServerApiStatus = "Todo el proceso de asignacion se ejecuto con ID generado :"+lv.Id_paqueteGenerado

                    };

                    return new OkObjectResult(dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        token_paquete = "null",
                        InfoMsg = "No se pudo generar la asignacion por falta de elementos o informacion",
                        ServerApiStatus = "Hubo un fallo al ingresar datos en el controlador"

                    };
                    return new OkObjectResult(dataResp);

                }
            }
        }//fin control asignarpaquete
        //end class controller
    }
}
