using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions.Payment;
using webApi_Turismo.models.paymentModel;

namespace webApi_Turismo.Controllers.payment
{
    [ApiController]
    [Route("api/payment/[controller]")]
    public class paymentController : Controller
    {

        [HttpPost]
        public IActionResult eliminarAdicional([FromBody] paymentModel modelo) 
        {
            var data = new {
                validate = 0,
                InfoMsg = "No se recivieron los datos necesarios ",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."

            };
            try {
                //verifica el codigo de la targeta y si esta es valida 
                paymentFuncs fnpayment = new paymentFuncs();

                if (!String.IsNullOrEmpty(modelo.Cvv.Trim()) && !String.IsNullOrEmpty(modelo.CardNumber) && !string.IsNullOrEmpty(modelo.FechaVencimiento))
                {
                    //verificacion final
                    if (fnpayment.fn_validateCard(modelo.CardNumber.Trim()) == true)
                    {
                        data = new
                        {
                            validate = 1,
                            InfoMsg = "Se ha aprovado la compra con la targeta de credito",
                            ServerApiStatus = "Los datos de la targeta de credito son validos"

                        };
                        return StatusCode(200, data);
                    }
                    else
                    {
                        data = new
                        {
                            validate = 0,
                            InfoMsg = "La targeta de credito no es valida",
                            ServerApiStatus = "El codigo de la targeta de credito es invalido"

                        };
                        return StatusCode(202, data);
                    }
                    //fin verificacion final
                }
                else 
                {
                    data = new
                    {
                        validate = 0,
                        InfoMsg = "Se necesitan todos los datos necesarios de la targeta de credito",
                        ServerApiStatus = "No se han recivido todos los datos necesarios"

                    };
                    return StatusCode(203, data);
                }

                //fin verificacion
            }
            catch(Exception) {
                return StatusCode(204, data);
            }
        
        }
    }
    //end class
}//end namespaces
