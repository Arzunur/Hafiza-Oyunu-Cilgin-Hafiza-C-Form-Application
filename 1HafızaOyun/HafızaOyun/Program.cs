using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HafızaOyun
{
    internal static class Program
    {
       
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Thread thread = new Thread(() =>
            {
                Application.Run(new Form1());
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new adminskor());
        }
    }
}
