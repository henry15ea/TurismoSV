using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.UitlsClass.RoutesApi;

    internal class RoutesApi
    {
        static public Dictionary<string, string> Routes;
        static public String HostApi = "http://localhost:5119/api";

       public RoutesApi() {
            Routes = new Dictionary<string, string>();
            Routes.Add("login",HostApi+ "/public/longin");        
            Routes.Add("registro",HostApi+ "/public/newuser");       
            Routes.Add("categorias",HostApi+ "/public/categorias");
            Routes.Add("paquetesDisp",HostApi+ "/public/paquetesDisponibles");
            Routes.Add("paquetesInfo",HostApi+ "/public/detallepckById");
            Routes.Add("adicionalesByIdpkg",HostApi+ "/public/adicionalesbyid");
            Routes.Add("formaPago",HostApi+ "/public/fpago");

            //rutas para hacer ingreso de datos 
            Routes.Add("InCompra",HostApi+ "/user/asignarPaquete");
            Routes.Add("InDetalle",HostApi+ "/user/detalleFactura");
            Routes.Add("InPersonsExtras",HostApi+ "/user/integrantesExtras");
            Routes.Add("historialCompras",HostApi+ "/user/facturas");

            //obtener reporte factura 
            Routes.Add("facturaReporte", HostApi + "/reporte/user/Factura");
            Routes.Add("reporteUsuarios", HostApi + "/reporte/admin/listadoUsuarios");

            //verificacion de targeta de credito para cuando se compran paquetes
            Routes.Add("payment", HostApi + "/payment/payment");



            //en pruebas
            Routes.Add("departamentos", HostApi + "/public/Departamentos");
        }

        static public string GetRoute(string key)
        {
            if (Routes.ContainsKey(key))
            {
                return Routes[key];
            }
            else
            {
                return null;
            }
        }




}

