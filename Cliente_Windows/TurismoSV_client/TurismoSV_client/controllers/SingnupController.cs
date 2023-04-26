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
using TurismoSV_client.models.ApiModels.singnupResponseModel;
using TurismoSV_client.models.AppModel.cuentaModel;

namespace TurismoSV_client.controllers.SingnupController
{
    internal class SingnupController
    {
        private String _responseJson;

        public async Task<bool> fn_SingUpUser(cuentaModel cuendaData)
        {
            bool resp = false;
            String username = cuendaData.U_name.Trim();
            String userpass = cuendaData.U_pass.Trim();

            if (cuendaData == null)
            {
                //se ha recivido elementos vacios 
                return false;
            }
            else
            {
                //trabajando con los datos recividos
                var httpClient = new HttpClient();


                string apiAddress = RoutesApi.GetRoute("registro");

                using (httpClient)
                {
                    var data = new {
                        id_cuenta = "null",
                        u_name = username,
                        id_usuario = "null",
                        u_state = 0,
                        idusuario ="null",
                        nombre = cuendaData.Nombre.ToUpper().Trim(),
                        apellido = cuendaData.Apellido.ToUpper().Trim(),
                        edad = cuendaData.Edad,
                        telefono = string.Format("{0:00-0000-00}", cuendaData.Telefono.ToUpper().Trim()),
                        direccion = cuendaData.Direccion.ToUpper().Trim(),
                        correo = cuendaData.Correo.Trim(),
                        id_rol = 0,
                        estado = 0,
                        u_pass = userpass.Trim(),

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

        public singnupResponseModel GetDataAPI()
        {
            return JsonConvert.DeserializeObject<singnupResponseModel>(_responseJson);

        }

        //------ end class
    }
}
