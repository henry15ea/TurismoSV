using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.AdminApi;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.mododelsdb;

namespace webApi_Turismo.Controllers.admControllers.adicionalesdisp
{
    [ApiController]
    [Route("api/admin/adicionalesdisp/[controller]")]
    public class getAdicionalesDispController : Controller
    {
        private readonly IConfiguration _configuration;


        public getAdicionalesDispController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult getAdicionaldisp(cUserModel datamodel)
        {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            if (datamodel != null)
            {
                //start data
                //verificando si el usuario existe en la db
                adicionalesDisp dp = new adicionalesDisp();
                var dataDB = new List<adicionalesDisponiblesModel>();
                try
                {
                    dataDB = dp.GetAdicionalesDispList();
                    getdata = true;
                }
                catch
                {
                    dataDB.Add(new adicionalesDisponiblesModel
                    {
                        Idadicionald = "null",
                        Idadicional = "null",
                        Idpaqueted = "null",
                    });
                    getdata = false;
                }


                if (getdata == false)
                {
                    var jsonResult = JsonConvert.SerializeObject(dataDB);

                    dataResp = new
                    {
                        data = jsonResult,
                        InfoMsg = "Datos forma pago generados",
                        ServerApiStatus = "No se pudo obtener los datos de los forma pago.",


                    };



                    return StatusCode(204, dataResp);
                }
                else
                {
                    //se han recibido datos asi que verificamos si el usuario existe 
                    var jsonResult = JsonConvert.SerializeObject(dataDB);

                    dataResp = new
                    {
                        data = jsonResult,
                        InfoMsg = "Mostrando Datos obtenidos.",
                        ServerApiStatus = "Se ha solicitado informacion de la base de datos",


                    };
                    return StatusCode(200, dataResp);

                    //end data 
                }

            }
            else
            {
                return StatusCode(401, dataResp);

            }
        }
        //end funct
    }
}
