using System;

class Product
{
    public int Id;
    public string Name;
    public double Price;
    public int RemainingStock;

    public void DisplayProduct()
    {
        Console.WriteLine($"{Id}. {Name} - ₱{Price} (Stock: {RemainingStock})");
    }

    public bool HasEnoughStock(int quantity)
    {
        return quantity <= RemainingStock;
    }

    public double GetItemTotal(int quantity)
    {
        return Price * quantity;
    }

    public void DeductStock(int quantity)
    {
        RemainingStock -= quantity;
    }
}

class Program
{
    static void Main()
    {
        Product[] products = new Product[]
        {
            new Product { Id = 1, Name = "Table", Price = 2500, RemainingStock = 60 },
            new Product { Id = 2, Name = "Chair", Price = 500, RemainingStock = 350 },
            new Product { Id = 3, Name = "Table Cloth", Price = 200, RemainingStock = 400 }
        };

        char choice;

        do
        {
            Console.WriteLine("\n=== STORE MENU ===");
            foreach (Product p in products)
            {
                p.DisplayProduct();
            }

            int productChoice;
            int quantity;

            while (true)
            {
                Console.Write("\nEnter product number: ");

                if (!int.TryParse(Console.ReadLine(), out productChoice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                if (productChoice < 1 || productChoice > products.Length)
                {
                    Console.WriteLine("Invalid product.");
                    continue;
                }

                Console.Write("Enter quantity: ");

                if (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    continue;
                }

                if (!products[productChoice - 1].HasEnoughStock(quantity))
                {
                    Console.WriteLine("Not enough stock.");
                    continue;
                }

                break;
            }

            Product selected = products[productChoice - 1];

            double total = selected.GetItemTotal(quantity);

            Console.WriteLine($"\nAdded: {selected.Name} x{quantity}");
            Console.WriteLine($"Subtotal: ₱{total}");

            selected.DeductStock(quantity);

            Console.Write("\nBuy again? (Y/N): ");
            choice = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

        } while (choice == 'Y');
    }
}
