using Microsoft.AspNetCore.Mvc;
using FastReport;
using FastReport.Export.PdfSimple;
using System.Web.Http.Hosting;
using webApi_Turismo.utils;

namespace webApi_Turismo.Controllers.reports
{
    [ApiController]
    [Route("api/reporte")]
    public class reporteController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public reporteController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult reporteFast()
        {
            Report report = new Report();
            routesReport ruta = new routesReport();
            
            //report.Load("~/reports/demo.frx");
            //string reportPath = hostin.MapPath("~/reports/myReport.frx");
            String reportPath = _webHostEnvironment.ContentRootPath+ ruta.GetRoutes()[0].ToString();

           // report.Load(@"C:\Users\henryGuzman\source\repos\webApi_Turismo\webApi_Turismo\reports\demo.frx");
            report.Load(@""+reportPath);
          //  report.Dictionary.Connections[0].ConnectionString = 
            report.Prepare();
            PDFSimpleExport export = new PDFSimpleExport();

            using (MemoryStream ms = new MemoryStream())
            {
                export.Export(report, ms);
                ms.Flush();
                return (File(ms.ToArray(), "application/pdf", "mi_reporte.pdf"));
            }


            //return File(stream.ToArray(), "application/pdf", "MyReport.pdf");
          
        }  //return StatusCode(203, null);

    }
}
