using System.Data.SqlClient;
using webApi_Turismo.models.customModels;
using webApi_Turismo.models.vistaModels.cuentaDetalle;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.functions.UsersApi.usuarioData;
using webApi_Turismo.models.mododelsdb.encabezadoModel;
using webApi_Turismo.functions.UsersApi;

namespace webApi_Turismo.functions.UsersApi.reportVerifiedUser
{
    public class reportVerifiedUser
    {
        private encabezadoModel dataUser;
        public Boolean fn_FacturaByUserAIDF(userFacturaModel dataModel)
        {
            Boolean state = false;



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();


                try
                {
                   

                    //evaluo el rol del usuario , sino es admin entonces no permite acceder a crear dato
                    if (!string.IsNullOrEmpty(dataModel.Username) && !string.IsNullOrEmpty(dataModel.Id_factura))
                        {
                            //ejecuto las peticiones o querys
                            String SQlCommand = "select * from vencabezado v WHERE idencabezado = @id_factura AND idcuenta =@user";

                            SqlCommand command = new SqlCommand(SQlCommand, conection);
                            //abro conexion
                            conection.Open();
                            //definiendo los datos
                            command.Parameters.AddWithValue("@id_factura", dataModel.Id_factura.Trim());
                            command.Parameters.AddWithValue("@user", dataModel.Username.Trim());

                            command.ExecuteNonQuery();
                        dataUser = new encabezadoModel();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dataUser.Idencabezado = (String)reader["idencabezado"].ToString();
                                dataUser.Idcuenta = (String)reader["idcuenta"].ToString();
                            }
                        }
                        //verifico los datos que trae la query
                            if (dataUser.Idcuenta != null || dataUser.Idencabezado != null) {
                                state = true;
                            } else {

                                state = false;
                            }

                                
                        }
                        else
                        {
                            state = false;
                        }


                        //fin evaluacion
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
    }
}
