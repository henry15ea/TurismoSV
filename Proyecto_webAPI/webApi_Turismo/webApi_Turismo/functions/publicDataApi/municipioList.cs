using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.models.mododelsdb;

namespace webApi_Turismo.functions.publicDataApi.dapartamentList
{
    public class municipioList
    {

        public List<municipiosModel> GetMunicipiosList()
        {
            var municipios = new List<municipiosModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vmunicipios";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                municipiosModel modelo = new municipiosModel();

                                municipios.Add(new municipiosModel
                                {
                                    Iddepartamento = (string)reader["idmunicipio"],
                                    Nombre = (string)reader["nombre"],
                                    Idmunicipio = (string)reader["iddepartamento"],

                                });
                            }
                        }
                    }


                    if (municipios != null)
                    {
                        return municipios;
                    }
                    else
                    {
                        municipios.Add(new municipiosModel
                        {
                            Iddepartamento = "null",
                            Nombre = "none",
                            Idmunicipio="null",
                        });

                        return municipios;
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

                return municipios;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return municipios;
            }

        }//end 
    }
}
