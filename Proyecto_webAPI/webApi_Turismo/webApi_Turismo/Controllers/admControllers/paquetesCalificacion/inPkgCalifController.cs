using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions.AdminApi;
using webApi_Turismo.models.customModels;

namespace webApi_Turismo.Controllers.admControllers.paquetesCalificacion
{
    [ApiController]
    [Route("api/admin/paquetesCalif/[controller]")]
    public class inPkgCalifController : Controller
    {
        private readonly IConfiguration _configuration;


        public inPkgCalifController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult nuevoPkgCalif([FromBody] cInPaqueteCalificacion modelo)
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


                paqueteCalificacionFuncs lv = new paqueteCalificacionFuncs();



                if (lv.fn_nuevaPkgNota(modelo) == true)
                {


                    dataResp = new
                    {
                        token_paquete = lv.Id_Generado,
                        InfoMsg = "Se ha creado un nuevo elemento",
                        ServerApiStatus = "Elemento creado con exito Id generado :" + lv.Id_Generado

                    };

                    return StatusCode(201, dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        token_paquete = "null",
                        InfoMsg = "No se ha creado un nuevo elemento",
                        ServerApiStatus = "Hubo un fallo al ingresar datos en el controlador"

                    };
                    return StatusCode(204, dataResp);

                }
            }
        }//fin control nuevacategoria
        //end class controller
    }//end class
}//end namespaces
