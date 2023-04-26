using System.Data.SqlClient;
using webApi_Turismo.models.mododelsdb.categoriasModel;
using webApi_Turismo.utils.Conection_database;

namespace webApi_Turismo.functions.publicDataApi.categoriasList
{
    public class categoriasList
    {
        public List<categoriasModel> GetCategoriasList()
        {
            var categorias = new List<categoriasModel>();



            Conection_database cn = new Conection_database();
            try
            {
                SqlConnection conection = cn.GetConnection();
                try
                {
                    String SQlCommand = "SELECT * FROM vcategorias";



                    conection.Open();
                    using (var command = new SqlCommand(SQlCommand, conection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                categoriasModel modelo = new categoriasModel();

                                categorias.Add(new categoriasModel
                                {
                                    Idcategoria = (string)reader["idcategoria"],
                                    Nombre = (string)reader["nombre"],
                                    Descripcion = (string)reader["descripcion"]
                                });
                            }
                        }
                    }


                    if (categorias != null)
                    {
                        return categorias;
                    }
                    else
                    {
                        categorias.Add(new categoriasModel
                        {
                            Idcategoria = "null",
                            Nombre = "null",
                            Descripcion = "null",
                        });

                        return categorias;
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

                return categorias;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return categorias;
            }

        }//end 
    }
}
