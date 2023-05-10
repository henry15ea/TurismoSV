using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TurismoSV_client.views.administrador
{
    class Conexion
    {
        public static SqlConnection sc()
        {

            var sc1 = new SqlConnection("Server=LAPTOP-8S0156K3\\SQLEXPRESS;Database=BD_TURISMO;User Id=henry15ea;Password=demolition;");

            return sc1;
        }
    }
}
