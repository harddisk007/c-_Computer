using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectOnePerson
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
            Application.Run(new Form1());
        }
        public static string username;
        public static string test;
        public static string id;
        public static string brand;
        public static string code;
        public static string types;
        public static string model;
        public static string price;
        public static string amount;
        public static string date_time;

    }

}
