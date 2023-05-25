using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.ApiModels
{
    internal class facturasResponseModel
    {
        String id_factura;
        String paquete;
        String pasarela;
        String descuento;
        String monto = "0";
        String total = "0";
        String cupos = "0";
        String usuario;
        String estado;

        public string Id_factura { get => id_factura; set => id_factura = value; }
        public string Paquete { get => paquete; set => paquete = value; }
        public string Pasarela { get => pasarela; set => pasarela = value; }
        public string Descuento
        {
            get => "%"+string.Format("{0:C2}", descuento);
            set => descuento = value;
        }

        public string Total
        {
            get => "$ "+string.Format("{0:C2}", total);
            set => total = value;
        }

        public string Monto
        {
            get => "$ " + string.Format("{0:C2}", monto);
            set => monto = value;
        }

        public string Cupos { get => cupos; set => cupos = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Estado { get => estado; set => estado = value; }

    }
}
