using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.categoriasModel
{
    internal class categoriasModel
    {
        String idcategoria;
        String nombre;
        String descripcion;
        string img ;

        

        public string Idcategoria { get => idcategoria; set => idcategoria = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Img { get => img; set => img = value; }
    }
}
