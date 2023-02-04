using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Excepciones
{
    public class AerolineaNoEncontradaException : Exception
    {
        public AerolineaNoEncontradaException()
        {


        }
        public AerolineaNoEncontradaException(string message) : base(message)
        {
            EscribirErrores(message);
        }

        public AerolineaNoEncontradaException(string message, Exception innerException)
        : base(message, innerException)
        {
            EscribirErrores(message);
        }

        public static void AerolineaNoEncontrada(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                throw new OrigenNoEncontradoException("No se encontraron Aerolineas con el nombre especificado");
            }
        }


        private bool EscribirErrores(string error)
        {

            return true;
        }


    }
}
