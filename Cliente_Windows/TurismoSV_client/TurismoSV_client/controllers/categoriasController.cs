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
using TurismoSV_client.models.AppModel.categoriasModel;
using Newtonsoft.Json.Linq;

namespace TurismoSV_client.controllers.categoriasController
{
    internal class categoriasController
    {
        //
        private String _responseJson;
        private List<categoriasModel> _dataResponse;

        public List<categoriasModel> DataResponse { get => _dataResponse; set => _dataResponse = value; }



        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_GetCategoryList()
        {
            bool resp = false;

                //trabajando con los datos recividos
                var httpClient = new HttpClient();


                string apiAddress = RoutesApi.GetRoute("categorias");

                using (httpClient)
                {
                    var response = await httpClient.GetAsync(apiAddress);

                    //reviso el status code que trae la api
                    if (response.IsSuccessStatusCode)
                    {
                        System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                        var result = await response.Content.ReadAsStringAsync();

                        dynamic responseObject = JsonConvert.DeserializeObject(result);

                    _responseJson = responseObject.data;

                    _dataResponse = JsonConvert.DeserializeObject<List<categoriasModel>>(_responseJson);
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

        public List<categoriasModel> GetDataAPI()
        {
            return JsonConvert.DeserializeObject<List<categoriasModel>>(_responseJson);

        }
        //
    }
}
