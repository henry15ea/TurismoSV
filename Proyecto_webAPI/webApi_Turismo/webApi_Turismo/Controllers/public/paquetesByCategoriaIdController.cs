using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.basedView.paquetesDisp;
using webApi_Turismo.models;
using webApi_Turismo.models.vistaModels;

namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class paquetesByCategoriaIdController : Controller
    {
        private readonly IConfiguration _configuration;


        public paquetesByCategoriaIdController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult adicionales([FromBody] generalModel id)
        {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            paquetesDisp dp = new paquetesDisp();
            var adicionales = new List<detallePaqueteModel>();
            try
            {
                adicionales = dp.GetPaquetesDisponiblesByCategoryList(id);
                getdata = true;
            }
            catch
            {
                adicionales.Add(new detallePaqueteModel
                {
                    Idpaqueted = "null",
                    Nombre = "null",
                    Descripcion = "null",
                    Direccion = "null",
                    Img = "null",
                    Precio = 0,
                    Cupos_disp = "0",
                    Cuposllenos = "0",
                    Fechafinal = DateTime.Now,
                    Fechainicial = DateTime.Now,
                    Fechreg = DateTime.Now,
                    Estado = false
                });
                getdata = false;
            }


            if (getdata == false)
            {
                var jsonResult = JsonConvert.SerializeObject(adicionales);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "No se pudo generar la informacion solicitada",
                    ServerApiStatus = "No Se han obtenido la informacion solicitada",


                };



                return StatusCode(203,dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                var jsonResult = JsonConvert.SerializeObject(adicionales);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Mostrando la informacion solicitada",
                    ServerApiStatus = "Se han obtenido la informacion solicitada",


                };



                return StatusCode(200,dataResp);


            }
        }
        //fin control
    }//end class
}//end namespaces
