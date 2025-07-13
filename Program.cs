using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Project.DatabaseUtilities;

class Program
{
  static void Main()
  {
    var database = new Database();

    Console.WriteLine("Welcome to the Product Management System!");

    while (true)
    {
      Console.WriteLine("Display products (d), Add a product (a), or Quit (q)?");
      var choice = char.ToLower(Console.ReadKey(true).KeyChar);

      if (choice == 'q')
      {
        Console.WriteLine("\nExiting the program. Goodbye!");
        break;
      }

      if (choice == 'd')
      {
        Console.WriteLine("\nCurrent Products:");
        foreach (var product in database.Products)
        {
          Console.WriteLine($"- {product.Name}: ₪{product.Price}");
        }
        continue;
      }

      Console.WriteLine("Enter a product name:");
      var name = Console.ReadLine()!;

      Console.WriteLine("Enter the product price (₪):");
      var price = double.Parse(Console.ReadLine()!);

      database.Products.Add(new Product(name, price));
      database.SaveChanges();

      Console.WriteLine($"Product '{name}' with price {price} added successfully.");
    }
  }
}


class Database() : DatabaseCore("database")
{
  /*──────────────────────────────╮
  │ Add your database tables here │
  ╰──────────────────────────────*/
  public DbSet<Product> Products { get; set; } = default!;
}

class Product(string name, double price)
{
  [Key] public int Id { get; set; } = default!;
  public string Name { get; set; } = name;
  public double Price { get; set; } = price;
}