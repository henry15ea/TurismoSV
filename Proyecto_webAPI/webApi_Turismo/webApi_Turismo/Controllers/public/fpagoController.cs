using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.formaPagoList;
using webApi_Turismo.models;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class fpagoController : Controller
    {
        private readonly IConfiguration _configuration;


        public fpagoController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpGet]
        public IActionResult formapago()
        {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            formaPagoList dp = new formaPagoList();
            var departamentos = new List<formasPagoModel>();
            try
            {
                departamentos = dp.GetFormaPagoList();
                getdata = true;
            }
            catch
            {
                departamentos.Add(new formasPagoModel
                {
                    Idformapago = "null",
                    Metodopago = "null",
                    Descripcion = "null",
                });
                getdata = false;
            }


            if (getdata == false)
            {
                var jsonResult = JsonConvert.SerializeObject(departamentos);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Datos forma pago generados",
                    ServerApiStatus = "No se pudo obtener los datos de los forma pago.",


                };



                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                var jsonResult = JsonConvert.SerializeObject(departamentos);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Mostrando los datos de forma pago",
                    ServerApiStatus = "Datos forma pago generado correctamente.",


                };



                return new OkObjectResult(dataResp);


            }
        }

        //fin controller
    }
}
