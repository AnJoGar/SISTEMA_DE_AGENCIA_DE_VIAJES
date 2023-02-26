using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_Negocio;

namespace C_Presentacion.FormulariosProyecto.Reservas
{
    public partial class Reservas : Form

    {
        // Instanciamos un objeto de la clase CNReservas que se encuentra en la cpaa de negocios para hacer uso de sus funciones 
        CNReservas objetoreservas = new CNReservas();

    // creamos las siguientes variables que se utilizaran en los metodos que crearemos
        private string codigo = null;
        private bool editar = false;
        private string idReserva = null;
        public Reservas()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        // Creamos un metodo el cual nos permitirà guardar los datos del formulario que ingrese en usuario y que luego llamaremos en el boton guardar 
        private void GuardarReservas()
        {
            try
            {
                objetoreservas.insertarReserva(txtNombres.Text, txtApellidos.Text, txtCedula.Text, txtTelefono.Text, txtPasajeros.Text, cbmPago.Text, dtmFecha.Text, cbmDestino.Text);
                MessageBox.Show("Reserva exitosa,Gracias por preferirnos");
                MostrarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la reserva por: " + ex.Message);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           GuardarReservas();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            editarfilas();
        }

        // Creamos un metodo el cual nos permitirà editar llas filas que se encuentran registradas en la base de datos y este metodo luego lo llamaremos en el boton editar 
        private void editarfilas()
        {
            if (dtgMostrardatos.SelectedRows.Count > 0)
            {
                txtNombres.Text = dtgMostrardatos.CurrentRow.Cells["Nombre"].Value.ToString();
                txtApellidos.Text = dtgMostrardatos.CurrentRow.Cells["Apellido"].Value.ToString();
                txtCedula.Text = dtgMostrardatos.CurrentRow.Cells["Cedula"].Value.ToString();
                txtTelefono.Text = dtgMostrardatos.CurrentRow.Cells["Celular"].Value.ToString();
                txtPasajeros.Text = dtgMostrardatos.CurrentRow.Cells["Numeropasajeros"].Value.ToString();
                cbmPago.Text = dtgMostrardatos.CurrentRow.Cells["Tipopago"].Value.ToString();
                dtmFecha.Text = dtgMostrardatos.CurrentRow.Cells["Fechaviaje"].Value.ToString();
                cbmDestino.Text = dtgMostrardatos.CurrentRow.Cells["Destino"].Value.ToString();
                //codigo = dtgMostrardatos.CurrentRow.Cells["Codigo"].Value.ToString();

            }
            else
            {
                MessageBox.Show("seleccione una fila");
            }
        }

        // Metodo para mostrar los datos que se encuntran en la base de datos a travez de un datagridview
        private void MostrarReservas()

        {
            CNReservas objetoReserva = new CNReservas();
            dtgMostrardatos.DataSource = objetoReserva.MostrarReserva();
        }


        // Creamos un metodo el cual nos permitira actualizar los nuevos datos ingresados por el usuario y que luego llamaremos en el boton actualizar 
        private void ActualizarReservas()
        {
            try
            {
                string codigo = dtgMostrardatos.CurrentRow.Cells["Cedula"].Value.ToString();
                objetoreservas.editarReserva(txtNombres.Text, txtApellidos.Text, txtCedula.Text, txtTelefono.Text, txtPasajeros.Text, cbmPago.Text, dtmFecha.Text, cbmDestino.Text);
                MessageBox.Show("edición exitosa");
                MostrarReservas();
                editar = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo realizar la edición por:" + ex);
            }
        }

    

    // Creamos un metodo para eliminar las reservas que constan en la base de datos mediante su codigo, este metodo lo llameremos en el boton eliminar 
    private void EliminarReservas()
        {
            if (dtgMostrardatos.SelectedRows.Count > 0)
            {
                idReserva = dtgMostrardatos.CurrentRow.Cells["Codigo"].Value.ToString();
                objetoreservas.eliminarReserva(idReserva);
                MessageBox.Show("Reserva eliminada");
                MostrarReservas();

            }
            else
            {
                MessageBox.Show("Seleccione una reserva por favor");
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            EliminarReservas();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MostrarReservas();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarReservas();
        }
    }
}
