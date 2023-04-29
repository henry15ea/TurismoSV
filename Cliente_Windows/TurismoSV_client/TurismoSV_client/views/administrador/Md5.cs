using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.views.administrador
{
    class Md5
    {
        public string fn_GenerateMd5Hash()
        {
            Random random = new Random();
            string input = random.Next().ToString();
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }

        public String fn_MD5Builder(String TextoACifrar)
        {
            String md5Hash = "202CB962AC59075B964B07152D234B70"; //equivalente a clave 123

            try
            {

                using (MD5 md5 = MD5.Create())
                {
                    byte[] inputBytes = Encoding.ASCII.GetBytes(TextoACifrar.Trim());
                    byte[] hashBytes = md5.ComputeHash(inputBytes);

                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        sb.Append(hashBytes[i].ToString("X2"));
                    }

                    md5Hash = sb.ToString();

                }

                return md5Hash;


            }
            catch (Exception e)
            {
                return md5Hash;

            }


            return md5Hash;
        }
    }
}
