using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.ApiModels.LoginResponseModel
{
    internal class LoginResponseModel
    {
        public string user { get; set; }

        public string mail { get; set; }
        public string role_user { get; set; }
        public string token_id { get; set; }
        public string infoMsg { get; set; }
        public string accessLogin { get; set; }
        public string serverApiStatus { get; set; }
    }
}
