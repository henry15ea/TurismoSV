using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.models.mododelsdb.adicionalesModel;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels.cAdicionalesModel;
using webApi_Turismo.models.customModels;

namespace webApi_Turismo.functions.AdminApi.adicionalesFuncs
{
    public class adicionalesFuncs
    {
        private String id_Generado;
        protected usuarioData udata;
        public string Id_Generado { get => id_Generado; set => id_Generado = value; }

        public Boolean fn_nuevoADicional(cAdicionalesModel dataModel)
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
                            String SQlCommand = "insert into adicionales(idadicional,nombre,descripcion,precio" +
                                ") values(@idgen,@nmb,@desc,@precio)";

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
                            command.Parameters.AddWithValue("@desc", dataModel.Descripcion);
                            command.Parameters.AddWithValue("@precio", dataModel.Precio);

                            command.ExecuteNonQuery();


                            state = true;
                        }
                        else {
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

        public Boolean fn_deleteAdicional(cDeleteModel dataModel)
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
                            String SQlCommand = "DELETE FROM adicionales WHERE idadicional=@idgen";

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

        public Boolean fn_updatedAdicional(formasPagoModel dataModel)
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
                            String SQlCommand = "UPDATE adicionales SET nombre=@nmb,descripcion=@desc" +
                                ",precio=@prec WHERE idadicional = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            Console.WriteLine("Updated ID : " + dataModel.Idadicional);
                            Id_Generado = dataModel.Idadicional;

                            command.Parameters.AddWithValue("@idgen", dataModel.Idadicional.Trim());
                            command.Parameters.AddWithValue("@nmb", dataModel.Nombre.ToUpper().Trim());
                            command.Parameters.AddWithValue("@desc", dataModel.Descripcion.Trim());
                            command.Parameters.AddWithValue("@prec", dataModel.Precio);

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

        public List<formasPagoModel> GetCategoriaList()
        {
            var infoPaquetes = new List<formasPagoModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from vadicionales v order by v.nombre ASC";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                formasPagoModel modelo = new formasPagoModel();

                                infoPaquetes.Add(new formasPagoModel
                                {
                                   Idadicional = (String)reader["idadicional"].ToString(),
                                   Nombre = (String)reader["nombre"].ToString(),
                                   Descripcion = (String)reader["descripcion"].ToString(),
                                   Precio = decimal.Parse(reader["precio"].ToString()),

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
                           Idadicional = "null",
                           Nombre = "null",
                           Descripcion = "null",
                           Precio =  0
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
