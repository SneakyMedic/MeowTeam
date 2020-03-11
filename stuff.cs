using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace MeowTeam
{
    public class stuff
    {
        public static string readFromFile(string file)
        {
            string ret = IO.ReadLine(file + ".txt", 1, Program.noteDir);
            if (!(ret == null)) { return ret; }
            else { IO.Write("",file+".txt",Program.noteDir,false,true); return ""; }
        }
        public static void writeToFile(string val, string id)
        {
            IO.Write(val,id+".txt", Program.noteDir,false,true);
        }
    }
}
