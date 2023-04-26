using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.basedView.adicionalesDispAll;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.dapartamentList;
using webApi_Turismo.models;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.vistaModels.vadicionalesModel;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers
{

        [ApiController]
        [Route("api/public/[controller]")]
        public class adicionalesPaqueteController : Controller
        {
            private readonly IConfiguration _configuration;


            public adicionalesPaqueteController(IConfiguration configuration)
            {
                _configuration = configuration;

            }
            //funciones que retornan un valor 

            [HttpGet]
            public IActionResult adicionales()
            {
                bool getdata = false;
                var dataResp = new
                {
                    data = "",
                    InfoMsg = "Datos no recividos",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };

            //verificando si el usuario existe en la db
                adicionalesDispAll dp = new adicionalesDispAll();
                var adicionales = new List<vadicionalesModel>();
                try
                {
                    adicionales = dp.GetAdicionalesAllList();
                    getdata = true;
                }
                catch
                {
                    adicionales.Add(new vadicionalesModel
                    {
                        Id_adicional = "null",
                        Id_paquete = "null",
                        Nmb_paquete = "null",
                        Nmb_adicional = "null",
                        Dsc_adicional = "null",
                        Precio_adicional = 0,
                    });
                    getdata = false;
                }


                if (getdata == false)
                {
                    var jsonResult = JsonConvert.SerializeObject(adicionales);

                    dataResp = new
                    {
                        data = jsonResult,
                        InfoMsg = "Datos adicionales no generados",
                        ServerApiStatus = "No se pudo obtener los datos de los adicionales.",


                    };



                    return new OkObjectResult(dataResp);
                }
                else
                {
                    //se han recibido datos asi que verificamos si el usuario existe 
                    var jsonResult = JsonConvert.SerializeObject(adicionales);

                    dataResp = new
                    {
                        data = jsonResult,
                        InfoMsg = "Mostrando los datos de adicionales",
                        ServerApiStatus = "Datos adicionales generado correctamente.",


                    };



                    return new OkObjectResult(dataResp);


                }
            }
            //fin control
        }
    }
