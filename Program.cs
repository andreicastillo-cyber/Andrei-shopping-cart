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

    Console.WriteLine("=== STORE MENU ===");
    foreach (Product p in products)
    {
        p.DisplayProduct();
    }
}
}
