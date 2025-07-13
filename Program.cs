using System.ComponentModel.DataAnnotations;
using DatabaseUtilities;
using Microsoft.EntityFrameworkCore;

class Program
{
  static void Main()
  {

    var newProduct = new Product("name", 0);

  }
}


class Database() : DbBase("database")
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