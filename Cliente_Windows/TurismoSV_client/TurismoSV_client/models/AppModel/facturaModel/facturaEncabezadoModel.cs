using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.facturaModel.facturaEncabezadoModel
{
    internal class facturaEncabezadoModel
    {

        private String idencabezado;
        private String idcuenta;
        private String idformapago;
        private decimal descuento;
        private decimal monto;
        private bool state_emited = false;
        //extra
        private string username;

        public string Idencabezado { get => idencabezado; set => idencabezado = value; }
        public string Idcuenta { get => idcuenta; set => idcuenta = value; }
        public string Idformapago { get => idformapago; set => idformapago = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal Monto { get => monto; set => monto = value; }
        public bool State_emited { get => state_emited; set => state_emited = value; }
        public string Username { get => username; set => username = value; }
    }
}
