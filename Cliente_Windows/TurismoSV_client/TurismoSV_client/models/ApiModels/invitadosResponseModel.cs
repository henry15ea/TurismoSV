using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.ApiModels
{
    internal class invitadosResponseModel
    {
        private String infoMsg;
        private String serverApiStatus;

        public string InfoMsg { get => infoMsg; set => infoMsg = value; }
        public string ServerApiStatus { get => serverApiStatus; set => serverApiStatus = value; }
    }
}
