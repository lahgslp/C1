using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Cotizaciones.Common;

namespace Cotizaciones
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            string connectionStringName = ConfigurationHelper.GetConfigurationValue("DefaultDBConnectionName");
            if (args.Count() == 0)
            {
            }
            ConfigurationHelper.ConnectionString = connectionStringName;
            try
            {
                if (Cotizaciones.Utilities.CheckConnection(connectionStringName) == false)
                {
                    MessageBox.Show("No se puede establecer una conexión con la base de datos. Por favor verifique que el servidor este encendido y que este conectado a la red apropiadamente.", "Base de datos no accesible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new ShellMainForm());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("La aplicación ha encontrado un error y será cerrada.", "Error crítico");
                Logger.LogException(e);
                Application.Exit();
            }
        }
    }
}
