using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TurismoSV_client.models.ApiModels.departamentosResponseModel;
using TurismoSV_client.UitlsClass.RoutesApi;

namespace TurismoSV_client.functions.FillCmbx
{
    internal class FillCmbx
    {

        private List<departamentosResponseModel?> listado = null;

        public List<departamentosResponseModel> Listado { get => listado; set => listado = value; }


        public static async Task<List<departamentosResponseModel>>  GetDepartaments() {
            List<departamentosResponseModel?> lista = null;
            try {
                //trabajando con los datos recividos
                var httpClient = new HttpClient();


                string apiAddress = RoutesApi.GetRoute("departamentos");

                using (httpClient)
                {
                   // var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                    var response = await httpClient.GetAsync(apiAddress);

                    //reviso el status code que trae la api
                    if (response.IsSuccessStatusCode)
                    {
                        //System.Diagnostics.Debug.WriteLine(response.Content.ReadAsStringAsync());
                        var result = await response.Content.ReadAsStringAsync();

                        lista = JsonConvert.DeserializeObject<List<departamentosResponseModel>>(result);


                        // manejar la respuesta exitosa aquí
                        return lista;
                    }
                    else
                    {
                        //no se obtuvo el resultado esperado 
                        return lista;
                    }
                }
            }
            catch(Exception) {
                return lista;
            }
            
        }//END LISTADODEPARTAMENTOS 
    
    //END CLASS 
    }
}//end namespaces
