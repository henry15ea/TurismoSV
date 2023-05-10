using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.AdminApi;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;

namespace webApi_Turismo.Controllers.admControllers.factura.detalle
{
    [ApiController]
    [Route("api/admin/facturasDet/[controller]")]
    public class getDetalleFacturaController : Controller
    {
        private readonly IConfiguration _configuration;


        public getDetalleFacturaController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult getDetalleFactura(cUserModel datamodel)
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
                detalleFacturaFuncs dp = new detalleFacturaFuncs();
                var dataDB = new List<vDetalleFactura>();
                try
                {
                    dataDB = dp.GetDetalleFacturaList();
                    getdata = true;
                }
                catch
                {
                    dataDB.Add(new vDetalleFactura
                    {
                        Id_registro = "null",
                        Id_factura = "null",
                        Paquete = "null",
                        Descripcion = "null",
                        Direccion = "null",
                        Img = "null",
                        Precio = 0,
                        Descuento = 0,
                        Monto = 0,
                        Total = 0,
                        Cupos_reservados = 0,
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
