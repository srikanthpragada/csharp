using System.IO;

namespace ConsoleApp
{
    class WriteMobileNumbers
    {

        public static bool IsValidMobileNumber(string number)
        {
            number = number.Trim(); 

            if (number.Length != 10)
                return false;

            for (int i = 0; i < number.Length; i++)
                if (!char.IsDigit(number[i]))
                    return false;

            return true;  // all 10 chars are digits 
        }
         public static void Main()
        {
            string source = @"f:\classroom\mobile_numbers.txt";
            string target = @"f:\classroom\aug21_mobile.txt";

            StreamReader sr = new StreamReader(source);
            StreamWriter sw = new StreamWriter(target);

            while(true)
            {
                string line = sr.ReadLine();
                if (line == null)  // EOF
                    break; 

                string[] numbers = line.Split(' ', ',', ':', ';');

                foreach(string number in numbers)
                {
                    if (IsValidMobileNumber(number))
                        sw.WriteLine(number);
                }
            }

            sw.Close();
        }
    }
}
