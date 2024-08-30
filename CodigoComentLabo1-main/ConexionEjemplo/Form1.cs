using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DatosLayer;
using System.Net;
using System.Reflection;


namespace ConexionEjemplo
{
    // Esta clase representa el formulario principal de la aplicación
    public partial class Form1 : Form
    {
        // Se crea una instancia del repositorio de clientes para manejar la base de datos
        CustomerRepository customerRepository = new CustomerRepository();

        // Constructor del formulario
        public Form1()
        {
            InitializeComponent();
        }

        // Este método se ejecuta cuando se presiona el botón "Cargar"
        private void btnCargar_Click(object sender, EventArgs e)
        {
            // Obtiene todos los clientes y los muestra en el dataGrid
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers;
        }

        // Este método se ejecuta cuando se cambia el texto en el textBox de filtro
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Aquí podrías filtrar los clientes según el texto ingresado (actualmente está comentado)
        }

        // Este método se ejecuta cuando se carga el formulario
        private void Form1_Load(object sender, EventArgs e)
        {
            // Configuración inicial (comentado por ahora)
        }

        // Este método se ejecuta cuando se presiona el botón "Buscar"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Busca un cliente por ID y muestra sus detalles en los textBoxes
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            tboxCustomerID.Text = cliente.CustomerID;
            tboxCompanyName.Text = cliente.CompanyName;
            tboxContacName.Text = cliente.ContactName;
            tboxContactTitle.Text = cliente.ContactTitle;
            tboxAddress.Text = cliente.Address;
            tboxCity.Text = cliente.City;
        }

        // Este método se ejecuta cuando se presiona el botón "Insertar"
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var resultado = 0;

            // Obtiene los datos del nuevo cliente desde los textBoxes
            var nuevoCliente = ObtenerNuevoCliente();

            // Verifica si hay campos nulos y, si no los hay, inserta el cliente en la base de datos
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Guardado" + "Filas modificadas = " + resultado);
            }
            else
            {
                MessageBox.Show("Debe completar los campos por favor");
            }
        }

        // Este método valida si hay algún campo vacío en el objeto cliente
        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if ((string)value == "")
                {
                    return true;
                }
            }
            return false;
        }

        // Este método se ejecuta cuando se presiona el botón "Modificar"
        private void btModificar_Click(object sender, EventArgs e)
        {
            // Obtiene los datos actualizados del cliente y los guarda en la base de datos
            var actualizarCliente = ObtenerNuevoCliente();
            int actualizadas = customerRepository.ActualizarCliente(actualizarCliente);
            MessageBox.Show($"Filas actualizadas = {actualizadas}");
        }

        // Este método crea un nuevo objeto cliente a partir de los datos ingresados en los textBoxes
        private Customers ObtenerNuevoCliente()
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContacName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };

            return nuevoCliente;
        }

        // Este método se ejecuta cuando se presiona el botón "Eliminar"
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Elimina el cliente con el ID especificado y muestra cuántas filas fueron afectadas
            int eliminadas = customerRepository.EliminarCliente(tboxCustomerID.Text);
            MessageBox.Show("Filas eliminadas = " + eliminadas);
        }
    }
}

