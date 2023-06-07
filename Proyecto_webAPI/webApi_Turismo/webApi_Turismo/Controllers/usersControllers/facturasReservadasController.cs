using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.UsersApi;
using webApi_Turismo.models;
using webApi_Turismo.models.vistaModels;

namespace webApi_Turismo.Controllers.usersControllers
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class facturasReservadasController : Controller
    {

        private readonly IConfiguration _configuration;


        public facturasReservadasController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult listadoFacturasReservadas([FromBody] generalModel modelo)
        {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            facturasReservadasFuncs dp = new facturasReservadasFuncs();
            var dataInfo = new List<vFacturaEmitidaByUsuarioModel>();
            try
            {
                dataInfo = dp.GetFacuraEmitidabyUserList(modelo);
                getdata = true;
            }
            catch
            {
                dataInfo.Add(new vFacturaEmitidaByUsuarioModel
                {
                    Id_factura = "null",
                    Paquete = "null",
                    Pasarela = "null",
                    Descuento = "null",
                    Monto = "null",
                    Total = "null",
                    Cupos = "null",
                    Usuario = "null",
                    Estado = "null",
                });
                getdata = false;
            }


            if (getdata == false)
            {
                var jsonResult = JsonConvert.SerializeObject(dataInfo);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Informacion solicitada no disponible",
                    ServerApiStatus = "No se encontro datos de acuerdo a los parametros recividos",


                };



                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                var jsonResult = JsonConvert.SerializeObject(dataInfo);

                dataResp = new
                {
                    data = jsonResult,
                    InfoMsg = "Mostrando los datos obtenidos",
                    ServerApiStatus = "Datos generado correctamente.",


                };



                return new OkObjectResult(dataResp);


            }
        }
        //fin clase control
    }
}
