using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataSourceDemo
{
    // Clase estática Program que sirve como punto de entrada de la aplicación.
    internal static class Program
    {
        /// <summary>
        /// Método principal donde comienza la ejecución de la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Activa los estilos visuales para los controles de Windows Forms.
            Application.EnableVisualStyles();
            // Configura la aplicación para usar la renderización de texto compatible por defecto.
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia la ejecución de la aplicación con el formulario principal 'Form2'.
            Application.Run(new Form2());
        }
    }
}