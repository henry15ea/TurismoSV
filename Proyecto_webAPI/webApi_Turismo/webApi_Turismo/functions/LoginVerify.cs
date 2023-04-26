using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;

namespace webApi_Turismo.functions.LoginVerify
{
   public class LoginVerify{
        public Boolean fn_loginVerify(String user, String password) {
            Boolean state = false;

       
                
                Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {

                    String SQlCommand = "select * from cuenta  where u_name = @user AND u_pass = @pass;";

                    Console.WriteLine(conection.ConnectionString);

                    SqlCommand command = new SqlCommand(SQlCommand, conection);

                    cls_md5Generator md5 = new cls_md5Generator();

                    //definiendo los datos 
                    String username = user.Trim();
                    string pass = md5.fn_MD5Builder(password.Trim());
                    
                    command.Parameters.Add("@user", System.Data.SqlDbType.VarChar);
                    command.Parameters.Add("@pass", System.Data.SqlDbType.VarChar);

                    command.Parameters["@user"].Value = username;
                    command.Parameters["@pass"].Value = pass;
                 
                   // command.Parameters.AddWithValue("@user", username);
                    //command.Parameters.AddWithValue("@pass", pass);

                    Console.WriteLine("usaurio " + user.Trim());
                    Console.WriteLine("pass : " + password.Trim());
                    Console.WriteLine("md5 : " + md5.fn_MD5Builder(password.Trim()));

                    conection.Open();
                    object o = command.ExecuteScalar();
                    int count = -1;
                    //  int count = o == null ? 0 : (int)o;
                    if (o != null){
                        count = int.Parse(o.ToString());
                       // Console.WriteLine("Founds : " + o.ToString());
                    }
                    else {
                        count = 0;
                       // Console.WriteLine("Valor por defecto == no encontro usuario");
                    }
                    if (count > 0)
                    {
                        // Las credenciales son válidas
                       // conection.Close();
                        state = true;
                    }
                    else
                    {
                        //conection.Close();
                        // Las credenciales son inválidas
                        state = false;
                    }
                    // command.Dispose();

                }
                catch (Exception ex) { 
                    Console.WriteLine (ex.Message);
                }
                finally
                {
                    if (conection != null)
                    {
                        conection.Close();
                    }
                };

                return state;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }//fin fn_loginVerify

    }//fin clase


}
