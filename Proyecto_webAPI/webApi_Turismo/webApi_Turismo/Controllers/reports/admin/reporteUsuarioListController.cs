using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using Microsoft.AspNetCore.Mvc;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.Controllers.reports.admin
{
    [ApiController]
    [Route("api/reporte/admin/listadoUsuarios")]
    public class reporteUsuarioListController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public reporteUsuarioListController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult reporteUsuarios([FromBody] cUserModel modelo)
        {
            var dataResponse = new
            {
                InfoMsg = "No se han recivido los parametros correctos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."
            };
            try
            {
                usuarioDataInfo udata = new usuarioDataInfo();
                cuentaDetalle ct = new cuentaDetalle();
                ct = udata.GetUserAccountDetailsByUserName(modelo.Username.Trim());

               

                if (ct != null && ct.Id_rol.Equals(1))
                {
                    //creando reporte
                    Report report = new Report();
                    routesReport ruta = new routesReport();

                    RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
                    Conection_database cn = new Conection_database();

                    //report.Load("~/reports/demo.frx");
                    //string reportPath = hostin.MapPath("~/reports/myReport.frx");
                    String reportPath = _webHostEnvironment.ContentRootPath + ruta.GetRoutes()[2].ToString();

                    report.Load(@"" + reportPath);
                    report.Dictionary.Connections[0].ConnectionString = cn.GetConnection().ConnectionString;
                    report.SetParameterValue("dataconections", cn.GetConnection().ConnectionString);
                    //  report.Dictionary.Connections[0].ConnectionString = 
                    report.Prepare();
                    PDFSimpleExport export = new PDFSimpleExport();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        String reporteFileName = "null";
                        reporteFileName = DateTime.Now + "_ListadoUsuarios.pdf";
                        reporteFileName.Replace(" ", "_");
                        export.Export(report, ms);

                        ms.Flush();

                        return (File(ms.ToArray(), "application/pdf", reporteFileName));
                    }
                    //fin crear reporte 
                }
                else
                {
                    dataResponse = new
                    {
                        InfoMsg = "El usuario recivido no tiene los derechos necesarios para generar el reporte",
                        ServerApiStatus = "El usuario no puede generar dicha informacion por permisos insuficiente."
                    };
                    return StatusCode(202, dataResponse);
                }
            }
            catch (Exception ex)
            {
                dataResponse = new
                {
                    InfoMsg = "Hubo un problema al tratar de crear el reporte",
                    ServerApiStatus = "Problema a nivel de api a crear reporte"
                };
                return StatusCode(204, dataResponse);
            }
            return StatusCode(203, dataResponse);
            //return File(stream.ToArray(), "application/pdf", "MyReport.pdf");

        }  //return StatusCode(203, null);

    }//end class
}//end namespaces
