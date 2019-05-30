using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogHelperLib
{
    public class LogHelper
    {
        public static void LogWrite(string message)
        {
            Logger.Write(message);
            Console.WriteLine(message);
        }
    }
}
