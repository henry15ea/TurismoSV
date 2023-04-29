using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.vadicionalesModel
{
    internal class vadicionalesModel
    {
        private string id_adicional;
        private string id_paquete;
        private string nmb_paquete;
        private string nmb_adicional;
        private string dsc_adicional;
        private decimal precio_adicional;

        public string PrecioFormateado
        {
            get { return precio_adicional.ToString("C2"); }
        }
        public string Id_adicional { get => id_adicional; set => id_adicional = value; }
        public string Id_paquete { get => id_paquete; set => id_paquete = value; }
        public string Nmb_paquete { get => nmb_paquete; set => nmb_paquete = value; }
        public string Nmb_adicional { get => nmb_adicional; set => nmb_adicional = value; }
        public string Dsc_adicional { get => dsc_adicional; set => dsc_adicional = value; }
        public decimal Precio_adicional { get => precio_adicional; set => precio_adicional = value; }
    }
}
