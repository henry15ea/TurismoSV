using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.payment
{
    internal class paymentModel
    {
        private String cardNumber;
        private String fechaVencimiento;
        private String cvv;//codigo de seguridad 

        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public String FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string Cvv { get => cvv; set => cvv = value; }
    }
}
