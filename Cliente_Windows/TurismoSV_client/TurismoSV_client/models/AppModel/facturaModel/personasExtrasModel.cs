using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.facturaModel.personasExtrasModel
{
    internal class personasExtrasModel
    {

        private String nombre;
        private String apellido;
        private String n_doc;
        private int edad;
        private String iddetalle;
        private String username;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string N_doc { get => n_doc; set => n_doc = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Iddetalle { get => iddetalle; set => iddetalle = value; }
        public string Username { get => username; set => username = value; }
    }
}
