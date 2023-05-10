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
using webApi_Turismo.models.customModels.cAdicionalesModel;
using webApi_Turismo.models.customModels;
using webApi_Turismo.functions.AdminApi;

namespace webApi_Turismo.Controllers.admControllers.post
{

    [ApiController]
    [Route("api/admin/adicionalesdisp/[controller]")]
    public class inadicionalesDispController : Controller
    {
        private readonly IConfiguration _configuration;


        public inadicionalesDispController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 
        [HttpPost]
        public IActionResult nuevoAdicionalDisp([FromBody] cadicionalesDisponiblesModel modelo)
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


                adicionalesDisp lv = new adicionalesDisp();



                if (lv.fn_nuevoADicionalDisp(modelo) == true)
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
        }//fin control adicionalesDisp
        //end class controller
    }
}
