using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions.AdminApi.categoriasFunctions;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.mododelsdb.categoriasModel;

namespace webApi_Turismo.Controllers.admControllers.categorias
{
    [ApiController]
    [Route("api/admin/categorias/[controller]")]
    public class getCategoriasController : Controller
    {
        private readonly IConfiguration _configuration;


        public getCategoriasController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult getCategorias(cUserModel datamodel)
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
                formasPago dp = new formasPago();
                var dataDB = new List<categoriasModel>();
                try
                {
                    dataDB = dp.GetCategoriaList();
                    getdata = true;
                }
                catch
                {
                    dataDB.Add(new categoriasModel
                    {
                        Idcategoria = "null",
                        Nombre = "null",
                        Descripcion = "null",
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
            else {
                return StatusCode(401, dataResp);
                
            }
        }
        //end funct
    }
    //end class
}
//end namespace
