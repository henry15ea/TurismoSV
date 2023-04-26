using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.models;
using webApi_Turismo.models.AccountAndUserModel;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.cuentaModel;
using webApi_Turismo.models.mododelsdb.UsuarioModel;
using webApi_Turismo.utils.cls_tokenGenerator;
namespace webApi_Turismo.Controllers
{
    [ApiController]
    [Route("api/public/[controller]")]
    public class newuserController : Controller
    {

        private readonly IConfiguration _configuration;


        public newuserController(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        [HttpPost]
        public IActionResult NewUser([FromBody] AccountAndUserModel modelo)
        {
            var dataResp = new
            {
                InfoMsg = "null",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };

            //verificando si el usuario existe en la db
            if (modelo == null)
            {
                dataResp = new
                {

                    InfoMsg = "Datos no recividos",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };
                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 


                CreateNewUser cd = new CreateNewUser();
                UsuarioModel umd = new UsuarioModel();

               

                //definiendo datos de usuario 
                umd.Idusuario = "";
                umd.Nombre = modelo.Nombre;
                umd.Apellido = modelo.Apellido;
                umd.Edad = modelo.Edad;
                umd.Telefono = modelo.Telefono;
                umd.Direccion = modelo.Direccion;
                umd.Correo = modelo.Correo;
                umd.Id_rol = modelo.Id_rol;
                umd.Estado = modelo.Estado;

                


                if (cd.NewUser(umd) == true)
                {
                    cuentaModel ct = new cuentaModel();

                    //definiendo datos de la cuenta de usuario registrado 
                    ct.Id_usuario = cd.Id_ususer;
                    ct.U_name = modelo.U_name;
                    ct.U_pass = modelo.U_pass;

                    if (cd.NewUserAccount(ct) == true) {
                        dataResp = new
                        {
                            InfoMsg = "Usuario registrado correctamente",
                            ServerApiStatus = "Usuario registrado correctamente "

                        };

                        return new OkObjectResult(dataResp);
                    }
                    else{

                        dataResp = new
                        {
                            InfoMsg = "Fallo al crear la cuenta de usuario",
                            ServerApiStatus = "Hubo un error al crear la cuenta de usuario. "

                        };

                        return new OkObjectResult(dataResp);
                    }

                }
                else
                {

                    dataResp = new
                    {
                        InfoMsg = "Los datos enviados no son validos ",
                        ServerApiStatus = "Se recivieron datos correctos , verificacion de usuario o clave invalida"

                    };
                    return new OkObjectResult(dataResp);

                }
            }
        }//en controller post

    }//end class controller
}//end namespace
