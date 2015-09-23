using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Stock.Interface;
using Stock.Interface.Master;

namespace Stock
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login  ());
        }
    }
}
