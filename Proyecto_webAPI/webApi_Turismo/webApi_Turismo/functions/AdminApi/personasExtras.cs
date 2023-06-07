using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.AdminApi
{
    public class personasExtrasFuncs
    {
        private String id_Generado;
        protected usuarioDataInfo udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevaPersonaExtra(cInPersonasExtras dataModel)
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
                            String SQlCommand = "insert into personasextras(" +
                                "idagregado,nombre,apellido,n_doc,edad,iddetalle,idcuenta" +
                                ") values(@idgen,@nmb,@apel,@docn,@ed,@idfact,@idc)";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            cls_md5Generator md5 = new cls_md5Generator();

                            string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("encabezadoData ID : " + idhead);
                            Id_Generado = idhead;

                            command.Parameters.AddWithValue("@idgen", idhead);
                            command.Parameters.AddWithValue("@nmb", dataModel.Nombre.ToUpper().Trim());
                            command.Parameters.AddWithValue("@apel", dataModel.Apellido.ToUpper().Trim());
                            command.Parameters.AddWithValue("@docn", dataModel.N_doc.Trim());
                            command.Parameters.AddWithValue("@ed", dataModel.Edad);
                            command.Parameters.AddWithValue("@idfact", dataModel.Iddetalle.Trim());
                            command.Parameters.AddWithValue("@idc", dataModel.Idcuenta.Trim());

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

        public Boolean fn_deletePersonaExtra(cDeleteModel dataModel)
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
                            String SQlCommand = "DELETE FROM personasextras WHERE idagregado=@idgen";

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

        public Boolean fn_updatePersonaExtra(cUpPersonasExtras dataModel)
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
                            String SQlCommand = "UPDATE adicionales SET " +
                                "nombre=@nmb," +
                                "apellido=@apel," +
                                "n_doc=@docn," +
                                "edad=@ed," +
                                "iddetalle=@idfact," +
                                "idcuenta=@idc" +
                                " WHERE idagregado = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Idagregado);
                            Id_Generado = dataModel.Idagregado.Trim();

                            command.Parameters.AddWithValue("@idgen", id_Generado);
                            command.Parameters.AddWithValue("@nmb", dataModel.Nombre.ToUpper().Trim());
                            command.Parameters.AddWithValue("@apel", dataModel.Apellido.ToUpper().Trim());
                            command.Parameters.AddWithValue("@docn", dataModel.N_doc.Trim());
                            command.Parameters.AddWithValue("@ed", dataModel.Edad);
                            command.Parameters.AddWithValue("@idfact", dataModel.Iddetalle.Trim());
                            command.Parameters.AddWithValue("@idc", dataModel.Idcuenta.Trim());

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

        public List<vPersonasExtrasExt> GetPersonaExtraList()
        {
            var infoPaquetes = new List<vPersonasExtrasExt>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vpersonasExtrasext ORDER BY registro DESC";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vPersonasExtrasExt modelo = new vPersonasExtrasExt();

                                infoPaquetes.Add(new vPersonasExtrasExt
                                {
                                    Id_registro = (String)reader["id_registro"].ToString(),
                                    Invitado = (String)reader["invitado"].ToString(),
                                    N_documento = (String)reader["n_documento"].ToString(),
                                    Edad = int.Parse((String)reader["edad"].ToString()),
                                    Cuenta_titular = (String)reader["cuenta_titular"].ToString(),
                                    Titular = (String)reader["titular"].ToString(),
                                    Correo = (String)reader["correo"].ToString(),
                                    Telefono = (String)reader["telefono"].ToString(),
                                    Paquete = (String)reader["paquete"].ToString(),
                                    Registro = (String)reader["registro"].ToString(),
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
                        infoPaquetes.Add(new vPersonasExtrasExt
                        {
                           Id_registro = "null",
                           Invitado = "null",
                           N_documento = "null",
                           Edad = 0,
                           Cuenta_titular= "null",
                           Titular= "null",
                           Correo = "null",
                           Telefono= "null",
                           Paquete= "null",
                           Registro = "null",
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
    }//end class
}//end namespaces
