using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeananTools
{
    internal class DebugClass
    {
        public static string Text="";
        public static  void Log(string str)
        {
            Text += str;        
        }

        public static void Logln(string str)
        {
            Text += str+"\r\n";
        }

    }
}
