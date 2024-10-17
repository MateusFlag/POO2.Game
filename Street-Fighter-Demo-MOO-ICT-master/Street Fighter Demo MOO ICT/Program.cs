using System;
using System.Windows.Forms;

namespace Street_Fighter_Demo_MOO_ICT
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainMenu()); // Inicializando com o menu principal
        }
    }
}
