using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions
{
    public class VerifyData
    {
        public Boolean fn_verifyUserById(String id) {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {

                    String SQlCommand = "SELECT COUNT(*) FROM vusuarios WHERE idusuario = @id";

                    String id_user = id.Trim();

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    command.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                    command.Parameters["@id"].Value = id_user;

                    conection.Open();

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        state = true;
                    }

                    return state;
                    // command.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

        }//fin fn_verifyUserById

        public Boolean fn_verifyAccountById(String id)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {

                    String SQlCommand = "SELECT COUNT(*) FROM vcuenta WHERE id_cuenta = @id";

                    String id_user = id.Trim();

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    command.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                    command.Parameters["@id"].Value = id_user;

                    conection.Open();

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        state = true;
                    }

                    return state;
                    // command.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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

        }//fin fn_verifyUserById
        //******************************
    }

}
