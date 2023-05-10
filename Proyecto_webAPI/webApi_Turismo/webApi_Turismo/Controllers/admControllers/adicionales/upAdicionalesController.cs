using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.models.customModels.cAdicionalesModel;
using webApi_Turismo.functions.AdminApi.adicionalesFuncs;
using webApi_Turismo.models.mododelsdb.adicionalesModel;

namespace webApi_Turismo.Controllers.admControllers.adicionales
{
    [ApiController]
    [Route("api/admin/Adicionales/[controller]")]
    public class upAdicionalesController : Controller
    {
        private readonly IConfiguration _configuration;


        public upAdicionalesController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult actualizarAdicional([FromBody] formasPagoModel modelo)
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


                adicionalesFuncs lv = new adicionalesFuncs();



                if (lv.fn_updatedAdicional(modelo) == true)
                {


                    dataResp = new
                    {
                        token_paquete = lv.Id_Generado,
                        InfoMsg = "Se ha actualizado un elemento",
                        ServerApiStatus = "Elemento actualizado con exito Id generado :" + lv.Id_Generado

                    };

                    return StatusCode(201, dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        token_paquete = "null",
                        InfoMsg = "No se ha actualizado elemento",
                        ServerApiStatus = "Hubo un fallo al ingresar datos en el controlador"

                    };
                    return StatusCode(204, dataResp);

                }
            }
        }//fin control actualizar elemento
        //end class controller
    }
}
