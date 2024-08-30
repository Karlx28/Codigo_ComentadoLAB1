using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    public partial class Form1 : Form
    {
        // Constructor de la clase Form1
        public Form1()
        {
            InitializeComponent();
        }

        // Evento que se dispara al hacer clic en el botón de guardar del BindingNavigator.
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            // Valida los controles, finaliza la edición en el BindingSource y actualiza los datos en el DataSet
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Evento duplicado: hace lo mismo que el anterior (posiblemente accidental, puede eliminarse)
        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Otro evento duplicado: también hace lo mismo que los anteriores (puede eliminarse)
        private void customersBindingNavigatorSaveItem_Click_2(object sender, EventArgs e)
        {
            this.Validate();
            this.customersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.northwindDataSet);
        }

        // Evento que se dispara cuando el formulario Form1 se carga
        private void Form1_Load(object sender, EventArgs e)
        {
            // Carga los datos de la tabla 'Customers' del DataSet cuando se carga el formulario
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        // Evento que se dispara al hacer clic en una celda del DataGridView 'customersDataGridView'
        private void customersDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Actualmente no hace nada; podrías agregar funcionalidad si lo necesitas
        }
    }
}
