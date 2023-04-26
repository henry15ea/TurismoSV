using System.Data.SqlClient;
using webApi_Turismo.models.mododelsdb;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.publicDataApi.formaPagoList
{
    public class formaPagoList
    {
        public List<formasPagoModel> GetFormaPagoList()
        {
            var fpago = new List<formasPagoModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vformapago";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                formasPagoModel modelo = new formasPagoModel();

                                fpago.Add(new formasPagoModel
                                {
                                    Idformapago = (string)reader["idformapago"],
                                    Metodopago = (string)reader["metodopago"],
                                    Descripcion = (string)reader["descripcion"]
                                });
                            }
                        }
                    }


                    if (fpago != null)
                    {
                        return fpago;
                    }
                    else
                    {
                        fpago.Add(new formasPagoModel
                        {
                            Idformapago = "null",
                            Metodopago = "null",
                            Descripcion = "null",
                        });

                        return fpago;
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

                return fpago;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return fpago;
            }

        }//end 
    }
}
