using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    abstract class Doctor
    {
        protected string name, mobile;
        public Doctor(string name, string mobile)
        {
            this.name = name;
            this.mobile = mobile;
        }
        public virtual void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine(mobile);
        }
        public abstract int GetSalary();
    }

    class RDoctor : Doctor 
    {
        protected int salary;
        public RDoctor(string name, string mobile, int salary) : base(name,mobile)
        {
            this.salary = salary; 
        }
        public override void Print()
        {
            base.Print(); 
            Console.WriteLine(salary);
        }

        public override int GetSalary()
        {
            return salary;
        }
    }

    class Consultant : Doctor
    {
        protected int visits,charge;
        public Consultant(string name, string mobile, int visits, int charge)
              : base(name, mobile)
        {
            this.visits = visits;
            this.charge = charge;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(visits);
            Console.WriteLine(charge);
        }

        public override  int GetSalary()
        {
            return visits * charge;
        }
    }


    class TestDoctor
    {
        public static void Main()
        {
            Consultant c = new Consultant("Dr. Bean", "343334433", 10, 500);
            RDoctor r = new RDoctor("Dr. James", "39393999", 200000);
            Print(c);
            Print(r);
        }

        public static void Print(Doctor d)
        {
            // Runtime polymorphism 
            d.Print();  // Print() of Object pointed by d 

            int sal = d.GetSalary();  // Runtime Polymorphism 
            if (sal > 20000)
                Console.WriteLine("Pay {0} by cheque!", sal);
            else
                Console.WriteLine("Pay {0} by cash!", sal);

        }
    }
}
