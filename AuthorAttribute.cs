[AttributeUsage (AttributeTargets.Class)]
    class AuthorAttribute : Attribute
    {
        public string Author  { get; set; }
        public int    Version { get; set; }
    }
