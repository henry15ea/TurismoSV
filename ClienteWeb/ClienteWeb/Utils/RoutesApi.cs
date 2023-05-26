using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteWeb.Utils;

    class RoutesApi
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
            Routes.Add("InPersonsExtras",HostApi+ "/api/user/integrantesExtras");



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

