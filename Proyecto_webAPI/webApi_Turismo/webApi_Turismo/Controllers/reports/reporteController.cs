using Microsoft.AspNetCore.Mvc;
using FastReport;
using FastReport.Export.PdfSimple;


namespace webApi_Turismo.Controllers.reports
{
    [ApiController]
    [Route("api/reporte")]
    public class reporteController : Controller
    {
        
        [HttpGet("mis-reportes")]
        public IActionResult reporteFast()
        {
            Report report = new Report();
            //report.Load("~/reports/demo.frx");
            report.Load(@"C:\Users\henryGuzman\source\repos\webApi_Turismo\webApi_Turismo\reports\demo.frx");
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
            //return StatusCode(203, null);

        }
    }
}
