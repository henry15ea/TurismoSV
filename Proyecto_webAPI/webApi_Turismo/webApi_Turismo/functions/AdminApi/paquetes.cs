using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.AdminApi
{
    public class paquetesFunc
    {
        private String id_Generado;
        protected usuarioDataInfo udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevoPaquete(cinPaquetesModel dataModel)
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
                            String SQlCommand = "insert into paquetes(idpaquete,nombre,descripcion,direccion,idmunicipio," +
                                "idcategoria,img" +
                                ") values(@idgen,@nmb,@desc,@dir,@idmun,@idcat,@src)";

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
                            command.Parameters.AddWithValue("@desc", dataModel.Descripcion.Trim());
                            command.Parameters.AddWithValue("@dir", dataModel.Direccion.Trim());
                            command.Parameters.AddWithValue("@idmun", dataModel.Idmunicipio.Trim());
                            command.Parameters.AddWithValue("@idcat", dataModel.Idcategoria.Trim());
                            command.Parameters.AddWithValue("@src", dataModel.Img.Trim());

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

        public Boolean fn_deletePaquete(cDeleteModel dataModel)
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
                            String SQlCommand = "DELETE FROM paquetes WHERE idpaquete=@idgen";

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

        public Boolean fn_updatePaquete(cUpPaquetes dataModel)
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
                            String SQlCommand = "UPDATE paquetes SET nombre=@nmb,descripcion=@desc," +
                                "direccion=@dir,idmunicipio=@idmun,idcategoria=@idcat,img=@src" +
                                ",estado=@sts WHERE idpaquete = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Idpaquete);
                            Id_Generado = dataModel.Idpaquete;

                            command.Parameters.AddWithValue("@idgen", id_Generado);
                            command.Parameters.AddWithValue("@nmb", dataModel.Nombre.ToUpper());
                            command.Parameters.AddWithValue("@desc", dataModel.Descripcion.Trim());
                            command.Parameters.AddWithValue("@dir", dataModel.Direccion.Trim());
                            command.Parameters.AddWithValue("@idmun", dataModel.Idmunicipio.Trim());
                            command.Parameters.AddWithValue("@idcat", dataModel.Idcategoria.Trim());
                            command.Parameters.AddWithValue("@src", dataModel.Img.Trim());

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

        public List<vpaquetex> GetFormaPaquetesList()
        {
            var infoPaquetes = new List<vpaquetex>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from vpaquetex v order by v.id_paquete DESC;";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vpaquetex modelo = new vpaquetex();

                                infoPaquetes.Add(new vpaquetex
                                {
                                    Id_paquete = (String)reader["id_paquete"].ToString(),
                                    Nombre = (String)reader["nombre"].ToString(),
                                    Descripcion = (String)reader["descripcion"].ToString(),
                                    Direccion = (String)reader["direccion"].ToString(),
                                    Img = (String)reader["img"].ToString(),
                                    Categoria = (String)reader["categoria"].ToString(),
                                    Departamento = (String)reader["departamento"].ToString(),
                                    Municipio = (String)reader["municipio"].ToString(),

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
                        infoPaquetes.Add(new vpaquetex
                        {
                           Id_paquete = "null",
                           Nombre = "null",
                           Descripcion = "null",
                           Direccion="null",
                           Img = "null",
                           Categoria="null",
                           Departamento="null",
                           Municipio="null",
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
