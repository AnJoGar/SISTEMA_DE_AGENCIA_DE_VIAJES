using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ClienteNoEncontradoExcepcion : Exception
    {
        public ClienteNoEncontradoExcepcion()
        {


        }
        public ClienteNoEncontradoExcepcion(string message) : base(message)
        {
            EscribirErrores(message);
        }

        public ClienteNoEncontradoExcepcion(string message, Exception innerException)
        : base(message, innerException)
        {
            EscribirErrores(message);
        }

        public static void ClienteNoEncontrado(List<object> lstClientes)
        {
            if (lstClientes.Count == 0)
            {
                throw new ClienteNoEncontradoExcepcion("No se encontraron clientes con el apellido especificado");
            }
        }


        private bool EscribirErrores(string error)
        {

            return true;
        }
    }
}
