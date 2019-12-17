using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.IO;


namespace DemoMVC.Helpers
{
    public class Logger
    {
        private static Logger logger = new Logger();
        private string filePath;
        FileStream fs = null;
        StreamWriter writer = null;

        private Logger()
        {
            filePath = ConfigurationManager.AppSettings["logfile"].ToString();
        }
        public static Logger CurrentLogger { get { return logger; } }
        public void Log(string msg)
        {
            if (File.Exists(filePath))
            {
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write);
            }
            else
            {
                fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            }

            writer = new StreamWriter(fs);
            string msgToBeLogged = "Logged: {0} at {1}";
            writer.WriteLine(msgToBeLogged, msg, DateTime.Now.ToString());
            writer.Close();
            fs = null;

        }
    }
}