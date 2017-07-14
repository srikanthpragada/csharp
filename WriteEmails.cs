using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class EmailsWriter
    {
        public static bool IsValidEmail(string email)
        {
            if (email.Length <= 5)
                return false;

            if (email.Contains("@") && email.Contains("."))
                return true;
            else
                return false; 
        }


        public static void Main()
        {
            string sourcefilename = @"f:\classroom\emails.txt";
            string targetfilename = @"f:\classroom\validemails.txt";
            try
            {
                StreamReader sr = new StreamReader(sourcefilename);
                StreamWriter sw = new StreamWriter(targetfilename);
                while (true)
                {
                    string line = sr.ReadLine();
                    if (line == null)  // EOF
                        break;

                    if (line.Length == 0)
                        continue;

                    // process line
                    string[] emails = line.Split(',', ';');

                    foreach(string email in emails)
                    {
                        if (IsValidEmail(email))
                        {
                            Console.WriteLine(email);
                            sw.WriteLine(email);
                        }
                    }
                }
                sr.Close();
                sw.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sorry! File cannot be opened! Error : " + ex.Message);
            }
        }
    }
}
