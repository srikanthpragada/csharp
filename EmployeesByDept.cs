deptemp.txt  (Source file)
===========================
HR,Joe
EDP,Steve
HR,Smith
SALES,Jason
SALES,Jack
HR,Kim
EDP,Bill
EDP,Micheal
EDP,Jeff 





//  Program to display employees by dept
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp
{
    class EmployeesByDept
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(@"e:\classroom\deptemp.txt");
            var depts = new SortedDictionary<string, SortedSet<string>>();

            while(true)
            {
                string line = sr.ReadLine();
                if (line == null) // EOF
                    break;

                if (line.Trim().Length == 0)
                    continue;  // blank line, so ignore 

                string[] parts = line.Split(',');
                var deptname = parts[0];
                var empname = parts[1];

                if (depts.ContainsKey(deptname)) // dept is already present 
                {
                    depts[deptname].Add(empname);  // Add employee to existing list 
                }
                else
                {
                    var names = new SortedSet<string>();
                    names.Add(empname);
                    depts.Add(deptname, names);  // add new entry to depts
                }
            }

            sr.Close();

            foreach (string deptname in depts.Keys)
            {
                Console.Write(deptname + " -> " );
                foreach (string name in depts[deptname])
                    Console.Write(name + " ");

                Console.WriteLine(); // come to next line 
            }
        }
    }
}

Output
============
EDP -> Bill Jeff  Micheal Steve
HR -> Joe Kim Smith
SALES -> Jack Jason
