using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.users
{
    internal class cInFacturaModel
    {
       private string username;
       private String id_factura;

        public string Username { get => username; set => username = value; }
        public string Id_factura { get => id_factura; set => id_factura = value; }
    }
}
