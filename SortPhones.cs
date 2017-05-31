using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class SortPhones
    {
        public static void Main()
        {
            StreamReader sr = new StreamReader(@"f:\classroom\may5dotnet\phones.txt");
            
            SortedDictionary<string, string> phones = new SortedDictionary<string, string>();

            while (true)
            {
                string line = sr.ReadLine();
                if (line == null)
                    break;
                    
                // Ignore empty lines
                if (line.Trim().Length == 0)
                    continue; 

                string[] parts = line.Split(',');

                // Ignore lines that don't have two parts 

                if (parts.Length < 2)
                    continue;

                string name = parts[0];
                string phone = parts[1];

                if (!phones.ContainsKey(name))  // Name not found
                    phones.Add(name, phone);
                else  // Name is already present, add new phone number to existing one
                    phones[name] = phones[name] + "," + phone;

            }

            foreach (string name in phones.Keys)
                Console.WriteLine("{0} - {1}", name.PadRight(15), phones[name]);
        }
    }
}


Phones.txt
===========
Steve,334943333
Scott,393922222
Bill,334343433
Joe,393939333
Bob,339393333
Bob,393939333
Bill,393939333
Jack,393911919
Bill,399191111
Bill
