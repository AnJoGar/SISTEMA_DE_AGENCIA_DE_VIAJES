using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class ClaseReservas
    {
        // Instanciamos un objeto de la clase Conexion_Desconexion_bd para abrir y cerrar la conexion a la base e datos
        
        private Conexion_Desconexion_bd conexion = new Conexion_Desconexion_bd();

        // creamos las siguientes variables de tipo sqlDatareader,Datatable y SqlCommand para guardar las operaciones que realizaremos y poder encapsularlas

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        // Creamos un mètodo el cual nos permitirà mostrar los datos obtenidos de la base de datos mediante un datable
        public DataTable Mostrar()
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "select * from  Reservas";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrar_conexion();
            return tabla;
        }

        // Creamos un mètodo el cual nos permitirà insertar los datos que el usuario ingresarà en cada una de las cajas de texto del formulario que se encuentra en la capa de presentaciòn 

        public void insertar(string nombres, string apellidos, string cedula, string telefono, int N_pasajeros, string pago, DateTime fecha, string destino)
        {
            SqlCommand comando = new SqlCommand();
            Conexion_Desconexion_bd conexion = new Conexion_Desconexion_bd();
            string msj = "";

            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "insert into Reservas (Nombre, Apellido, Cedula, Celular, Numeropasajeros, Fechaviaje, Tipopago, Destino) values('" + nombres + "','" + apellidos + "','" + cedula + "','" + telefono + "','" + N_pasajeros + "','" + fecha.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + pago + "','" + destino + "')";
            comando.ExecuteNonQuery();
            conexion.cerrar_conexion();
        }
        // Creamos un mètodo el cual nos permitirà editar  los datos ingresados por cada reserva solicitada y que se encuentran registrados en la base de datos 
        public void editar( string nombres, string apellidos, string cedula, string telefono, int N_pasajeros, string pago, DateTime fecha, string destino)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "update Reservas set Nombre='" + nombres + "',Apellido='" + apellidos + "',Cedula='" + cedula + "',Celular='" + telefono + "',Numeropasajeros='" + N_pasajeros + "',Tipopago='" + pago + "',Fechaviaje='" + fecha.ToString("yyyy-MM-dd") + "',Destino='" + destino + "' where Cedula='" + cedula + "'";
            comando.ExecuteNonQuery();
            conexion.cerrar_conexion();
        }



        // Creamos un mètodo el cual nos permitirà eliminar todos los datos ingresados por cada reserva, que se encuentran registradas en la base de datos 
        public void eliminar(int codigo)
        {
            comando.Connection = conexion.abrir_conexion();
            comando.CommandText = "delete Reservas where Codigo=" + codigo;
            comando.ExecuteNonQuery();
            conexion.cerrar_conexion();
        }
    }
}
