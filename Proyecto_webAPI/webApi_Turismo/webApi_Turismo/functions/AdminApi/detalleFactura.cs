using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.AdminApi
{
    public class detalleFacturaFuncs
    {
        private String id_Generado;
        protected usuarioData udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevoDetalleFactura(cInDetalleFactura dataModel)
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
                    udata = new usuarioData();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(1))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "insert detalle formapago(" +
                                "iddetalle,idencabezado,idpaqueted,precio," +
                                "descuento,monto,cupos" +
                                ") values(@idgen,@idfact,@idpkg,@precio,@desc,@mnt,@cups)";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            cls_md5Generator md5 = new cls_md5Generator();

                            string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("encabezadoData ID : " + idhead);
                            Id_Generado = idhead;

                            command.Parameters.AddWithValue("@idgen", idhead);
                            command.Parameters.AddWithValue("@idfact", dataModel.Idencabezado.Trim());                          
                            command.Parameters.AddWithValue("@idpkg", dataModel.Idpaqueted.Trim());                   
                            command.Parameters.AddWithValue("@precio", dataModel.Precio);
                            command.Parameters.AddWithValue("@desc", dataModel.Descuento);
                            command.Parameters.AddWithValue("@mnt", dataModel.Monto);
                            command.Parameters.AddWithValue("@cups", dataModel.Cupos);

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

        public Boolean fn_deleteDetalleFactura(cDeleteModel dataModel)
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
                    udata = new usuarioData();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(1))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "DELETE FROM detalle WHERE iddetalle=@idgen";

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

        public Boolean fn_updateDetalleFactura(cUpDetalleFacturaModel dataModel)
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
                    udata = new usuarioData();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(1))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "UPDATE detalle SET " +
                                "idencabezado=@idfact," +
                                "idpaqueted=@idpkg," +
                                "precio=@precio," +
                                "descuento=@desc," +
                                "monto=@mnt," +
                                "cupos=@cups" +
                                " WHERE iddetalle = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Iddetalle);
                            Id_Generado = dataModel.Iddetalle;

                            command.Parameters.AddWithValue("@idgen", id_Generado.Trim());
                            command.Parameters.AddWithValue("@idfact", dataModel.Idencabezado.Trim()); 
                            command.Parameters.AddWithValue("@idpkg", dataModel.Idpaqueted.Trim());
                            command.Parameters.AddWithValue("@desc", dataModel.Descuento);
                            command.Parameters.AddWithValue("@mnt", dataModel.Monto);
                            command.Parameters.AddWithValue("@cups", dataModel.Cupos);

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

        public List<vDetalleFactura> GetDetalleFacturaList()
        {
            var infoPaquetes = new List<vDetalleFactura>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * from vdetalleFacturaExt ORDER BY id_registro DESC";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vDetalleFactura modelo = new vDetalleFactura();

                                infoPaquetes.Add(new vDetalleFactura
                                {
                                    Id_registro = (String)reader["id_registro"].ToString(),
                                    Id_factura = (String)reader["id_factura"].ToString(),
                                    Paquete = (String)reader["paquete"].ToString(),
                                    Descripcion = (String)reader["descripcion"].ToString(),
                                    Direccion = (String)reader["direccion"].ToString(),
                                    Img = (String)reader["img"].ToString(),
                                    Precio = Decimal.Parse(reader["precio"].ToString()),
                                    Descuento = Decimal.Parse(reader["descuento"].ToString()),
                                    Monto = Decimal.Parse(reader["monto"].ToString()),
                                    Total = Decimal.Parse(reader["total"].ToString()),
                                    Cupos_reservados = int.Parse(reader["cupos_reservados"].ToString())

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
                        infoPaquetes.Add(new vDetalleFactura
                        {
                            Id_registro = "null",
                            Id_factura = "null",
                            Paquete = "null",
                            Descripcion="null",
                            Direccion="null",
                            Img = "null",
                            Precio = 0,
                            Descuento = 0,
                            Monto = 0,
                            Total = 0,
                            Cupos_reservados=0,
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
}// end namespaces
