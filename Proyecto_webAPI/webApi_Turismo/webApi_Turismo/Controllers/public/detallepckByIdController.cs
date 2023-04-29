using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.basedView.paquetesDisp;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.dapartamentList;
using webApi_Turismo.models;
using webApi_Turismo.models.customModels.cpaquetesModel;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class detallepckByIdController : Controller
{
        private readonly IConfiguration _configuration;
        public detallepckByIdController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult paquetesDisponibles(cpaquetesModel detalle)
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
            detallePaqueteModel modelo = new detallePaqueteModel();
            var paquetes = new List<detallePaqueteModel>();

            try
            {
                modelo.Idpaqueted = detalle.Idpaqueted.ToString().Trim();
                paquetes = dp.GetPaquetesDisponiblesByIDList(modelo);
                getdata = true;
            }
            catch
            {
                paquetes.Add(new detallePaqueteModel
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
                    Estado = false
                });
                getdata = false;
            }


            if (getdata == false)
            {
                var jsonResult = JsonConvert.SerializeObject(paquetes);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Datos paquetes no generados",
                    ServerApiStatus = "No se pudo obtener los datos de los paquetes.",


                };



                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                var jsonResult = JsonConvert.SerializeObject(paquetes);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Mostrando los datos de paquetes",
                    ServerApiStatus = "Datos paquetes generado correctamente.",


                };



                return new OkObjectResult(dataResp);


            }
        }
        //fin control

        //end control class
    }
}