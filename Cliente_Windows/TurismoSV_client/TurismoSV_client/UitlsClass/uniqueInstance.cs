using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoSV_client.UitlsClass
{
    internal class uniqueInstance
    {
        private static uniqueInstance instancia;

        public static uniqueInstance Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new uniqueInstance();
                }

                return instancia;
            }
        }

        private uniqueInstance()
        {
            // constructor privado para evitar la creación directa de objetos de uniqueInstance
        }

        // Otros métodos y propiedades de uniqueInstance aquí
    }//end class
}//end namespaces
