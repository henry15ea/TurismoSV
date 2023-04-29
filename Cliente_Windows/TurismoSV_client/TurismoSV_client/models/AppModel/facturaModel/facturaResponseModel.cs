using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.facturaModel.facturaResponseModel
{
    internal class facturaResponseModel
    {
        private String token_paquete;
        private String infoMsg;
        private String serverApiStatus;

        public string Token_paquete { get => token_paquete; set => token_paquete = value; }
        public string InfoMsg { get => infoMsg; set => infoMsg = value; }
        public string ServerApiStatus { get => serverApiStatus; set => serverApiStatus = value; }
    }
}
