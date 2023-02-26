using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Capa_Datos;


namespace Capa_Negocio
{
    public class CNReservas
    {

        // Instanciamos un objeto de la clase ClaseReservas que se encuentra en la capa de datos para hacer uso de sus funciones


        private ClaseReservas CD_reserva = new ClaseReservas ();

        // Creamos un metodo de tipo Datatable para mostrar los datos obtenidos de la base de datos 
        public DataTable MostrarReserva()
        {
            DataTable tabla = new DataTable();
            tabla = CD_reserva.Mostrar();
            return tabla;

        }

        // Creamos un metodo para insertar reservas con los parametros establecidos en la capa de datos y estos tomaran los datos del formulario 

        public void insertarReserva(string nombres, string apellidos, string cedula, string celular, string N_pasajeros, string pago, string fecha, string destino)
        {
            CD_reserva.insertar(nombres, apellidos, cedula, celular, Convert.ToInt32(N_pasajeros), pago, Convert.ToDateTime(fecha), destino);
        }

        // Creamos un metodo para editar resrvas con los parametros establecidos en la capa de datos y estos tomaran los datos del formulario 
        public void editarReserva( string nombres, string apellidos, string cedula, string celular, string N_pasajeros, string pago, string fecha, string destino)
        {
            CD_reserva.editar( nombres, apellidos, cedula, celular, Convert.ToInt32(N_pasajeros), pago, Convert.ToDateTime(fecha), destino);
        }

        // Creamos un metodo para eliminar reservas mediante el codigo 
        public void eliminarReserva(string codigo)
        {
            CD_reserva.eliminar(Convert.ToInt32(codigo));
        }
    }

}
