using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student
    {
        private int admno;
        private string name;
        private int course, marks;

        private static int passmark = 50;

        public static int PassMark
        {
            get
            {
                return passmark;
            }
            set
            {
                passmark = value;
            }
        }

        public static bool GetResult(int marks)
        {
            return marks >= passmark;
        }

        public static string GetCourseName(int course)
        {
            switch (course)
            {
                case 1: return "MS.NET";
                case 2: return "Java";
                case 3: return "Python";
                case 4: return "Angular";
                default: return "";
            }
        }

        public Student(int admno, string name, int course, int marks)
        {
            this.admno = admno;
            this.name = name;
            this.course = course;
            this.marks = marks;
        }
        public string CourseName
        {
            get
            {
                return GetCourseName(this.course);
            }
        }
        public int Marks
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }

        public bool IsPassed
        {
            get
            {
                return this.marks >= passmark;
            }
        }

        public void Print()
        {
            Console.WriteLine(this.admno);
            Console.WriteLine(this.name);
            Console.WriteLine(this.CourseName);
            Console.WriteLine(this.marks);
            Console.WriteLine(this.IsPassed);
        }

    }

    class TestStudent
    {
        static void Main(string[] args)
        {
            Student s = new Student(1, "Mr. James", 3, 70);
            s.Print();
            Console.WriteLine(Student.PassMark);
            Student.PassMark = 40;
            Console.WriteLine(Student.GetResult(40));
        }
    }
}
