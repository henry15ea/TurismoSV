using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.AdminApi;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;

namespace webApi_Turismo.Controllers.admControllers.personasExtras
{
    [ApiController]
    [Route("api/admin/personasExtras/[controller]")]
    public class getPersonasExtrasController : Controller
    {
        private readonly IConfiguration _configuration;


        public getPersonasExtrasController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult getPersonasExtra(cUserModel datamodel)
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
                personasExtrasFuncs dp = new personasExtrasFuncs();
                var dataDB = new List<vPersonasExtrasExt>();
                try
                {
                    dataDB = dp.GetPersonaExtraList();
                    getdata = true;
                }
                catch
                {
                    dataDB.Add(new vPersonasExtrasExt
                    {
                        Id_registro = "null",
                        Invitado = "null",
                        N_documento = "null",
                        Edad = 0,
                        Cuenta_titular = "null",
                        Titular = "null",
                        Correo = "null",
                        Telefono = "null",
                        Paquete = "null",
                        Registro = "null",
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
    }//end class
}//end namespaces
