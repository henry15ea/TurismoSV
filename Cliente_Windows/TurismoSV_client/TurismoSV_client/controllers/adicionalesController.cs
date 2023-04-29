using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using TurismoSV_client.UitlsClass.HttpClientObj;
using TurismoSV_client.UitlsClass.RoutesApi;
using TurismoSV_client.models.UserModel;
using Newtonsoft.Json;
using TurismoSV_client.models.AppModel.vadicionalesModel;
using Newtonsoft.Json.Linq;

namespace TurismoSV_client.controllers.adicionalesController
{
    internal class adicionalesController
    {
        //
        private String _responseJson;
        private List<vadicionalesModel> _dataResponse;

        public List<vadicionalesModel> DataResponse { get => _dataResponse; set => _dataResponse = value; }



        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_GetAdicionalesByIdpkgList(String id_paquete)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("adicionalesByIdpkg");

            using (httpClient)
            {
                var data = new { id_paquete = id_paquete.ToString().Trim() };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiAddress, content);

                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                    var result = await response.Content.ReadAsStringAsync();

                    dynamic responseObject = JsonConvert.DeserializeObject(result);

                    _responseJson = responseObject.data;

                    _dataResponse = JsonConvert.DeserializeObject<List<vadicionalesModel>>(_responseJson);
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

        public List<vadicionalesModel> GetDataAPI()
        {
            return JsonConvert.DeserializeObject<List<vadicionalesModel>>(_responseJson);

        }
        //
    }
}
