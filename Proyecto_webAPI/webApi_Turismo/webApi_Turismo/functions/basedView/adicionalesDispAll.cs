using System.Data.SqlClient;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.models.vistaModels.vadicionalesModel;
using webApi_Turismo.models.vistaModels.vidAdicionalModel;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.basedView.adicionalesDispAll
{
    public class adicionalesDispAll
    {
        //init  class
        public List<vadicionalesModel> GetAdicionalesAllList()
        {
            var infoPaquetes = new List<vadicionalesModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vadicionalesDetalle";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vadicionalesModel modelo = new vadicionalesModel();

                                infoPaquetes.Add(new vadicionalesModel
                                {
                                    Id_adicional = (string)reader["id_adicional"],
                                    Id_paquete = (string)reader["id_paquete"],
                                    Nmb_paquete = (string)reader["nmb_paquete"],
                                    Nmb_adicional = (string)reader["nmb_adicional"],
                                    Dsc_adicional = (string)reader["dsc_adicional"],
                                    Precio_adicional = (decimal)reader["precio_adicional"],
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

                        infoPaquetes.Add(new vadicionalesModel
                        {
                            Id_adicional = "null",
                            Id_paquete = "null",
                            Nmb_paquete = "null",
                            Nmb_adicional = "null",
                            Dsc_adicional = "null",
                            Precio_adicional = 0,
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

        public List<vadicionalesModel> GetAdicionalesByPckgIdList(vidAdicionalModel idpkg)
        {
            var infoPaquetes = new List<vadicionalesModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from vadicionalesDetalle where id_paquete = @idpckg";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        command.Parameters.Add("@idpckg", System.Data.SqlDbType.VarChar);
                        command.Parameters["@idpckg"].Value = idpkg.id_paquete.Trim();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                vadicionalesModel modelo = new vadicionalesModel();

                                infoPaquetes.Add(new vadicionalesModel
                                {
                                    Id_adicional = (string)reader["id_adicional"],
                                    Id_paquete = (string)reader["id_paquete"],
                                    Nmb_paquete = (string)reader["nmb_paquete"],
                                    Nmb_adicional = (string)reader["nmb_adicional"],
                                    Dsc_adicional = (string)reader["dsc_adicional"],
                                    Precio_adicional = (decimal)reader["precio_adicional"],
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

                        infoPaquetes.Add(new vadicionalesModel
                        {
                            Id_adicional = "null",
                            Id_paquete = "null",
                            Nmb_paquete = "null",
                            Nmb_adicional = "null",
                            Dsc_adicional = "null",
                            Precio_adicional = 0,
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
        //final class
    }
}
