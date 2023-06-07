using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.UsuarioModel;
using webApi_Turismo.models.vistaModels.cuentaDetalle;

namespace webApi_Turismo.functions.UsersApi.usuarioData
{
    //retorna informacion acerca de un usuario , tanto especifica como tambien el listado de todos los usuarios en la tabla usuarios

    public class usuarioDataInfoFuncs
    {
        //obtiene el listado de los usuarios que estan en tabla usuarios
        public List<UsuarioModel> GetUsuariosList()
        {
            var usuarios = new List<UsuarioModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vusuarios";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UsuarioModel modelo = new UsuarioModel();

                                usuarios.Add(new UsuarioModel
                                {
                                    Idusuario = (String)reader["idusuario"].ToString(),
                                    Nombre = (String)reader["nombre"].ToString(),
                                    Apellido = (String)reader["apellido"].ToString(),
                                    Edad = (int)reader["edad"],
                                    Telefono = (String)reader["telefono"].ToString(),
                                    Direccion = (String)reader["direccion"].ToString(),
                                    Correo = (String)reader["correo"],
                                    Id_rol = (int)reader["id_rol"],
                                    Estado = (int)reader["estado"],

                                });
                            }
                        }
                    }


                    if (usuarios != null)
                    {
                        return usuarios;
                    }
                    else
                    {
                        usuarios.Add(new UsuarioModel
                        {
                            Idusuario = "null",
                            Nombre = "null",
                            Apellido = "null",
                            Edad = -1,
                            Telefono = "null",
                            Direccion = "null",
                            Correo = "null",
                            Id_rol = -1,
                            Estado = -1,
                        });

                        return usuarios;
                    };
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

                return usuarios;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return usuarios;
            }

        }//end getUsauriosList

        //obtiene los datos de un usuario en particular por su id 
        public UsuarioModel GetUsuarioInfoById(String id)
        {
            UsuarioModel dataUsuario = new UsuarioModel();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    Console.WriteLine("entro para obtener informacion del usuario");
                    String SQlCommand = "SELECT * FROM vusuarios where idusuario = @id_usuario";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {

                        command.Parameters.Add("@id_usuario", System.Data.SqlDbType.VarChar);
                        command.Parameters["@id_usuario"].Value = id.Trim();

                        using (var reader = command.ExecuteReader())
                        {
                            Console.WriteLine("leyendo datos de usuario");
                            while (reader.Read())
                            {
                                dataUsuario.Idusuario = (String)reader["idusuario"].ToString();
                                dataUsuario.Nombre = (String)reader["nombre"].ToString();
                                dataUsuario.Apellido = (String)reader["apellido"].ToString();
                                dataUsuario.Edad = (int)reader["edad"];
                                dataUsuario.Telefono = (String)reader["telefono"].ToString();
                                dataUsuario.Direccion = (String)reader["direccion"].ToString(); 
                                dataUsuario.Correo = (String)reader["correo"].ToString();
                                dataUsuario.Id_rol = (int)reader["id_rol"];
                                dataUsuario.Estado = (int)reader["estado"];  
                            }
                        }
                    }


                    if (dataUsuario != null)
                    {
                        Console.WriteLine("No se obtuvo datos de usuario fallo en el formato");
                        return dataUsuario;
                    }
                    else
                    {

                        dataUsuario.Idusuario = "null";
                        dataUsuario.Nombre = "null";
                        dataUsuario.Apellido = "null";
                        dataUsuario.Edad = -1;
                        dataUsuario.Telefono = "null";
                        dataUsuario.Direccion = "null";
                        dataUsuario.Correo = "null";
                        dataUsuario.Id_rol = -1;
                        dataUsuario.Estado = -1;
                       

                        return dataUsuario;
                    };
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

                return dataUsuario;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return dataUsuario;
            }

        }//end user info by id

        //obtiene los datos de un usuario en particular por su nombre de usuario
        public cuentaDetalle GetUserAccountDetailsByUserName(String user_name)
        {
            cuentaDetalle dataUsuario = new cuentaDetalle();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    Console.WriteLine("entro para obtener informacion del usuario");
                    String SQlCommand = "SELECT * FROM vuserdetailAll WHERE u_name = @user";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                       
                        //command.Parameters.AddWithValue("@user", "henry15ea");

                        command.Parameters.Add("@user", System.Data.SqlDbType.VarChar);
                        command.Parameters["@user"].Value = user_name.ToString().Trim();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataUsuario.Id_cuenta = (String)reader["id_cuenta"].ToString();
                                dataUsuario.U_name = (String)reader["u_name"].ToString();
                                dataUsuario.Id_usuario = (String)reader["id_usuario"].ToString();
                                dataUsuario.Nombre = (String)reader["nombre"].ToString();
                                dataUsuario.Correo = (String)reader["correo"].ToString();
                                dataUsuario.Id_rol = int.Parse(reader["id_rol"].ToString());
                                dataUsuario.U_state = (Boolean)reader["u_state"];

                            }
                        }
                    }


                    if (dataUsuario != null)
                    {
                        return dataUsuario;
                    }
                    else
                    {

                        dataUsuario.Id_cuenta = "null";
                        dataUsuario.U_name = "null";
                        dataUsuario.Id_usuario = "null";
                        dataUsuario.Nombre = "null";
                        dataUsuario.Correo = "null";
                        dataUsuario.Id_rol = -1;
                        dataUsuario.U_state = false;

                        return dataUsuario;
                    };
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

                return dataUsuario;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return dataUsuario;
            }

        }//end 
        //

    }//fin clase
}//fin namespace
