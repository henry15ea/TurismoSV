using FastReport;
using FastReport.Data;
using FastReport.Export.PdfSimple;
using FastReport.Utils;
using webApi_Turismo.functions.UsersApi.reportVerifiedUser;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.modelsUtils;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.Reports.UserReports
{
    public class FacturaUserFuncs
    {
        public MemoryStream fn_FacturaUserBuilder(cReporteDataRoute modelo) {
            MemoryStream memoryStream =null;

            try {
                reportVerifiedUser rpv = new reportVerifiedUser();
                usuarioDataInfo udata = new usuarioDataInfo();
                userFacturaModel modeloFacVerif = new userFacturaModel();
                cuentaDetalle ct = new cuentaDetalle();
                ct = udata.GetUserAccountDetailsByUserName(modelo.Username.Trim());

                modeloFacVerif.Id_factura = modelo.Id_factura.Trim();
                modeloFacVerif.Username = ct.Id_cuenta.Trim();
                //verificando si el usuario que hace la peticion corresponde a el usuario de la factura
                if (rpv.fn_FacturaByUserAIDF(modeloFacVerif) == true)
                {
                    //creando reporte
                    Report report = new Report();
                    routesReport ruta = new routesReport();

                    RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));
                    Conection_database cn = new Conection_database();

                    //report.Load("~/reports/demo.frx");
                    //string reportPath = hostin.MapPath("~/reports/myReport.frx");


                    report.Load(@"" + modelo.RutaReporte.Trim());
                    report.SetParameterValue("pid_factura", modelo.Id_factura.Trim());
                    report.Dictionary.Connections[0].ConnectionString = cn.GetConnection().ConnectionString;
                    //  report.Dictionary.Connections[0].ConnectionString = 
                    report.Prepare();
                    PDFSimpleExport export = new PDFSimpleExport();
                    using (MemoryStream ms = new MemoryStream())
                    {
        
                        export.Export(report, ms);

                        memoryStream = ms;
                       
                    }

                    return memoryStream;
                }
                else {
                    return memoryStream;
                }
                //finaliza verificacion de usuario y factura

                } catch (Exception ex) {
                return memoryStream;
            
            }

            return memoryStream;
        
        }
    }
}
