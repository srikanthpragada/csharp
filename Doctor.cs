using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csdemo
{
   abstract class Doctor
    {
        protected String name, dept;
        public Doctor(String name, String dept)
        {
            this.name = name;
            this.dept = dept;
        }
        public virtual void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine(dept);
        }
        public abstract int GetPayment();
    }

    class RDoctor : Doctor
    {
        protected int salary;
        public RDoctor(String name, String dept, int salary) : base(name,dept)
        {
            this.salary = salary;
        }
        public override void Print()
        {
            base.Print();
            Console.WriteLine(salary);
        }
        public override int GetPayment()
        {
            return salary;
        }
    }

    class Consultant : Doctor
    {
        protected int visits, charge;
        public Consultant(String name, String dept, int visits, int charge) : base(name, dept)
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
        public override int GetPayment()
        {
            return visits  * charge;
        }
    }

    class TestDoctor
    {
        public static void Main()
        {
            Doctor d;

            d = new Consultant("Dr. Jeans", "Ped", 10, 500);
            d.Print();  // Print of Consultant  - Runtime Polymorphism
            Console.WriteLine("Payment  : {0}", d.GetPayment());

            d = new RDoctor("Dr. Andy", "Card", 300000);
            d.Print();  // Print of RDoctor - Runtime Polymorphism
            Console.WriteLine("Payment  : {0}", d.GetPayment());
        }
    }
}
