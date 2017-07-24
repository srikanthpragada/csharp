using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class Intersect
    {
        public static void Main()
        {
            StreamReader sr = new StreamReader(@"f:\classroom\names.txt");
            var names = new HashSet<string>();
            // Copy all lines from first file into HashSet
            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                    break;
                names.Add(line);
            }

            // Copy lines present second file and also in first file 
            sr = new StreamReader(@"f:\classroom\names2.txt");
            var commonNames = new HashSet<string>();

            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                    break;
                if ( names.Contains(line))
                       commonNames.Add(line);
            }

            foreach (string name in commonNames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
