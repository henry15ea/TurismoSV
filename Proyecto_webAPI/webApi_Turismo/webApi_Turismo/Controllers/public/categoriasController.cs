using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.categoriasList;
using webApi_Turismo.functions.publicDataApi.dapartamentList;
using webApi_Turismo.models;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.categoriasModel;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class categoriasController : Controller
    {
        private readonly IConfiguration _configuration;


        public categoriasController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor
        [HttpGet]
        public IActionResult categorias()
        {
            bool getdata = false;
            var dataResp = new
            {
                data = "",
                InfoMsg = "Datos no recividos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            categoriasList dp = new categoriasList();
            var departamentos = new List<categoriasModel>();
            try
            {
                departamentos = dp.GetCategoriasList();
                getdata = true;
            }
            catch
            {
                departamentos.Add(new categoriasModel
                {
                    Idcategoria = "null",
                    Nombre = "null",
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
                    InfoMsg = "Datos categorias no generados",
                    ServerApiStatus = "No se pudo obtener los datos de los categorias.",


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
        //fin clase control
    }
}
