using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexionEjemplo
{
    // Define una clase estática llamada Program
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        // Este método es el punto de inicio de la aplicación
        static void Main()
        {
            // Habilita estilos visuales para los controles de Windows Forms
            Application.EnableVisualStyles();
            // Configura la aplicación para que use la compatibilidad predeterminada con el renderizado de texto
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia la ejecución de la aplicación con el formulario principal (Form1)
            Application.Run(new Form1());
        }
    }
}
