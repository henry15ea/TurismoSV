using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.AdminApi
{
    public class formasPago
    {
        private String id_Generado;
        protected usuarioDataInfo udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevoFpago(cFormasPagoModel dataModel)
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
                            String SQlCommand = "insert into formapago(idformapago,metodopago,descripcion,estado" +
                                ") values(@idgen,@nmb,@desc,@precio,@ests)";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            cls_md5Generator md5 = new cls_md5Generator();

                            string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("encabezadoData ID : " + idhead);
                            Id_Generado = idhead;

                            command.Parameters.AddWithValue("@idgen", idhead);
                            command.Parameters.AddWithValue("@nmb", dataModel.Metodopago.ToUpper());
                            command.Parameters.AddWithValue("@desc", dataModel.Descripcion.Trim());
                            command.Parameters.AddWithValue("@ests", dataModel.Estado);

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

        public Boolean fn_deleteFpago(cDeleteModel dataModel)
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
                            String SQlCommand = "DELETE FROM formapago WHERE idformapago=@idgen";

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

        public Boolean fn_updateFpago(cUpFPagoModel dataModel)
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
                            String SQlCommand = "UPDATE adicionales SET metodopago=@nmb,descripcion=@desc" +
                                ",estado=@sts WHERE idformapago = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Idformapago);
                            Id_Generado = dataModel.Idformapago;

                            command.Parameters.AddWithValue("@idgen", id_Generado);
                            command.Parameters.AddWithValue("@nmb", dataModel.Metodopago.ToUpper().Trim());
                            command.Parameters.AddWithValue("@desc", dataModel.Descripcion.Trim());
                            command.Parameters.AddWithValue("@sts", dataModel.Estado);

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

        public List<formasPagoModel> GetFormaPagoList()
        {
            var infoPaquetes = new List<formasPagoModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from vformapago v  order by v.idformapago  ASC";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                formasPagoModel modelo = new formasPagoModel();

                                infoPaquetes.Add(new formasPagoModel { 
                                    Idformapago = (String)reader["idformapago"].ToString(),
                                    Metodopago = (String)reader["metodopago"].ToString(),
                                    Descripcion = (String)reader["descripcion"].ToString(),
                                    Estado = Boolean.Parse(reader["estado"].ToString()),
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
                        infoPaquetes.Add(new formasPagoModel
                        {
                           Idformapago = "null",
                           Metodopago="null",
                           Descripcion = "null",
                           Estado = false
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
