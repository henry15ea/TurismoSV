using System.Data.SqlClient;
using webApi_Turismo.models;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.UsersApi
{
    public class facturasReservadasFuncs
    {
        public List<vFacturaEmitidaByUsuarioModel> GetFacuraEmitidabyUserList(generalModel data)
        {
            var dataInfo = new List<vFacturaEmitidaByUsuarioModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from vFacturaEmitidaByUsuario  where rol = 2 and usuario = @uname and estado = 'NE'";

                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        command.Parameters.AddWithValue("@uname", data.Item.ToString());
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vFacturaEmitidaByUsuarioModel modelo = new vFacturaEmitidaByUsuarioModel();

                                dataInfo.Add(new vFacturaEmitidaByUsuarioModel
                                {
                                    Id_factura = (String)reader["id_factura"].ToString(),
                                    Paquete = (String)reader["paquete"].ToString(),
                                    Pasarela = (String)reader["pasarela"].ToString(),
                                    Descuento = (String)reader["descuento"].ToString(),
                                    Monto = (String)reader["monto"].ToString(),
                                    Total = (String)reader["total"].ToString(),
                                    Cupos = (String)reader["cupos"].ToString(),
                                    Usuario = (String)reader["usuario"].ToString(),
                                    Estado = (String)reader["estado"].ToString(),

                                });
                            }
                        }
                    }


                    if (dataInfo != null)
                    {
                        return dataInfo;
                    }
                    else
                    {
                        dataInfo.Add(new vFacturaEmitidaByUsuarioModel
                        {
                            Id_factura = "null",
                            Paquete = "null",
                            Pasarela = "null",
                            Descuento = "null",
                            Monto = "null",
                            Total = "null",
                            Cupos = "null",
                            Usuario = "null",
                            Estado = "null",
                        });

                        return dataInfo;
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

                return dataInfo;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return dataInfo;
            }

        }//end getUsauriosList
    }
}
