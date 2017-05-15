using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class CSharpSourceViewer
    {

        public static void Main()
        {
            string folder = @"f:\classroom\may5dotnet\csharpdemo";

            // Console.Write("Enter folder : ");
            // folder = Console.ReadLine();

            DirectoryInfo dir = new DirectoryInfo(folder);

            FileInfo[] files = dir.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.FullName.EndsWith(".cs"))
                    PrintFile(file.FullName);
            }


        }

        public static void PrintFile(string filename)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                Console.WriteLine(" **** Filename : {0} ******", filename);

                int lineno = 1;
                while (true)
                {
                    string name = sr.ReadLine();
                    if (name == null)
                        break;

                    Console.WriteLine("{0:000}:{1}", lineno, name);
                    lineno++;
                }
            }
        }
    }
}
