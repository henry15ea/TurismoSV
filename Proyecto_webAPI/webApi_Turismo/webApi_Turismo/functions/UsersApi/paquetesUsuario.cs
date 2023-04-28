using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.models.mododelsdb.encabezadoModel;

namespace webApi_Turismo.functions.UsersApi.paquetesUsuario
{
    public class paquetesUsuario
    {
        private String id_paqueteGenerado;

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
                        "monto,state_emited) values (" +
                        "@id,@idcuenta,@fpago,@desc,@monto,@state)" +
                        ");";

                    SqlCommand command = new SqlCommand(SQlCommand, conection);
                    //abro conexion
                    conection.Open();
                    //definiendo los datos
                    cls_md5Generator md5 = new cls_md5Generator();

                    string idhead = md5.fn_GenerateMd5Hash();
                    Console.WriteLine("encabezadoData ID : " + idhead);
                    id_paqueteGenerado = idhead;    

                    command.Parameters.AddWithValue("@id", idhead);
                    command.Parameters.AddWithValue("@idcuenta", encabezadoData.Idcuenta);
                    command.Parameters.AddWithValue("@fpago", encabezadoData.Idformapago);
                    command.Parameters.AddWithValue("@desc", encabezadoData.Descuento);
                    command.Parameters.AddWithValue("@monto", encabezadoData.Monto);
                    command.Parameters.AddWithValue("@state", encabezadoData.State_emited);

                    command.ExecuteNonQuery();

                    //verificamos si el encabezadoData existe en la db
                    VerifyData dt = new VerifyData();

                    bool userExist = dt.fn_verifyUserById(idhead);


                    //retornamos el dato
                    return userExist;
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
