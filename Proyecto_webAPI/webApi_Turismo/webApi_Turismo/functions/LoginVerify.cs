using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

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

                    String SQlCommand = "select count(*) from cuenta c  where c.u_name = @user AND c.u_pass = @pass";

                    Console.WriteLine(conection.ConnectionString);

                    SqlCommand command = new SqlCommand(SQlCommand, conection);

                    cls_md5Generator md5 = new cls_md5Generator();

                    //definiendo los datos 
                    String username = user.Trim();
                    string pass = md5.fn_MD5Builder(password.Trim());
                    
                    command.Parameters.Add("@user", System.Data.SqlDbType.VarChar);
                    command.Parameters.Add("@pass", System.Data.SqlDbType.VarChar);

                    command.Parameters["@user"].Value = username.ToString();
                    command.Parameters["@pass"].Value = pass.ToString();
                 
                   // command.Parameters.AddWithValue("@user", username);
                    //command.Parameters.AddWithValue("@pass", pass);

                    

                    conection.Open();
                    object o = command.ExecuteScalar();
                    int count = -1;
                    //  int count = o == null ? 0 : (int)o;
                    if (o != null )
                    {
                        bool parsedSuccessfully = int.TryParse(o.ToString(), out count);
                        Console.WriteLine("encontrado usuario  " + count);
                        Console.WriteLine("usaurio " + user.Trim());
                        Console.WriteLine("pass : " + password.Trim());
                        Console.WriteLine("md5 : " + pass);

                        if (!parsedSuccessfully)
                        {
                            // handle the situation where the value of 'o' cannot be parsed as an integer
                            count = -1;
                        }
                        else {
                            count = 1;
                        }

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
