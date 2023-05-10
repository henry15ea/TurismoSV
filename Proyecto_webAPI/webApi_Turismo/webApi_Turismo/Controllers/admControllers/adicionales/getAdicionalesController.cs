using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.AdminApi.adicionalesFuncs;
using webApi_Turismo.functions.AdminApi.categoriasFunctions;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.mododelsdb.adicionalesModel;


namespace webApi_Turismo.Controllers.admControllers.adicionales
{
    [ApiController]
    [Route("api/admin/Adicionales/[controller]")]
    public class getAdicionalesController : Controller
    {
        private readonly IConfiguration _configuration;


        public getAdicionalesController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult getAdicional(cUserModel datamodel)
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
                adicionalesFuncs dp = new adicionalesFuncs();
                var dataDB = new List<formasPagoModel>();
                try
                {
                    dataDB = dp.GetCategoriaList();
                    getdata = true;
                }
                catch
                {
                    dataDB.Add(new formasPagoModel
                    {
                        Idadicional = "null",
                        Nombre = "null",
                        Descripcion = "null",
                        Precio = 0,
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
}//end namespace
