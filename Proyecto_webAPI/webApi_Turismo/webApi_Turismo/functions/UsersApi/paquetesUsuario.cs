using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.encabezadoModel;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.models.mododelsdb.detalleFacturaModel;
using webApi_Turismo.models.mododelsdb.personasExtrasModel;

namespace webApi_Turismo.functions.UsersApi.paquetesUsuario
{
    public class paquetesUsuario
    {
        private String id_paqueteGenerado;
        protected usuarioData.usuarioData udata;
        public string Id_paqueteGenerado { get => id_paqueteGenerado; set => id_paqueteGenerado = value; }

        public Boolean NuevoEncabezado(encabezadoModel encabezadoData)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {
                    //ejecuto las peticiones o querys

                    String SQlCommand = "insert into encabezado(idencabezado,idcuenta,idformapago,descuento," +
                        "monto,state_emited) values(@id,@idcuenta,@fpago,@desc,@monto,@state)";

                    SqlCommand command = new SqlCommand(SQlCommand, conection);

                    cuentaDetalle ct = new cuentaDetalle();
                    udata = new usuarioData.usuarioData();
                    ct = udata.GetUserAccountDetailsByUserName(encabezadoData.Username.Trim());
                    //abro conexion
                    conection.Open();
                    //definiendo los datos
                    cls_md5Generator md5 = new cls_md5Generator();

                    string idhead = md5.fn_GenerateMd5Hash();
                    Console.WriteLine("encabezadoData ID : " + idhead);
                    id_paqueteGenerado = idhead;    

                    command.Parameters.AddWithValue("@id", idhead);
                    command.Parameters.AddWithValue("@idcuenta", ct.Id_usuario);
                    command.Parameters.AddWithValue("@fpago", encabezadoData.Idformapago);
                    command.Parameters.AddWithValue("@desc", encabezadoData.Descuento);
                    command.Parameters.AddWithValue("@monto", encabezadoData.Monto);
                    command.Parameters.AddWithValue("@state", encabezadoData.State_emited);

                    command.ExecuteNonQuery();

                    //verificamos si el encabezadoData existe en la db


                    



                    //retornamos el dato
                    if (ct != null)
                    {
                        state = true;
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

        public Boolean NuevoDetalleFactura(detalleFacturaModel detalleData)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {
                    //ejecuto las peticiones o querys

                    String SQlCommand = "insert into detalle(iddetalle,idencabezado,idpaqueted,precio," +
                        "descuento,monto,cupos) values(@idetalle,@idheader,@idpkg,@prc,@desc,@mnt,@cps)";

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    //abro conexion
                    conection.Open();
                    //definiendo los datos
                    cls_md5Generator md5 = new cls_md5Generator();

                    string idGenMd5 = md5.fn_GenerateMd5Hash();
                    Console.WriteLine("detalle ID : " + idGenMd5);
                    id_paqueteGenerado = idGenMd5;

                    command.Parameters.AddWithValue("@idetalle", idGenMd5);
                    command.Parameters.AddWithValue("@idheader", detalleData.Idencabezado);
                    command.Parameters.AddWithValue("@idpkg", detalleData.Idpaqueted);
                    command.Parameters.AddWithValue("@prc", detalleData.Precio);
                    command.Parameters.AddWithValue("@desc", detalleData.Descuento);
                    command.Parameters.AddWithValue("@mnt", detalleData.Monto);
                    command.Parameters.AddWithValue("@cps", detalleData.Cupos);

                    command.ExecuteNonQuery();

                    //verificamos si el encabezadoData existe en la db
                    

                    cuentaDetalle ct = new cuentaDetalle();
                    udata = new usuarioData.usuarioData();
                    ct = udata.GetUserAccountDetailsByUserName(detalleData.Username.Trim());



                    //retornamos el dato
                    if (ct != null) {
                        state = true;
                    } else {
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

        public Boolean PersonasExtras(personasExtrasModel detalleData)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {
                    //primero busco al usuario 

                    cuentaDetalle ct = new cuentaDetalle();
                    udata = new usuarioData.usuarioData();
                    ct = udata.GetUserAccountDetailsByUserName(detalleData.Username.Trim());
                    //ejecuto las peticiones o query
                    String SQlCommand = "insert into personasextras(idagregado,nombre,apellido,n_doc," +
                        "edad,iddetalle,idcuenta) values(@idAgregado,@nmb,@apel,@ndoc,@edad,@idet,@idcuenta)";

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    //abro conexion
                    conection.Open();
                   

                    //definiendo los datos
                    cls_md5Generator md5 = new cls_md5Generator();

                    string idGenMd5 = md5.fn_GenerateMd5Hash();
                    Console.WriteLine("Persona Agregada ID : " + idGenMd5);
                    id_paqueteGenerado = idGenMd5;

                    command.Parameters.AddWithValue("@idAgregado", idGenMd5);
                    command.Parameters.AddWithValue("@nmb", detalleData.Nombre);
                    command.Parameters.AddWithValue("@apel", detalleData.Apellido);
                    command.Parameters.AddWithValue("@ndoc", detalleData.N_doc);
                    command.Parameters.AddWithValue("@edad", detalleData.Edad);
                    command.Parameters.AddWithValue("@idet", detalleData.Iddetalle);
                    command.Parameters.AddWithValue("@idcuenta", ct.Id_cuenta);

                    command.ExecuteNonQuery();

                    //verificamos si el encabezadoData existe en la db





                    //retornamos el dato
                    if (ct != null)
                    {
                        state = true;
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

        //end class
    }
}
