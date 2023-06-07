using System.Data.SqlClient;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.UsersApi
{
    public class facturaUpdateStatus
    {
        protected usuarioDataInfoFuncs udata;
        public String Id_paqueteGenerado;
        public Boolean fn_updatedFacturaState(cUpFacturaStateEmited dataModel)
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
                    udata = new usuarioDataInfoFuncs();
                    ct = udata.GetUserAccountDetailsByUserName(dataModel.Username.Trim());

                    //verificamos si el encabezadoData existe en la db

                    //retornamos el dato
                    if (ct != null)
                    {
                        //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                        if (ct.Id_rol.Equals(2))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "UPDATE encabezado SET idformapago=@fpg,state_emited=@stcs" +
                                " WHERE idencabezado = @idgen";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            //cls_md5Generator md5 = new cls_md5Generator();

                            //string idhead = md5.fn_GenerateMd5Hash();
                            // Console.WriteLine("Updated ID : " + dataModel.Idadicional);
                            Id_paqueteGenerado = dataModel.Id_encabezado;

                            command.Parameters.AddWithValue("@idgen", dataModel.Id_encabezado.Trim());
                            command.Parameters.AddWithValue("@fpg", dataModel.Id_fpago.ToUpper().Trim());
                            command.Parameters.AddWithValue("@stcs", 1);

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

    }//end class
}//end namespaces
