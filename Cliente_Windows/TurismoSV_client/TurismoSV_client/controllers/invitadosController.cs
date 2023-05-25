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

namespace TurismoSV_client.controllers
{
    internal class invitadosCotroller
    {
        //
        private String _responseJson;
        private invitadosResponseModel _dataResponse;
        internal invitadosResponseModel DataResponse { get => _dataResponse; set => _dataResponse = value; }


        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_RegistroInvitados(List<invitadosModel> datosModel)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("InPersonsExtras");

            using (httpClient)
            {
                var content = new StringContent(JsonConvert.SerializeObject(datosModel), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiAddress, content);
                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {
                    
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var result = await response.Content.ReadAsStringAsync();
                    _responseJson = result;

                    _dataResponse = JsonConvert.DeserializeObject<invitadosResponseModel>(_responseJson);

                    // manejar la respuesta exitosa aquí
                    return true;
                }
                else
                {
                    //no se obtuvo el resultado esperado 
                    return resp;
                }
            }
        }//fin fn_IsloggedIn

        public invitadosResponseModel GetDataAPI()
        {
            return JsonConvert.DeserializeObject<invitadosResponseModel>(_responseJson);

        }
        //
    }//end class
}//end namespaces
