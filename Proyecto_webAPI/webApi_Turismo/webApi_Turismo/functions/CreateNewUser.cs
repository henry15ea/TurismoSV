using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.UsuarioModel;
using webApi_Turismo.models.mododelsdb.cuentaModel;

namespace webApi_Turismo.functions
{
    public class CreateNewUser
    {
        private String id_ususer;

        public string Id_ususer { get => id_ususer; set => id_ususer = value; }

        public Boolean NewUser(UsuarioModel usuario)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {
                    //ejecuto las peticiones o querys

                    String SQlCommand = "insert into usuarios(idusuario,nombre,apellido,edad," +
                        "telefono,direccion,correo,id_rol,estado) values (" +
                        "@id,@nmb,@ape,@ed,@tel,@dir,@mail,@rol,@est" +
                        ");";

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    //abro conexion
                    conection.Open();
                    //definiendo los datos
                    cls_md5Generator md5 = new cls_md5Generator();
                    
                    string id_user = md5.fn_GenerateMd5Hash();
                    Console.WriteLine("Usuario ID : " + id_user);

                    this.id_ususer = id_user;
                    command.Parameters.AddWithValue("@id", id_user);
                    command.Parameters.AddWithValue("@nmb", usuario.Nombre);
                    command.Parameters.AddWithValue("@ape", usuario.Apellido);
                    command.Parameters.AddWithValue("@ed", usuario.Edad);
                    command.Parameters.AddWithValue("@tel", usuario.Telefono);
                    command.Parameters.AddWithValue("@dir", usuario.Direccion);
                    command.Parameters.AddWithValue("@mail", usuario.Correo);
                    command.Parameters.AddWithValue("@rol", 2); //automaticamente asigna el 2 por ser tipo usuario
                    command.Parameters.AddWithValue("@est", 0);

                    command.ExecuteNonQuery();

                    //verificamos si el usuario existe en la db
                    VerifyData dt = new VerifyData();

                    bool userExist = dt.fn_verifyUserById(id_user); 


                //retornamos el dato
                    return userExist;
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

        }//end 

        public Boolean NewUserAccount(cuentaModel cuenta)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {
                    //ejecuto las peticiones o querys

                    String SQlCommand = "insert into cuenta(id_cuenta,id_usuario,u_name,u_pass," +
                        "u_state) values (" +
                        "@id,@iduser,@username,@pass,@state"+
                        ");";

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    //abro conexion
                    conection.Open();
                    //definiendo los datos
                    cls_md5Generator md5 = new cls_md5Generator();

                    string id_account = md5.fn_GenerateMd5Hash();
                    String userpass = md5.fn_MD5Builder(cuenta.U_pass);
                    Console.WriteLine("Usuario ID : " + id_account);
                    command.Parameters.AddWithValue("@id", id_account);
                    command.Parameters.AddWithValue("@iduser", cuenta.Id_usuario);
                    command.Parameters.AddWithValue("@username", cuenta.U_name);
                    command.Parameters.AddWithValue("@pass", userpass.Trim());
                    command.Parameters.AddWithValue("@state", 0);

                    command.ExecuteNonQuery();

                    //verificamos si el usuario existe en la db
                    VerifyData dt = new VerifyData();

                    bool userExist = dt.fn_verifyAccountById(id_account);


                    //retornamos el dato
                    return userExist;
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

        }//end 


        //-----------------------------------
    }
}
