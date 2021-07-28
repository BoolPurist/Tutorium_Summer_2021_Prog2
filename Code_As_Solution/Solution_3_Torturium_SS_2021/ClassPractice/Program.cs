using System;

namespace ClassPractice
{
  class Program
  {
    static void Main(string[] args)
    {
      
    }

    static void TestTask0() {
      Product dummyProduct = new Product("Dummy", 0.0, 0);
      Product dummyProduct1 = new Product("Dummy", 0.0, 0);
      Product product = new Product("TV", 8000.0, 2);
      Console.WriteLine($"product.ID = {product.ID}");
      Console.WriteLine($"product.Name = {product.Name}");
      Console.WriteLine($"product.SinglePrice = {product.SinglePrice}");
    }

    static void TestTask1()
    {
      Product product = new Product("Gurke", 0.5, 10);
      Console.WriteLine($"product.GetProductInfo() = {product.GetProductInfo()}");
    }

    static void TestTask2()
    {
      Product product = new Product("Chips", 2.0, 5);
      Console.WriteLine($"product.WholePrice = {product.WholePrice}");
    }

    static void TestTask3()
    {
      Product[] list = new Product[] { new Product("Auto", 20000.0, 3), new Product("Chips", 2.0, 20) };
      Console.WriteLine($"Product.GetWholePrice(list) = {Product.GetWholePrice(list)}");
    }

    static void TestTask4()
    {
      var list = new Product[] { new Product("Auto", 20000.0, 3), new Product("Chips", 2.0, 20) };
      Console.WriteLine(Product.ProductTable(list));
    }


  }
}
