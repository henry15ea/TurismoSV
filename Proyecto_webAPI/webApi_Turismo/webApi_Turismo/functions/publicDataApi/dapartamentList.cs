using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.utils.Conection_database;
using webApi_Turismo.utils.cls_md5Generator;
using webApi_Turismo.models.mododelsdb;

namespace webApi_Turismo.functions.publicDataApi.dapartamentList
{
    public class dapartamentList
    {

        public List<departamentosModel> GetDepartamentList()
        {
            var departamentos = new List<departamentosModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vdepartamentos";



                        conection.Open();
                        using (var command = new SqlCommand(SQlCommand, conection))
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    departamentosModel modelo = new departamentosModel();

                                    departamentos.Add(new departamentosModel
                                    {
                                        Iddepartamento = (string)reader["iddepartamento"],
                                        Nombre = (string)reader["nombre"]
                                    });
                                }
                            }
                        }
                    

                    if (departamentos != null)
                    {
                        return departamentos;
                    }
                    else
                    {
                        departamentos.Add(new departamentosModel
                        {
                            Iddepartamento = "null",
                            Nombre = "none"
                        });

                        return departamentos;
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

                return departamentos;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return departamentos;
            }

        }//end 
    }
}
