using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public  class RegistroDuplicadoException : Exception
    {
        public RegistroDuplicadoException()
        {


        }
        public RegistroDuplicadoException(string message) : base(message)
        {
            EscribirErrores(message);
        }

        public RegistroDuplicadoException(string message, Exception innerException): base(message, innerException)
        {
            EscribirErrores(message);
        }

        public static void RegistroDuplicado(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                throw new OrigenNoEncontradoException("Registro existente ");
            }
        }


        private bool EscribirErrores(string error)
        {

            return true;
        }

    }
}
