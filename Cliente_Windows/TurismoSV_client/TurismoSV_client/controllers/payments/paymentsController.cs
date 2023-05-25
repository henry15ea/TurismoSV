using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TurismoSV_client.models.ApiModels;
using TurismoSV_client.models.AppModel.payment;
using TurismoSV_client.UitlsClass.RoutesApi;

namespace TurismoSV_client.controllers.payments
{
    internal class paymentsController
    {
        private paymentResponseModel _dataResponse;
        private String _responseJson;

        public paymentResponseModel DataResponse { get => _dataResponse; set => _dataResponse = value; }

        public async Task<bool> fn_GetCardValidation(paymentModel cardData)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("payment");

            using (httpClient)
            {
                var data = new {
                    cardNumber = cardData.CardNumber.Trim(),
                    fechaVencimiento = cardData.FechaVencimiento.Trim(),
                    cvv = cardData.Cvv.Trim(),
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
        }//fin fn_IsloggedIn

        public paymentResponseModel GetDataAPI()
        {
            return JsonConvert.DeserializeObject<paymentResponseModel>(_responseJson);

        }
        //

    }//end class
}//end namespaces
