using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CSharpViewer
    {
        public static void Main()
        {
            string dir = @"f:\classroom\aug22\consoleapp";

            DirectoryInfo dinfo = new DirectoryInfo(dir);

            foreach(FileInfo  finfo in  dinfo.GetFiles() )
            {
                if (finfo.FullName.EndsWith(".cs"))
                    PrintFile(finfo.FullName);
            }
        }

        public static void PrintFile(string filename)
        {
            Console.WriteLine("\n=================== {0} ==================\n", filename);
            using (StreamReader sr = new StreamReader(filename))
            {
                int lineno = 1;
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine("{0:000}: {1}",lineno++, line);
                }
            }

        }
    }
}
