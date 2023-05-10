using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions.AdminApi.categoriasFunctions;
using webApi_Turismo.models.customModels;

namespace webApi_Turismo.Controllers.admControllers.categorias
{
    [ApiController]
    [Route("api/admin/categorias/[controller]")]
    public class delCategoriaController : Controller
    {
        private readonly IConfiguration _configuration;


        public delCategoriaController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        [HttpPost]
        public IActionResult eliminarCategoria([FromBody] cDeleteModel modelo)
        {
            var dataResp = new
            {
                token_paquete = "null",
                InfoMsg = "null",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            if (modelo == null)
            {
                dataResp = new
                {
                    token_paquete = "null",
                    InfoMsg = "null",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };
                return StatusCode(203, dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 


                formasPago lv = new formasPago();



                if (lv.fn_deleteCategoria(modelo) == true)
                {


                    dataResp = new
                    {
                        token_paquete = lv.Id_Generado,
                        InfoMsg = "Se ha eliminado el elemento",
                        ServerApiStatus = "Elemento eliminado con exito Id generado :" + lv.Id_Generado

                    };

                    return StatusCode(201, dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        token_paquete = "null",
                        InfoMsg = "No se ha eliminado elemento",
                        ServerApiStatus = "Hubo un fallo al ingresar datos en el controlador"

                    };
                    return StatusCode(204, dataResp);

                }
            }
        }//fin control
    }
}
