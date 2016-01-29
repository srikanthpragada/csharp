[AttributeUsage (AttributeTargets.Class)]
    class AuthorAttribute : Attribute
    {
        public string Author  { get; set; }
        public int Version { get; set; } = 1;  // default version 
    }
