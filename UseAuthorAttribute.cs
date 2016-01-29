 [Author ( Author = "Srikanth", Version = 1)]
 class Contact : IComparable<Contact>
 {
    // members
 }

[Author(Author = "Praneeth", Version = 2)]
class  ListContacts
{
   // members
}


class ListClasses
    {
        public static void Main()
        {

            Assembly asm = Assembly.GetExecutingAssembly();

            string author;
            int version;

            foreach ( Type t in asm.GetTypes() )
            {
                AuthorAttribute aa = t.GetCustomAttribute(typeof(AuthorAttribute))
                                     as AuthorAttribute;

                author = "Unknown";
                version = 1;
                if (aa != null)
                {
                    author = aa.Author;
                    version = aa.Version;
                }

                Console.WriteLine("{0}   {1}   {2}", t.Name.PadRight(30), author.PadRight(30),version);
            }


        }
    }
    
    
