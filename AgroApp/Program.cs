using AgroApp.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgroApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormBase());
        }
    }
}
/*
 * do zrobienia:
 * -form do pokazywania i edytowania maszyn
 * -form do pokazywania i edytowania narzędzi
 * -edytowanie pracowników
 * -edytowanie gospodarstw
 * -edytowanie pól
 * -wykresy
 */
