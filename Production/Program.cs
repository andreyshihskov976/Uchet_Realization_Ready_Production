using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Login login = new Login();
            Application.Run(login);
            if (login.DialogResult == DialogResult.No)
            {
                Application.Run(new Postavschik());
            }
            if (login.DialogResult == DialogResult.Yes)
            {
                Application.Run(new Zakazchik(login.ID));
            }
        }
    }
}
