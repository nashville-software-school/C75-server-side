using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public bool Sold { get; set; }
    public string Material { get; set; }
    public DateTime StockDate { get; set; }
    public int ManufactureYear { get; set; }
    public double Condition { get; set; }

    public int AgeInYears => DateTime.Now.Year - ManufactureYear;
    public int DaysInStock => (DateTime.Now - StockDate).Days;
}

class Program
{
    static List<Product> inventory = new List<Product>
    {
        new Product 
        { 
            Name = "Wilson Football", 
            Price = 45.99M, 
            Sold = false, 
            Material = "Leather", 
            StockDate = DateTime.Now.AddDays(-30), 
            ManufactureYear = 2023, 
            Condition = 8.5 
        },
        new Product 
        { 
            Name = "Louisville Slugger Baseball Bat", 
            Price = 89.99M, 
            Sold = false, 
            Material = "Maple Wood", 
            StockDate = DateTime.Now.AddDays(-120), 
            ManufactureYear = 2022, 
            Condition = 7.8 
        },
        new Product 
        { 
            Name = "Spalding Basketball", 
            Price = 29.99M, 
            Sold = false, 
            Material = "Composite Leather", 
            StockDate = DateTime.Now.AddDays(-15), 
            ManufactureYear = 2024, 
            Condition = 9.2 
        },
        new Product 
        { 
            Name = "Nike Soccer Ball", 
            Price = 34.99M, 
            Sold = false, 
            Material = "Synthetic Leather", 
            StockDate = DateTime.Now.AddDays(-60), 
            ManufactureYear = 2023, 
            Condition = 8.0 
        },
        new Product 
        { 
            Name = "Tennis Racket Pro", 
            Price = 119.99M, 
            Sold = false, 
            Material = "Graphite", 
            StockDate = DateTime.Now.AddDays(-45), 
            ManufactureYear = 2022, 
            Condition = 7.5 
        },
        new Product 
        { 
            Name = "Golf Driver", 
            Price = 199.99M, 
            Sold = false, 
            Material = "Titanium", 
            StockDate = DateTime.Now.AddDays(-90), 
            ManufactureYear = 2023, 
            Condition = 8.8 
        }
    };

    static void ViewAllProducts()
    {
        decimal totalValue = inventory.Where(p => !p.Sold).Sum(p => p.Price);
        Console.WriteLine("\nCurrent Inventory:");
        Console.WriteLine($"Total Inventory Value: ${totalValue:F2}");
        Console.WriteLine("------------------------");
        
        foreach (var product in inventory.Where(p => !p.Sold))
        {
            Console.WriteLine($"{inventory.IndexOf(product) + 1}. {product.Name} - ${product.Price:F2}");
        }
    }

    static void ViewDetailedProduct()
    {
        ViewAllProducts();
        Console.Write("\nEnter the number of the product to view details (or 0 to return): ");
        
        if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= inventory.Count)
        {
            var product = inventory[choice - 1];
            Console.WriteLine("\nDetailed Product Information:");
            Console.WriteLine("------------------------");
            Console.WriteLine($"Name: {product.Name}");
            Console.WriteLine($"Price: ${product.Price:F2}");
            Console.WriteLine($"Material: {product.Material}");
            Console.WriteLine($"Condition: {product.Condition:F1}/10.0");
            Console.WriteLine($"Manufacture Year: {product.ManufactureYear} (Age: {product.AgeInYears} years)");
            Console.WriteLine($"In Stock Since: {product.StockDate:MM/dd/yyyy} ({product.DaysInStock} days)");
            Console.WriteLine($"Status: {(product.Sold ? "Sold" : "Available")}");
        }
        else if (choice != 0)
        {
            Console.WriteLine("\nInvalid selection. Please try again.");
        }
    }

    static void ViewLatestProducts()
    {
        var recentProducts = inventory
            .Where(p => !p.Sold && p.DaysInStock <= 90)
            .OrderBy(p => p.StockDate)
            .ToList();

        if (recentProducts.Any())
        {
            Console.WriteLine("\nProducts Added in Last 90 Days:");
            Console.WriteLine("------------------------");
            foreach (var product in recentProducts)
            {
                Console.WriteLine($"{product.Name} - Added {product.DaysInStock} days ago");
                Console.WriteLine($"Price: ${product.Price:F2}");
                Console.WriteLine("------------------------");
            }
        }
        else
        {
            Console.WriteLine("\nNo products have been added in the last 90 days.");
        }
    }

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nThrown for a Loop - Used Sporting Equipment");
            Console.WriteLine("1. View All Products");
            Console.WriteLine("2. View Detailed Product Information");
            Console.WriteLine("3. View Latest Products (Last 90 Days)");
            Console.WriteLine("4. Exit");
            Console.Write("\nSelect an option (1-4): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        ViewAllProducts();
                        break;
                    case 2:
                        ViewDetailedProduct();
                        break;
                    case 3:
                        ViewLatestProducts();
                        break;
                    case 4:
                        running = false;
                        Console.WriteLine("\nThank you for visiting Thrown for a Loop!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid option. Please select 1-4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nInvalid input. Please enter a number between 1-4.");
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}