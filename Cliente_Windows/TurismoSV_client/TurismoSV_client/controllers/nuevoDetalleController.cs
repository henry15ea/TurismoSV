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
using TurismoSV_client.models.AppModel.facturaModel.detalleFacturaModel;
using TurismoSV_client.models.AppModel.facturaModel.facturaResponseModel;

namespace TurismoSV_client.controllers.nuevoDetalleController
{
    internal class nuevoDetalleController
    {
        //
        private String _responseJson;
        private List<facturaEncabezadoModel> _dataResponse;
        private facturaResponseModel restult;



        public List<facturaEncabezadoModel> DataResponse { get => _dataResponse; set => _dataResponse = value; }
        internal facturaResponseModel Restult { get => restult; set => restult = value; }



        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_InDetalleFactura(detalleFacturaModel datosModel)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("InDetalle");

            using (httpClient)
            {
                var data = new
                {
                    iddetalle = datosModel.Iddetalle.ToString(),
                    idencabezado = datosModel.Idencabezado.ToString(),
                    idpaqueted = datosModel.Idpaqueted.ToString(),
                    precio = datosModel.Precio,
                    descuento = datosModel.Descuento,
                    monto = datosModel.Monto,
                    cupos = datosModel.Cupos,
                    username = datosModel.Username.ToString(),

                };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiAddress, content);

                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                    string responseBody = await response.Content.ReadAsStringAsync();

                    restult = JsonConvert.DeserializeObject<facturaResponseModel>(responseBody);
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

        public List<facturaEncabezadoModel> GetDataAPI()
        {
            return JsonConvert.DeserializeObject<List<facturaEncabezadoModel>>(_responseJson);

        }
        //
    }
}
