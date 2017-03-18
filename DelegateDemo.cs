using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class DelegateDemo
    {
        public static void Main()
        {
            int[] a = { 10, -11, 0, 33, -14 };
            int[] sa;
            sa = Array.FindAll(a, new Predicate<int>(Positive));  // 1

            sa = Array.FindAll(a, Positive); // 2

            // use anonymous method    // 3
            sa = Array.FindAll(a, 
                    delegate (int v)
                    {
                       return v < 0;
                    }
                 );

            sa = Array.FindAll(a, n => n > 0);  // 4  Lambda expression 

        }
        static bool Positive(int n)
        {
            return n > 0;
        }
    }
    }
}
