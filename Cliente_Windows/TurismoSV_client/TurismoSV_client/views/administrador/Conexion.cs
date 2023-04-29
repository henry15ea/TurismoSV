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
            SqlConnection sc1 = new SqlConnection("Server=DESKTOP-OFBBKK3\\RONALD;Database=BD_TURISMO;Integrated Security=True");

            return sc1;
        }
    }
}
