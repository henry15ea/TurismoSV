using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.models.AppModel.cuentaModel
{
    internal class cuentaModel
    {
        private String idusuario;
        private string nombre;
        private string apellido;
        private int edad;
        private string telefono;
        private string direccion;
        private string correo;
        private int id_rol;
        private int estado;

        private String id_cuenta;
        private String u_name;
        private String u_pass;
        private String id_usuario;
        private int u_state;

        public string Id_cuenta { get => id_cuenta; set => id_cuenta = value; }
        public string U_name { get => u_name; set => u_name = value; }
        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public int U_state { get => u_state; set => u_state = value; }

        public string Idusuario { get => idusuario; set => idusuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public int Id_rol { get => id_rol; set => id_rol = value; }
        public int Estado { get => estado; set => estado = value; }
        public string U_pass { get => u_pass; set => u_pass = value; }
    }
}
