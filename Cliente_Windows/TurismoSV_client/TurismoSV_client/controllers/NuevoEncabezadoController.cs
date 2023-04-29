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
using TurismoSV_client.models.ApiModels.LoginResponseModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaEncabezadoModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaResponseModel;

namespace TurismoSV_client.controllers.NuevoEncabezadoController
{
    internal class NuevoEncabezadoController
    {
        //
        private String _responseJson;
        private facturaResponseModel result;
        private List<facturaResponseModel> _dataResponse;

        public List<facturaResponseModel> DataResponse { get => _dataResponse; set => _dataResponse = value; }
        public facturaResponseModel Result { get => result; set => result = value; }



        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_InHeadFactura(facturaEncabezadoModel datosModel)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("InCompra");

            using (httpClient)
            {
                var data = new {
                    idencabezado = datosModel.Idencabezado,
                    idcuenta = datosModel.Idcuenta,
                    idformapago = datosModel.Idformapago,
                    descuento = datosModel.Descuento,
                    monto = datosModel.Monto,
                    state_emited = datosModel.State_emited,
                    username = datosModel.Username
                };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiAddress, content);

                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                 
                    string responseBody = await response.Content.ReadAsStringAsync();

                    Result = JsonConvert.DeserializeObject<facturaResponseModel>(responseBody);
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

        public List<facturaResponseModel> GetDataAPI()
        {
            return JsonConvert.DeserializeObject<List<facturaResponseModel>>(_responseJson);

        }
        //
    }
}
