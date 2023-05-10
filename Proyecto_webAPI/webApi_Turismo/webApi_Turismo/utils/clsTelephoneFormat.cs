namespace webApi_Turismo.utils
{
    public static class clsTelephoneFormat
    {
        public static String GetTelephoneFormat(String telephoneData) {
            string result = "(123) 5050-5050";

            if (!string.IsNullOrEmpty(telephoneData))
            {
                string res = telephoneData.Trim();
                String formater = String.Format(
                    "({0}) {1}-{2}",
                    res.Substring(0, 3),
                    res.Substring(3, 6),
                    res.Substring(6)
                    );

                result = formater;

            }
            return result;
        }
    }
}
