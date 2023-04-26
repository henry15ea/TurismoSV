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

namespace TurismoSV_client.controllers.LoginController
{
    internal class LoginController
    {
        private String _responseJson;
        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task<bool> fn_loginUser(String username, String password)
        {
            bool resp = false;
            String uname = username.Trim();
            String pass = password.Trim();

            if (uname == null || pass == null)
            {
                //se ha recivido elementos vacios 
                return false;
            }
            else {
                //trabajando con los datos recividos
                var httpClient = new HttpClient();


                string apiAddress = RoutesApi.GetRoute("login");

                using (httpClient)
                {
                    var data = new { usuario = uname, clave = password };

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

        public LoginResponseModel GetDataAPI() {
           return JsonConvert.DeserializeObject<LoginResponseModel>(_responseJson);

        }



        //*************************************************************************
    }
}
