using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharpdemo
{
    class Contact : IComparable<Contact>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }

        public int CompareTo(Contact other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }

    class  ListContacts
    {
        public static void Main()
        {

            StreamReader sr = new StreamReader(@"f:\classroom\contacts.txt");
            var  contacts = new SortedSet<Contact>(); 
            String line = sr.ReadLine();

            while ( line!= null)
            {
                string[] parts = line.Split('-');
                contacts.Add(new Contact
                        { Name = parts[0].Trim(),
                          Email = parts[1].Trim(),
                          Mobile = parts[2].Trim()
                        });
                line = sr.ReadLine();
            }
            sr.Close();

            foreach(Contact c in contacts)
            {
                Console.WriteLine("{0} {1} {2}", c.Name.PadRight(30), c.Email.PadRight(30), c.Mobile.PadRight(10));
            }

        }
    }
}
