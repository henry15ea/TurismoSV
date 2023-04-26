using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.ApiModels.departamentosResponseModel
{
    internal class departamentosResponseModel
    {
        string iddepartamento;
        String nombre;

        public string Iddepartamento { get => iddepartamento; set => iddepartamento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
