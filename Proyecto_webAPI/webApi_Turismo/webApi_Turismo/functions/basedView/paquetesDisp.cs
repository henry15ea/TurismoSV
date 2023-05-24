using System.Data.SqlClient;
using webApi_Turismo.models;
using webApi_Turismo.models.vistaModels;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.basedView.paquetesDisp
{
    public class paquetesDisp
    {
        //init  class
        public List<detallePaqueteModel> GetPaquetesDisponiblesList()
        {
            var infoPaquetes = new List<detallePaqueteModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT TOP (5) * FROM vpdisponiblesinfo v WHERE v.estado = 0 ORDER BY registro DESC;";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detallePaqueteModel modelo = new detallePaqueteModel();

                                infoPaquetes.Add(new detallePaqueteModel
                                {
                                    Idpaqueted = (string)reader["idpaqueted"],
                                    Nombre = (string)reader["nombre"],
                                    Descripcion = (string)reader["descripcion"],
                                    Direccion = (string)reader["direccion"],
                                    Img = (string)reader["img"],
                                    Precio = (decimal)reader["precio"],
                                    Cupos_disp = (String)reader["cupos_disp"].ToString(),
                                    Cuposllenos = (String)reader["cuposllenos"].ToString(),
                                    Fechainicial = (DateTime)reader["fechainicial"],
                                    Fechafinal = (DateTime)reader["fechafinal"],
                                    Fechreg = (DateTime)reader["registro"],
                                    Estado = (bool)reader["estado"],
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
                        infoPaquetes.Add(new detallePaqueteModel
                        {
                            Idpaqueted = "null",
                            Nombre="null",
                            Descripcion="null",
                            Direccion="null",
                            Img = "null",
                            Precio = 0,
                            Cupos_disp ="0",
                            Cuposllenos="0",
                            Fechafinal = DateTime.Now,
                            Fechainicial= DateTime.Now,
                            Fechreg= DateTime.Now,
                            Estado= false
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

        public List<detallePaqueteModel> GetPaquetesDisponiblesByCategoryList(generalModel itemData)
        {
            var infoPaquetes = new List<detallePaqueteModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "select * from vpkgDispByCategoryId kc where kc.id_categoria = @id order by kc.nombre ASC ;";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        command.Parameters.Add("@id", System.Data.SqlDbType.VarChar);
                        command.Parameters["@id"].Value = itemData.Item.Trim();
                        using (var reader = command.ExecuteReader())
                        {

                            while (reader.Read())
                            {
                                detallePaqueteModel modelo = new detallePaqueteModel();

                                infoPaquetes.Add(new detallePaqueteModel
                                {
                                    Idpaqueted = (string)reader["idpaqueted"],
                                    Nombre = (string)reader["nombre"],
                                    Descripcion = (string)reader["descripcion"],
                                    Direccion = (string)reader["direccion"],
                                    Img = (string)reader["img"],
                                    Precio = (decimal)reader["precio"],
                                    Cupos_disp = (String)reader["cupos_disp"].ToString(),
                                    Cuposllenos = (String)reader["cuposllenos"].ToString(),
                                    Fechainicial = (DateTime)reader["fechainicial"],
                                    Fechafinal = (DateTime)reader["fechafinal"],
                                    Fechreg = (DateTime)reader["registro"],
                                    Estado = (bool)reader["estado"],
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
                        infoPaquetes.Add(new detallePaqueteModel
                        {
                            Idpaqueted = "null",
                            Nombre = "null",
                            Descripcion = "null",
                            Direccion = "null",
                            Img = "null",
                            Precio = 0,
                            Cupos_disp = "0",
                            Cuposllenos = "0",
                            Fechafinal = DateTime.Now,
                            Fechainicial = DateTime.Now,
                            Fechreg = DateTime.Now,
                            Estado = false
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

        //informacion de paquete disponible por id
        public List<detallePaqueteModel> GetPaquetesDisponiblesByIDList(detallePaqueteModel paqueteDetails)
        {
            var infoPaquetes = new List<detallePaqueteModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vpdisponiblesinfo v WHERE v.estado = 0 and v.idpaqueted = @idpkg ORDER BY registro DESC ;";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        command.Parameters.Add("@idpkg", System.Data.SqlDbType.VarChar);

                        command.Parameters["@idpkg"].Value = paqueteDetails.Idpaqueted.Trim();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                detallePaqueteModel modelo = new detallePaqueteModel();

                                infoPaquetes.Add(new detallePaqueteModel
                                {
                                    Idpaqueted = (string)reader["idpaqueted"],
                                    Nombre = (string)reader["nombre"],
                                    Descripcion = (string)reader["descripcion"],
                                    Direccion = (string)reader["direccion"],
                                    Img = (string)reader["img"],
                                    Precio = (decimal)reader["precio"],
                                    Cupos_disp = (String)reader["cupos_disp"].ToString(),
                                    Cuposllenos = (String)reader["cuposllenos"].ToString(),
                                    Fechainicial = (DateTime)reader["fechainicial"],
                                    Fechafinal = (DateTime)reader["fechafinal"],
                                    Fechreg = (DateTime)reader["registro"],
                                    Estado = (bool)reader["estado"],
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
                        infoPaquetes.Add(new detallePaqueteModel
                        {
                            Idpaqueted = "null",
                            Nombre = "null",
                            Descripcion = "null",
                            Direccion = "null",
                            Img = "null",
                            Precio = 0,
                            Cupos_disp = "0",
                            Cuposllenos = "0",
                            Fechafinal = DateTime.Now,
                            Fechainicial = DateTime.Now,
                            Fechreg = DateTime.Now,
                            Estado = false
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
