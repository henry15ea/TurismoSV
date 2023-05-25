namespace webApi_Turismo.models.paymentModel
{
    public class paymentModel
    {
        private String cardNumber;
        private String fechaVencimiento;
        private String cvv;//codigo de seguridad 

        public string CardNumber { get => cardNumber; set => cardNumber = value; }
        public String FechaVencimiento { get => fechaVencimiento; set => fechaVencimiento = value; }
        public string Cvv { get => cvv; set => cvv = value; }
    }
}
