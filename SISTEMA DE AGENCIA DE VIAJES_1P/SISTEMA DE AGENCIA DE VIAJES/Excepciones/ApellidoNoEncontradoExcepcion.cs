using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ApellidoNoEncontradoExcepcion : Exception
    {
        public ApellidoNoEncontradoExcepcion()
        {


        }
        public ApellidoNoEncontradoExcepcion(string message) : base(message)
        {
            EscribirErrores(message);
        }

        public ApellidoNoEncontradoExcepcion(string message, Exception innerException)
        : base(message, innerException)
        {
            EscribirErrores(message);
        }

        public static void ApellidoNoEncontrado(List<object> lstCliente)
        {
            if (lstCliente.Count == 0)
            {
                throw new ApellidoNoEncontradoExcepcion("No se encontraron Apellidos con el nombre especificado");
            }
        }


        private bool EscribirErrores(string error)
        {

            return true;
        }
    }
}
