using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.AdminApi
{
    public class usuarioFuncts
    {
        private String id_Generado;
        protected usuarioDataInfo udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevoUsuario(cInUsuarioModel dataModel)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {

                    //busco al usuario y si este es valido
                    cuentaDetalle ct = new cuentaDetalle();
                    udata = new usuarioDataInfo();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(1))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "insert into usuarios(idusuario,nombre," +
                                "apellido,edad,telefono,direccion,correo," +
                                "id_rol,estado" +
                                ") values(@idgen,@nmb,@apel,@edad,@tel,@dir,@mail,@role,@est)";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            cls_md5Generator md5 = new cls_md5Generator();

                            string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("encabezadoData ID : " + idhead);
                            Id_Generado = idhead;

                            command.Parameters.AddWithValue("@idgen", idhead);
                            command.Parameters.AddWithValue("@nmb", dataModel.Nombre.ToUpper());
                            command.Parameters.AddWithValue("@apel", dataModel.Apellido.Trim());
                            command.Parameters.AddWithValue("@edad", dataModel.Edad);
                            command.Parameters.AddWithValue("@tel", clsTelephoneFormat.GetTelephoneFormat(dataModel.Telefono.Trim()));
                            command.Parameters.AddWithValue("@dir", dataModel.Direccion.ToUpper().Trim());
                            command.Parameters.AddWithValue("@mail", dataModel.Correo.Trim());
                            command.Parameters.AddWithValue("@role", dataModel.Id_rol);
                            command.Parameters.AddWithValue("@est", dataModel.Estado);

                            command.ExecuteNonQuery();


                            state = true;
                        }
                        else
                        {
                            state = false;
                        }


                        //fin evaluacion

                    }
                    else
                    {
                        state = false;
                    }
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

        public Boolean fn_deleteUsuario(cDeleteModel dataModel)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {

                    //busco al usuario y si este es valido
                    cuentaDetalle ct = new cuentaDetalle();
                    udata = new usuarioDataInfo();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(1))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "UPDATE usuarios SET estado=1 WHERE idusuario=@idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos


                            string idhead = dataModel.Id_element.Trim();
                            Console.WriteLine("DELETE ID : " + idhead);
                            Id_Generado = idhead;

                            command.Parameters.AddWithValue("@idgen", idhead);

                            command.ExecuteNonQuery();


                            state = true;
                        }
                        else
                        {
                            state = false;
                        }


                        //fin evaluacion

                    }
                    else
                    {
                        state = false;
                    }
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

        public Boolean fn_updateUsuario(cUpUsuarioModel dataModel)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {

                    //busco al usuario y si este es valido
                    cuentaDetalle ct = new cuentaDetalle();
                    udata = new usuarioDataInfo();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(1))
                        {
                            
                            //ejecuto las peticiones o querys
                            String SQlCommand = "UPDATE usuarios SET nombre=@nmb," +
                                "apellido=@apel,edad=@edad,telefono=@tel,direccion=@dir,correo=@mail," +
                                "id_rol=@role,estado=@est" + " WHERE idusuario = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Idusuario);
                            Id_Generado = dataModel.Idusuario.Trim();

                            command.Parameters.AddWithValue("@idgen", Id_Generado);
                            command.Parameters.AddWithValue("@nmb", dataModel.Nombre.ToUpper());
                            command.Parameters.AddWithValue("@apel", dataModel.Apellido.Trim());
                            command.Parameters.AddWithValue("@edad", dataModel.Edad);
                            command.Parameters.AddWithValue("@tel", clsTelephoneFormat.GetTelephoneFormat(dataModel.Telefono.Trim()));
                            command.Parameters.AddWithValue("@dir", dataModel.Direccion.ToUpper().Trim());
                            command.Parameters.AddWithValue("@mail", dataModel.Correo.Trim());
                            command.Parameters.AddWithValue("@role", dataModel.Id_rol);
                            command.Parameters.AddWithValue("@est", dataModel.Estado);

                            command.ExecuteNonQuery();


                            state = true;
                        }
                        else
                        {
                            state = false;
                        }


                        //fin evaluacion

                    }
                    else
                    {
                        state = false;
                    }
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

        public List<vdetalleUsuarioModel> GetUsuarioList()
        {
            var infoPaquetes = new List<vdetalleUsuarioModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from  vdetalleUsuario v";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vdetalleUsuarioModel modelo = new vdetalleUsuarioModel();

                                infoPaquetes.Add(new vdetalleUsuarioModel
                                {
                                   Id = (String)reader["id"].ToString(),
                                   Nombre = (String)reader["nombre"].ToString(),
                                   Apellido = (String)reader["apellido"].ToString(),
                                   Edad = (String)reader["edad"].ToString(),
                                   Telefono = (String)reader["telefono"].ToString(),
                                   Direccion = (String)reader["direccion"].ToString(),
                                   Correo = (String)reader["correo"].ToString(),
                                   Rol = (String)reader["rol"].ToString(),
                                   Estado = (String)reader["estado"].ToString(),
                                   Registro = (String)reader["registro"].ToString()
                                });
                            }
                        }
                    }


                    if (infoPaquetes != null)
                    {
                        return infoPaquetes;
                    }
                    else
                    {
                        infoPaquetes.Add(new vdetalleUsuarioModel
                        {
                            Id = "null",
                            Nombre="null",
                            Apellido="null",
                            Telefono="null",
                            Direccion="null",
                            Correo ="null",
                            Rol ="null",
                            Estado ="null",
                            Registro ="null",

                        });

                        return infoPaquetes;
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

                return infoPaquetes;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return infoPaquetes;
            }

        }//end 
    }
}
