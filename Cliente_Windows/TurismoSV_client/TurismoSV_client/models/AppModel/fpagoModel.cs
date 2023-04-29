using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.fpagoModel
{
    internal class fpagoModel
    {
        String idformapago;
        String metodopago;
        String descripcion;

        public string Idformapago { get => idformapago; set => idformapago = value; }
        public string Metodopago { get => metodopago; set => metodopago = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
