using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.dapartamentList;
using webApi_Turismo.models;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class municipioController : Controller
    {
        private readonly IConfiguration _configuration;


        public municipioController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 
        [HttpGet]
        public IActionResult departamentos()
        {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            municipioList mn = new municipioList();
            var municipios = new List<municipiosModel>();
            try
            {
                municipios = mn.GetMunicipiosList();
                getdata = true;
            }
            catch
            {
                municipios.Add(new municipiosModel
                {
                    Idmunicipio = "null",
                    Nombre = "null",
                    Iddepartamento = "null",
                });
                getdata = false;
            }


            if (getdata == false)
            {
                var jsonResult = JsonConvert.SerializeObject(municipios);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Datos municipios no generados",
                    ServerApiStatus = "No se pudo obtener los datos de los municipios.",


                };



                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                var jsonResult = JsonConvert.SerializeObject(municipios);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Mostrando los datos de municipios",
                    ServerApiStatus = "Datos municipios generado correctamente.",


                };



                return new OkObjectResult(dataResp);


            }
        }

    }
}
