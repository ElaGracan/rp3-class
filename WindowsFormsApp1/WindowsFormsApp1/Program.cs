using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Form form1 = new Form();
            Form form2 = new Form();
            Form form3 = new Form();

            form1.Text = "1.forma - Run";
          form2.Text = "2.forma - Show";
          form2.Show();
            form3.Text ="3.forma - ShowDialog";
          form3.ShowDialog();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(form1);
        }
    }
}
