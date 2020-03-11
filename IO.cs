using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
namespace MeowTeam
{
    public class IO
    {
        public static string nullstr = null;
        public static void DirectoryCreate(string directory)
        {
            Directory.CreateDirectory(directory);
        }
        public static void DirectoryDelete(string directory)
        {
            Directory.Delete(directory);
        }
        private static string dircheck(string directory)
        {
            if(!(directory==""))
            {
                return "/";
            }
            else
            {
                return "";
            }
        }
        private static string dirfile(string directory,string file)
        {
            return directory + dircheck(directory) + file;
        }
        private static string directoryCorrectCheck(string directory)
        {
            try
            {
                if (directory.ToCharArray()[directory.ToCharArray().Length - 1] == '/')
                {
                    directory = (directory.ToCharArray()[directory.ToCharArray().Length - 1] = '|').ToString();
                    directory.Replace("|", "");
                }
            }
            catch(Exception)
            {
                directory = "";
            }
            return directory;
        }
        public static string ReadLine(string file, int line, string directory)
        {
            directoryCorrectCheck(directory);
            string ret = null;
            try
            {
                ret = File.ReadAllLines(dirfile(directory,file)).Skip(line-1).Take(1).First();
            }
            catch(Exception)
            {
                //Console.WriteLine("\nError while reading "+file+" at "+line+"line"+"\n");
            }
            return ret;
        }
        public static void Write(string str, string file, string directory, bool append, bool writeline)
        {
            if(str==null&&file==null&&directory==null&&append==false&&writeline==false)
            {
                File.Delete(dirfile(directory, file));
                var v = File.Create(dirfile(directory, file));
                v.Close();
            }
            else
            {
                directoryCorrectCheck(directory);
                using (StreamWriter sw = new StreamWriter(dirfile(directory, file), append))
                {
                    if (writeline)
                    {
                        sw.WriteLine(str);
                    }
                    else
                    {
                        sw.Write(str);
                    }
                }
            }        
        }
        public static void ClearFile(string file, string directory)
        {
            File.Delete(dirfile(directory, file));
            var v = File.Create(dirfile(directory, file));
            v.Close();
        }
        public static void Delete(string file, string directory)
        {
            File.Delete(dirfile(directory, file));
        }
        public static void Create(string file, string directory)
        {
            var v = File.Create(dirfile(directory, file));
            v.Close();
        }
    }
}
