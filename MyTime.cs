using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class MyTime  : IComparable<MyTime>
    {
        public int Hours { get; set; }
        public int Mins { get; set; }
        public int Secs { get; set; }

        public int TotalSeconds   // Read-only property
        {
            get
            {
                return Hours * 3600 + Mins * 60 + Secs;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}:{2}", Hours, Mins, Secs);
        }

        public override bool Equals(object obj)
        {
            MyTime other = (MyTime) obj;
            return this.TotalSeconds == other.TotalSeconds;
        }
        public override int GetHashCode()
        {
            return Hours; 
        }
        // 0 , >0 , <0
        public int CompareTo(MyTime other)
        {
            return this.TotalSeconds - other.TotalSeconds;
        }

        public static bool operator==(MyTime t1, MyTime t2)
        {
            return t1.TotalSeconds == t2.TotalSeconds;
        }

        public static bool operator!=(MyTime t1, MyTime t2)
        {
            return t1.TotalSeconds != t2.TotalSeconds;
        }
        // Conversion operator to convert MyTime to int 
        public static implicit operator int(MyTime t)
        {
            return t.TotalSeconds;
        }
    }

    class TestMyTime
    {
        public static void Main()
        {
            MyTime t1 = new MyTime { Hours = 10, Mins = 20, Secs = 30 };
            MyTime t2 = new MyTime { Hours = 10, Mins = 20, Secs = 30 };
            
            int n =  t1;  // uses Conversion Operator 
            Console.WriteLine(t1 == t2);   // MyTime.operator==(t1,t2)
        }
    }
}
