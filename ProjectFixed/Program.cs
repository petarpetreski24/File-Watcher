using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectFixed.Database;


namespace ProjectFixed
{
    public enum FileTypes { Video=1, Photo, OtherType };
    static class Program
    {
        //static public Configuration appConfiguration = new Configuration();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if(!SQLServices.IsDataInvalid && !SQLServices.CheckTables())
            {
                SQLServices.CreateTables();
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MonitoringDLG());
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print("Problem with starting application : " + ex.ToString());
            }
        }
    }
}
