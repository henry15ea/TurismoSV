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
    public class DepartamentosController : Controller
    {
        private readonly IConfiguration _configuration;


        public DepartamentosController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpGet]
        public IActionResult departamentos() {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            dapartamentList dp = new dapartamentList();
            var departamentos = new List<departamentosModel>();
            try {
                departamentos = dp.GetDepartamentList();
                getdata = true;
            } catch { 
                departamentos.Add(new departamentosModel { 
                    Iddepartamento = "none",
                    Nombre = "null",
                });
                getdata = false;
            }


            if (getdata == false)
            {
                var jsonResult = JsonConvert.SerializeObject(departamentos);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Datos departamentos no generados",
                    ServerApiStatus = "No se pudo obtener los datos de los departamentos.",


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
                    InfoMsg = "Mostrando los datos de departamentos",
                    ServerApiStatus = "Datos departamentos generado correctamente.",


                };



                return new OkObjectResult(dataResp);


            }
        }
        //fin control
    }
}
