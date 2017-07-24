using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class ListMobileNumbers
    {
        public static void Main()
        {
            StreamReader sr = new StreamReader(@"f:\classroom\mobilenumbers.txt");
            var directory = new SortedDictionary<string, string>();
            
            while(true)
            {
                string line = sr.ReadLine();
                if (line == null)
                    break;

                string[] parts = line.Split(':');  // name:number

                if (parts.Length < 2 || parts[1].Length == 0 || parts[0].Length == 0)
                    continue;

                if (!directory.ContainsKey(parts[1]))
                       directory.Add(parts[1], parts[0]);
            }

            sr.Close();

            foreach(string number in  directory.Keys)
            {
                Console.WriteLine("{0} - {1}", number.PadRight(12,' '), directory[number]);
            }
        }
    }
}
