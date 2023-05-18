using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using webApi_Turismo.functions;
using webApi_Turismo.functions.basedView.paquetesDisp;
using webApi_Turismo.functions.LoginVerify;
using webApi_Turismo.functions.publicDataApi.dapartamentList;
using webApi_Turismo.functions.UsersApi.paquetesUsuario;
using webApi_Turismo.models;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.detalleFacturaModel;
using webApi_Turismo.models.mododelsdb.personasExtrasModel;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.utils.cls_tokenGenerator;

namespace webApi_Turismo.Controllers.usersControllers
{
    [ApiController]
    [Route("api/user/[controller]")]
    public class integrantesExtrasController : Controller
    {

        private readonly IConfiguration _configuration;


        public integrantesExtrasController(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        //funciones que retornan un valor 

        protected Boolean fn_DisponibilidadPaquete(int NumInvitados, String id_paquete) {
           

            try {
                paquetesDisp pkgDisp = new paquetesDisp();
                detallePaqueteModel dtpkg = new detallePaqueteModel();
                List<detallePaqueteModel> dataInfo;

                dtpkg.Idpaqueted = id_paquete.Trim();
                
                dataInfo = pkgDisp.GetPaquetesDisponiblesByIDList(dtpkg);

                int disp = int.Parse(dataInfo[0].Cupos_disp);

                int CuposLimite = int.Parse(dataInfo[0].Cuposllenos);

                if (disp > NumInvitados)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch (Exception e) {
                return false;
            }

        }

        [HttpPost]
        public IActionResult asignar([FromBody] List<cInPersonasExtrasUser> modelo)
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
                    InfoMsg = "null",
                    ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

                };
                return new OkObjectResult(dataResp);
            }
            else
            {
                //se han recibido datos asi que verificamos si el usuario existe 
                


                paquetesUsuario lv = new paquetesUsuario();

                if (fn_DisponibilidadPaquete(modelo.Count, modelo[0].Id_paquete)==true) {
                    //asignar lista de invitados 
                    cInPersonasExtrasUser dataIter = new cInPersonasExtrasUser();
                    int invitadosRegistrados = 0;

                    for (int iter = 0; iter < modelo.Count; iter++) {
                        //comenzamos a agregar invitados a la db 
                        dataIter = modelo[iter];

                        if (fn_DisponibilidadPaquete(modelo.Count, modelo[0].Id_paquete) == true)
                        {
                            //ingresar invitado

                            if (lv.PersonasExtras(dataIter) == true)
                             {
                                 invitadosRegistrados++;
                             }
                            
                            //fin ingresar invitado
                        }
                        else {
                            break;
                        }
                     }

                    dataResp = new
                    {
                        InfoMsg = "Se ha registrado la lista de invitados",
                        ServerApiStatus = "El proceso de ingreso de invitados , se ha completado con "

                    };
                    return StatusCode(200, dataResp);


                    //fin asignacion de invitados 

                } else {
                    dataResp = new
                    {
                        InfoMsg = "No se pueden agregar usuarios Debido a que supera el limite de cupos",
                        ServerApiStatus = "No se puede asignar debido a que no hay cupos disponibles suficientes para agregar lista de invitados"

                    };
                    return StatusCode(203, dataResp);
                }

               
            }
        }//fin control personas extras
    }
}
