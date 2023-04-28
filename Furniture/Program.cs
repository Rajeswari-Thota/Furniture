namespace Furniture
{
 class Furniture
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual void Accept()
        {
            Console.Write("Enter height: ");
            Height = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter width: ");
            Width = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter color: ");
            Color = Console.ReadLine();

            Console.Write("Enter quantity: ");
            Quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter price: ");
            Price = Convert.ToDouble(Console.ReadLine());
        }

        public virtual void Display()
        {
            Console.WriteLine($"Height: {Height}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Quantity: {Quantity}");
            Console.WriteLine($"Price: {Price}");
        }
    }

    class BookShelf : Furniture
    {
        public int NoOfShelves { get; set; }

        public override void Accept()
        {
            base.Accept();

            Console.Write("Enter number of shelves: ");
            NoOfShelves = Convert.ToInt32(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Number of shelves: {NoOfShelves}");
        }
    }

    class DiningTable : Furniture
    {
        public int NoOfLegs { get; set; }

        public override void Accept()
        {
            base.Accept();

            Console.Write("Enter number of legs: ");
            NoOfLegs = Convert.ToInt32(Console.ReadLine());
        }

        public override void Display()
        {
            base.Display();

            Console.WriteLine($"Number of legs: {NoOfLegs}");
        }
    }

    class FurnitureShop
    {
        public int AddToStock(Furniture[] furnitures)
        {
            int count = 0;

            for (int i = 0; i < furnitures.Length; i++)
            {
                Console.WriteLine("Select furniture type: ");
                Console.WriteLine("1. BookShelf");
                Console.WriteLine("2. DiningTable");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        furnitures[i] = new BookShelf();
                        break;
                    case 2:
                        furnitures[i] = new DiningTable();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        i--;
                        continue;
                }

                furnitures[i].Accept();
                count++;
            }

            return count;
        }
        public double TotalStockValue(Furniture[] furnitures)
        {
            double totalValue = 0;

            foreach (Furniture furniture in furnitures)
            {
                totalValue += furniture.Quantity * furniture.Price;
            }

            return totalValue;
        }
        public void ShowStockDetails(Furniture[] furnitures)
        {
            Console.WriteLine("................Furniture details .............. ");
            Console.WriteLine();
            foreach (Furniture furniture in furnitures)
            {
                furniture.Display();
                Console.WriteLine();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            FurnitureShop shop = new FurnitureShop();

            Furniture[] furnitures = new Furniture[5];

            int count = shop.AddToStock(furnitures);

            Console.WriteLine($"Total furniture items added to stock: {count}");

            Console.WriteLine();
            shop.ShowStockDetails(furnitures);

            double totalValue = shop.TotalStockValue(furnitures);
            Console.WriteLine($"Total stock value: {totalValue}");
        }
    }
}