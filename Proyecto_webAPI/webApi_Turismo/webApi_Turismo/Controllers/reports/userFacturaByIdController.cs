using Microsoft.AspNetCore.Mvc;
using FastReport.Data;
using FastReport.Utils;
using FastReport;
using FastReport.Export.PdfSimple;
using webApi_Turismo.functions.UsersApi.reportVerifiedUser;
using webApi_Turismo.models.customModels;
using webApi_Turismo.utils;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.vistaModels.cuentaDetalle;

namespace webApi_Turismo.Controllers.reports
{
    [ApiController]
    [Route("api/reporte/user/Factura")]
    public class userFacturaByIdController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public userFacturaByIdController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost]
        public IActionResult reporteFacturaUsuario([FromBody] userFacturaModel modelo)
        {
            var dataResponse = new {
                InfoMsg = "No se han recivido los parametros correctos",
                ServerApiStatus = "fallo al recivir parametros , o no se recivieron parametros."
            };
            try {
                reportVerifiedUser rpv = new reportVerifiedUser();
                usuarioData udata = new usuarioData();
                cuentaDetalle ct = new cuentaDetalle();
                ct = udata.GetUserAccountDetailsByUserName(modelo.Username.Trim());

                modelo.Username = ct.Id_usuario;

                if (rpv.fn_FacturaByUserAIDF(modelo)==true)
                {
                    //creando reporte
                    Report report = new Report();
                    routesReport ruta = new routesReport();

                    RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
                    Conection_database cn = new Conection_database();

                    //report.Load("~/reports/demo.frx");
                    //string reportPath = hostin.MapPath("~/reports/myReport.frx");
                    String reportPath = _webHostEnvironment.ContentRootPath + ruta.GetRoutes()[1].ToString();

                    report.Load(@"" + reportPath);
                    report.SetParameterValue("pid_factura", modelo.Id_factura.Trim());
                    report.Dictionary.Connections[0].ConnectionString = cn.GetConnection().ConnectionString;
                    //  report.Dictionary.Connections[0].ConnectionString = 
                    report.Prepare();
                    PDFSimpleExport export = new PDFSimpleExport();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        String reporteFileName = "null";
                        reporteFileName = DateTime.Now + "_Factura.pdf";
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
                        InfoMsg = "El usuario recivido no corresponde con la factura",
                        ServerApiStatus = "El id de la factura no corresponde al usuario obtenido."
                    };
                    return StatusCode(202, dataResponse);
                }
            } catch (Exception ex) {
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
