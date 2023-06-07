using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.AdminApi
{
    public class encabezadoFacturaFuncs
    {
        private String id_Generado;
        protected usuarioDataInfo udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevoEncabezadoFactura(cInEncabezado dataModel)
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
                            String SQlCommand = "insert into encabezado(" +
                                "idencabezado,idcuenta,idformapago,descuento,monto,state_emited" +
                                ") values(@idgen,@idcuenta,@idfpago,@desc,@monto,@stse)";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            cls_md5Generator md5 = new cls_md5Generator();

                            string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("encabezadoData ID : " + idhead);
                            Id_Generado = idhead;

                            command.Parameters.AddWithValue("@idgen", idhead);
                            command.Parameters.AddWithValue("@idcuenta", dataModel.Idcuenta.ToUpper());
                            command.Parameters.AddWithValue("@idfpago", dataModel.Idformapago.Trim());
                            command.Parameters.AddWithValue("@desc", dataModel.Descuento);
                            command.Parameters.AddWithValue("@monto", dataModel.Monto);
                            command.Parameters.AddWithValue("@stse", dataModel.State_emited);

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

        public Boolean fn_deleteEncabezadoFactura(cDeleteModel dataModel)
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
                            String SQlCommand = "UPDATE encabezado SET state_emited=1  WHERE idencabezado=@idgen";

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

        public Boolean fn_updateEncabezadoFactura(cUpEncabezado dataModel)
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
                            String SQlCommand = "UPDATE encabezado SET " +
                                "idcuenta=@idcuenta," +
                                "idformapago=@idfpago," +
                                "descuento=@desc," +
                                "monto=@mnt," +
                                "state_emited=@sts " +
                                "WHERE idencabezado = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Idformapago);
                            Id_Generado = dataModel.Idformapago.Trim();

                            command.Parameters.AddWithValue("@idgen", id_Generado);
                            command.Parameters.AddWithValue("@idcuenta", dataModel.Idcuenta.Trim());
                            command.Parameters.AddWithValue("@idfpago", dataModel.Idformapago.Trim());
                            command.Parameters.AddWithValue("@desc", dataModel.Descuento);
                            command.Parameters.AddWithValue("@mnt", dataModel.Monto);
                            command.Parameters.AddWithValue("@sts", dataModel.State_emited);

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

        public List<vencabezadoExt> GetEncabezadoFacuturaList()
        {
            var infoPaquetes = new List<vencabezadoExt>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * from vencabezadoext v order by v.fecha DESC;";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vencabezadoExt modelo = new vencabezadoExt();

                                infoPaquetes.Add(new vencabezadoExt
                                {
                                    Id_factura = (String)reader["id_factura"].ToString(),
                                    Nombre = (String)reader["nombre"].ToString(),
                                    Apellido = (String)reader["apellido"].ToString(),
                                    Edad = (String)reader["edad"].ToString(),
                                    Telefono = (String)reader["telefono"].ToString(),
                                    Direccion = (String)reader["direccion"].ToString(),
                                    Correo = (String)reader["correo"].ToString(),
                                    MetodoPago = (String)reader["metodoPago"].ToString(),
                                    Descuendo= (String)reader["descuento"].ToString(),
                                    Monto = (String)reader["monto"].ToString(),
                                    Fecha = (String)reader["fecha"].ToString(),
                                    Emitido = (String)reader["emitido"].ToString(),
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
                        infoPaquetes.Add(new vencabezadoExt
                        {
                            Id_factura = "null",
                            Nombre = "null",
                            Apellido= "null",
                            Edad = "null",
                            Telefono= "null",
                            Direccion= "null",
                            Correo= "null",
                            MetodoPago= "null",
                            Descuendo = "null",
                            Monto = "null",
                            Fecha= "null",
                            Emitido= "null",
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
