using System;
using System.IO;

namespace csharpdemo
{
    class DisplaySourceCode
    {
        public static void Main()
        {
            //Console.Write("Enter folder : ");
            //string folder = Console.ReadLine();

            string folder = @"f:\classroom\feb20\csharpdemo";

            string [] filesnames = Directory.GetFiles(folder);

            foreach (string filename in filesnames)
            {
                if (!filename.EndsWith(".cs"))
                    continue; 

                Console.WriteLine("\n ***** {0} *****\n", filename);
                int lineno = 1;
                StreamReader sr = new StreamReader(filename);
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)
                        break;
                    Console.WriteLine("{0:000} : {1}", lineno, line);
                    lineno++;
                }
                sr.Close();
            }
        }
    }
}
