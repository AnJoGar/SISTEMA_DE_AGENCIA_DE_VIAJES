using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Excepciones
{
    public class OrigenNoEncontradoException : Exception
    {
        public OrigenNoEncontradoException()
        {


        }
        public OrigenNoEncontradoException(string message) : base(message)
        {
            EscribirErrores(message);
        }

        public OrigenNoEncontradoException(string message, Exception innerException)
        : base(message, innerException)
        {
            EscribirErrores(message);
        }

        public static void OrigenNoEncontrado(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                throw new OrigenNoEncontradoException("No se encontraron destinos turísticos con el origen especificado");
            }
        }


        private bool EscribirErrores(string error)
        {

            return true;
        }


    }
}
