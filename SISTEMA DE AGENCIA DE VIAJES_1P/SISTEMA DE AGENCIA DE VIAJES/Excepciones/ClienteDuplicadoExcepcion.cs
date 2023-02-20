using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ClienteDuplicadoExcepcion : Exception
    {
        public ClienteDuplicadoExcepcion()
        {


        }
        public ClienteDuplicadoExcepcion(string message) : base(message)
        {
            EscribirErrores(message);
        }

        public ClienteDuplicadoExcepcion(string message, Exception innerException) : base(message, innerException)
        {
            EscribirErrores(message);
        }

        public static void ClienteDuplicado(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                throw new OrigenNoEncontradoException("Cliente existente ");
            }
        }


        private bool EscribirErrores(string error)
        {

            return true;
        }
    }
}
