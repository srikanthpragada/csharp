using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class Employee
    {   // instance variables
        private int empno;
        private string empname;
        private int salary;
        private string[] skills = new string[5];

        // Constructor 
        public Employee(int empno, string empname, int salary)
        {
            this.empno = empno;
            this.empname = empname;
            this.salary = salary;
        }
        public int Number
        {
            get
            {
                return empno;
            }
            private set
            {
                this.empno = value; 
            }
        }
        // Methods 
        public void Print()
        {
            Console.WriteLine(this.empno);   // WriteLine(int)
            Console.WriteLine(this.empname); // WriteLine(string)
            Console.WriteLine(this.salary);
            foreach(string s in skills)
            {
                if (s != null && s.Length > 0)
                    Console.WriteLine(s);
            }

        }
        public void SetSalary(int salary)
        {
            if (salary > 0)
                this.salary = salary;
        }
        public int NetSalary  // Readonly property 
        {
            get
            {
                return salary + (salary * 30 / 100);
            }
        }
        // Indexer
        public string this[int index]
        {
            get
            {
                return skills[0];
            }
            set
            {
                skills[index] = value;
            }
        }
    }

    class TestEmployee
    {
        public static void Main()
        {
            Employee e;   // object reference
            e = new Employee(1,"Bill",90000);
            e[0] = "Oracle";
            e[1] = "Java Language";
            e[3] = "Angular";

            e.Print();
        }
    }
}
