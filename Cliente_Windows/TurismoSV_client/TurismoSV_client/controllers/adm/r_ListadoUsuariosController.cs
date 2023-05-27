using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TurismoSV_client.models.AppModel.admin;
using TurismoSV_client.UitlsClass;
using TurismoSV_client.UitlsClass.RoutesApi;

namespace TurismoSV_client.controllers.adm
{
    internal class r_ListadoUsuariosController
    {
        //funcion que retorna un true/false si el suario se ha logueado en el sistema de la api 
        public async Task fn_GetListadoUsuariosReport(adicionalesByNombreModel dataModel)
        {
            bool resp = false;

            //trabajando con los datos recividos
            var httpClient = new HttpClient();


            string apiAddress = RoutesApi.GetRoute("reporteUsuarios");

            using (httpClient)
            {
                var data = new
                {
                    username = dataModel.username.Trim(),

                };

                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(apiAddress, content);

                //reviso el status code que trae la api
                if (response.IsSuccessStatusCode)
                {

                    var ReportResult = await response.Content.ReadAsByteArrayAsync();
                    var memoryStream = new MemoryStream(ReportResult);


                    saveFileDialogFuncs svdialog = new saveFileDialogFuncs();
                    svdialog.fn_saveFile(memoryStream);

                    /*
                    var browser = new System.Windows.Controls.WebBrowser();
                    browser.NavigateToStream(memoryStream);
                    var window = new Window();
                    window.Content = browser;
                    window.Show();
                    // manejar la respuesta exitosa aquí
                    */
                }
            }
        }//fin 
    }
}
