using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TurismoSV_client.models.ApiModels;
using TurismoSV_client.UitlsClass.RoutesApi;

namespace TurismoSV_client.controllers.users
{
    internal class historialComprasController
    {
        //
        private String _responseJson;
        private List<facturasResponseModel> _dataResponse;

        public List<facturasResponseModel> DataResponse { get => _dataResponse; set => _dataResponse = value; }



        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_GetFacturaList(String username)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("historialCompras");

            using (httpClient)
            {
                var data = new { item = username.Trim()};

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiAddress, content);

                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                    var result = await response.Content.ReadAsStringAsync();

                    dynamic responseObject = JsonConvert.DeserializeObject(result);

                    _responseJson = responseObject.data;

                    _dataResponse = JsonConvert.DeserializeObject<List<facturasResponseModel>>(_responseJson);
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

        public List<facturasResponseModel> GetDataAPI()
        {
            return JsonConvert.DeserializeObject<List<facturasResponseModel>>(_responseJson);

        }
        //
    }//end class
}//end namespaces
