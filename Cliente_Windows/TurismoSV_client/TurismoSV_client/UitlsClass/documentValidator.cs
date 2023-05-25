using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.UitlsClass
{
    internal class documentValidator
    {
        public bool fn_ValidaDUI(string dui)
        {
            if (dui.Length != 9)
            {
                return false;
            }

            int suma = 0;
            for (int i = 0; i < 8; i++)
            {
                suma += (i + 1) * Convert.ToInt32(dui[i].ToString());
            }
            int resto = suma % 10;
            int digitoVerificador = Convert.ToInt32(dui[8].ToString());

            return (resto == digitoVerificador);
        }

        public string fn_GetDuiFormat(String ndoc) {
            String dx = "454545-6";
            if (ndoc != null) {
               dx=  ndoc.Insert(ndoc.Length - 2, "-");
            }
            return ndoc;
        }

        public string fn_FormatoIDConGuion(string numeros)
        {
            string[] numerosSeparados = numeros.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string resultado = "";
            foreach (string num in numerosSeparados)
            {
                string id = num.Trim();
                if (id.Length < 2 || id[id.Length - 2] == '-' || id[id.Length - 1] != '-')
                {
                    continue; // número inválido, pasamos al siguiente
                }

                // Eliminamos cualquier caracter no numérico de la cadena
                id = new string(id.Where(char.IsDigit).ToArray());
                // Si la cadena es más larga de 8 caracteres, tomamos sólo los primeros 8
                id = id.PadLeft(id.Length - 1, '0').Substring(0, id.Length - 1);
                // Construimos el número de identificación con el formato adecuado
                resultado += id.Insert(id.Length - 1, "-") + "\n";
            }
            return resultado.TrimEnd('\n');
        }

        public string fn_FormatoDUI(string numeros)
        {
            // Eliminamos cualquier caracter no numérico de la cadena
            numeros = new string(numeros.Where(char.IsDigit).ToArray());
            // Si la cadena es más larga de 8 caracteres, tomamos sólo los primeros 8
            numeros = numeros.PadLeft(8, '0').Substring(0, 8);
            // Calculamos el dígito verificador
            int suma = 0;
            for (int i = 0; i < 8; i++)
            {
                suma += (i + 1) * Convert.ToInt32(numeros[i].ToString());
            }
            int verificador = suma % 10;
            // Construimos el número de DUI con el formato adecuado
            string formato = numeros.Insert(2, "-").Insert(5, "-");
            formato += "-" + verificador.ToString();
            return formato;
        }



    }
}
