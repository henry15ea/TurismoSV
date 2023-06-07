using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TurismoSV_client.models.ApiModels;
using TurismoSV_client.models.AppModel.users;
using TurismoSV_client.UitlsClass.RoutesApi;

namespace TurismoSV_client.controllers.users
{
    internal class CompraPaqueteReservaController
    {
        private String _responseJson;
        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_CompraPaqueteReserva(cUpFacturaStatus datamodel)
        {
            bool resp = false;

            if (datamodel.Username == null || datamodel.Id_encabezado == null || datamodel.Id_fpago == null)
            {
                //se ha recivido elementos vacios 
                return false;
            }
            else
            {
                //trabajando con los datos recividos
                var httpClient = new HttpClient();


                string apiAddress = RoutesApi.GetRoute("CompletaReserva");

                using (httpClient)
                {
                    var data = new {
                        username = datamodel.Username.Trim(),
                        id_encabezado = datamodel.Id_encabezado.Trim(),
                        id_fpago = datamodel.Id_fpago.Trim() 
                    };

                    var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(apiAddress, content);

                    //reviso el status code que trae la api
                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                        var result = await response.Content.ReadAsStringAsync();
                        _responseJson = result;
                        // manejar la respuesta exitosa aquí
                        return true;
                    }
                    else
                    {
                        //no se obtuvo el resultado esperado 
                        return resp;
                    }
                }
            }
        }//fin fn_IsloggedIn

        public facturaUpdateStatusResponse GetDataAPI()
        {
            return JsonConvert.DeserializeObject<facturaUpdateStatusResponse>(_responseJson);

        }

    }//end class
}//end namespaces
