List<Product> products = new List<Product>
{
   new Product()
   {
       Name = "Football",
       Price = 15.00M,
       Sold = false,
       Material = "Leather",
       StockDate = new DateTime(2024, 11, 21),
       ManufactureYear = 2022,
       Condition = 1.2,
   },
   new Product()
   {
       Name = "Hockey Stick",
       Price = 12.00M,
       Sold = false,
       Material = "Wood",
       StockDate = new DateTime(2024, 12, 1),
       ManufactureYear = 2022,
       Condition = 4.2,
   },
   new Product()
   {
       Name = "Basketball",
       Price = 12.00M,
       Sold = true,
       Material = " Leather",
       StockDate = new DateTime(2024, 11, 20),
       ManufactureYear = 2023,
       Condition = 3.2,
   },
   new Product()
   {
       Name = "Tennis Racket",
       Price = 10.00M,
       Sold = false,
       Material = "Graphite",
       StockDate = new DateTime(2019, 8, 20),
       ManufactureYear = 2018,
       Condition = 3.2,
   },
   new Product()
   {
       Name = "Bowling Pin",
       Price = 8.00M,
       Sold = true,
       Material = "Wood",
       StockDate = new DateTime(2022, 5, 20),
       ManufactureYear = 2012,
       Condition = 5.2,
   },
   new Product()
   {
       Name = "Baseball",
       Price = 4.00M,
       Sold = true,
       Material = "Cork",
       StockDate = new DateTime(1931, 10, 30),
       ManufactureYear = 1931,
       Condition = 3.2,
   },
};

Console.WriteLine("_______________________");

string greeting =
    @"Welcome to Thrown for a Loop!
Your one-stop shop for used sporting equipment.";

Console.WriteLine(greeting);
string choice = null;
while (choice != "0")
{
    Console.WriteLine(@"Chose an option:
    0. Exit
    1. View All Products
    2. View Product Details
    3. View Latest Products");

    choice = Console.ReadLine();
    if (choice == "0")
    {
        Console.WriteLine("Goodbye!");
    }
    else if (choice == "1")
    {
        ListProducts();
        Console.WriteLine("_______________________");
    }
    else if (choice == "2")
    {
        ViewProductDetails();
        Console.WriteLine("_______________________");
    }
    else if (choice == "3")
    {
        ViewLatestProducts();
        Console.WriteLine("_______________________");
    }
}

void ViewProductDetails()
{
    ListProducts();

    Product chosenProduct = null;
    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: ");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    DateTime now = DateTime.Now;
    TimeSpan timeInStock = now - chosenProduct.StockDate;
    Console.WriteLine("_______________________");
    Console.WriteLine(@$"You chose: 
{chosenProduct.Name}. 
It is made out of {chosenProduct.Material}, and costs {chosenProduct.Price} dollars.
It is {now.Year - chosenProduct.ManufactureYear} years old.
It {(chosenProduct.Sold ? "is not available." : $"has been in stock for {timeInStock.Days} days.")}
Its condition (out of 1-5) is a {chosenProduct.Condition}");
}

void ListProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }

    Console.WriteLine($"Total inventory value: ${totalValue}");
    Console.WriteLine("Products:");
    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }
}

void ViewLatestProducts()
{
    List<Product> latestProducts = new List<Product>();
    DateTime threeMonthsAgo = DateTime.Now - TimeSpan.FromDays(90);
    foreach (Product product in products)
    {
        if (product.StockDate > threeMonthsAgo && !product.Sold)
        {
            latestProducts.Add(product);
        }
    }

    for (int i = 0; i < latestProducts.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {latestProducts[i].Name}");
    }
}