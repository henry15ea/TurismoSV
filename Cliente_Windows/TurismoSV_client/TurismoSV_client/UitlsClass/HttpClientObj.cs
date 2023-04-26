using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using TurismoSV_client.models.UserModel;

namespace TurismoSV_client.UitlsClass.HttpClientObj;

    internal class HttpClientObj
    {
        private string SalidaApi = "";
    public HttpClient GetHttpClient()
        {
            //var httpClient = new HttpClient();
            return new HttpClient();
        }

        public async Task<bool> PostDataToApi(string apiAddress, UserModel values)
        {
        

                var httpClient = new HttpClient();//objeto de httpClient

            //var encodedData = new FormUrlEncodedContent(data); //convierto el arreglo en formato JSON

                var json = JsonConvert.SerializeObject(values);
                //var json = JsonSerializer.Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("http://localhost:5119/api/longin", content); //Hago una peticion POST

        //DataApi = await response.Content.ReadAsStringAsync(); //obtengo los datos que trae la api

        // return response.IsSuccessStatusCode; //retorna el codigo de estado 

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Error sending request: {response.StatusCode} - {response.ReasonPhrase}");
            return false;
        }
        else
        {
            var result = await response.Content.ReadAsStringAsync();
            SalidaApi = result;
            Console.WriteLine($"Response from server: {result}");
           
            return true;
        }
    }

    public dynamic GetDataOfApi() { 
        dynamic data = null;

        if (SalidaApi != null) { 
            data = JsonConvert.DeserializeObject<dynamic>(SalidaApi);
        } else { 
            data = null;
        }

        return data;
    }


 }

