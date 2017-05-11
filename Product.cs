 class Product
    {   // instance variables 
        private string name;
        private int price;
        private string[] features = new string[3];

        // class variable
        private static double taxper = 12.5; 

        // Static property 
        public static double TaxRate
        {
            get
            {
                return taxper;
            }
        }

        public Product(string name, int price)  // constructor 
        {
            this.name = name;
            this.price = price;
        }
        public Product(string name)  // constructor 
        {
            this.name = name;
        }

        // Method 
        public void Print()
        {
            Console.WriteLine(name);
            Console.WriteLine(price);
        }

        public string this[int index]
        {
            get
            {
                return features[index];
            }
            set
            {
                features[index] = value;
            }
        }

        public int Price   // Read-write Property 
        {
            get
            {
                return price;
            }
            set
            {
                if (value >= 0)
                    this.price = value;
            }
        }
        public double NetPrice  // Readonly Property
        {
            get
            {
                return price + price * taxper / 100;
            }

        }
    }
    class TestProduct
    {
        public static void Main()
        {
            Product p;

            p = new Product("iPhone 7 Plus", 70000); // create object
            p.Print();

            p[0] = "Features 1";
            p[1] = "Features 2";
            p[2] = "Features 3";

            Console.WriteLine(p[0]);

            Console.WriteLine(Product.TaxRate);

        }
    }
