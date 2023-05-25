namespace webApi_Turismo.functions.Payment
{
    public class paymentFuncs
    {
        public bool fn_validateCard(String cardNumber) {
            // Eliminar espacios en blanco y guiones del número de tarjeta
            cardNumber = cardNumber.Replace(" ", "").Replace("-", "");

            // Verificar que la longitud del número de tarjeta sea correcta
            if (cardNumber.Length < 13 || cardNumber.Length > 19) {
                return false;
            } else { 
                return true;
            }
        }
    }
}
