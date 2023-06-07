using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.cls_tokenGenerator;


namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class longinController : Controller
    {
        private readonly IConfiguration _configuration;

        
        public longinController(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        [HttpPost]
        public IActionResult LoginUser([FromBody] UserModel modelo)
        {
            var dataResp = new
            {
                user = "null",
                token_id = "null",
                mail = "null",
                role_user = "null",
                InfoMsg = "null",
                accesLogin = "none",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            if (modelo.Usuario == null || modelo.Clave == null)
            {
                dataResp = new
                {
                    user = "null",
                    token_id = "null",
                    mail = "null",
                    role_user = "null",
                    InfoMsg = "Datos no recividos",
                    accesLogin = "none",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };
                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                string username = modelo.Usuario.Trim();
                string password = modelo.Clave.Trim();

                LoginVerify lv = new LoginVerify();

                if (lv.fn_loginVerify(username, password) == true)
                {
                    cuentaDetalle user = new cuentaDetalle();
                    cls_tokenGenerator tkn = new cls_tokenGenerator();
                    usuarioDataInfo vd = new usuarioDataInfo();

                    user = vd.GetUserAccountDetailsByUserName(username);



                    String token = tkn.fn_tokenBuilder(username, password);

                    dataResp = new
                    {
                        user = username.ToString(),
                        token_id = token,
                        mail = user.Correo,
                        role_user = ""+ user.Id_rol,
                        InfoMsg = "Bienvenido al sistema " + username,
                        accesLogin = "ok",
                        ServerApiStatus = "El usaurio y clave son correctos "

                    };

                    return new OkObjectResult(dataResp);

                }
                else
                {

                    dataResp = new
                    {
                        user = "null",
                        token_id = "null",
                        mail = "null",
                        role_user = "null",
                        InfoMsg = "Usuario o constraseña invalidos ",
                        accesLogin = "none",
                        ServerApiStatus = "Se recivieron datos correctos , verificacion de usuario o clave invalida"

                    };
                    return new OkObjectResult(dataResp);

                }
            }
        }//fin control LoginUser




    }//fin class
}
//fin namespace
