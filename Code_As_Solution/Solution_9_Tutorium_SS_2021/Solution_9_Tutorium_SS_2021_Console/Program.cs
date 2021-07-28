using System;

using Solution_9_Tutorium_SS_2021_Library;

namespace Solution_9_Tutorium_SS_2021_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      TestWareHouse();
    }

    static void TestStandardArticle()
    {
      var articleNES = new StandardArticle("NES", 200.0, 100.0);
      var articleNESCopy = new StandardArticle("NES", 200.0, 100.0);
      var articleSNES = new StandardArticle("SNES", 400.0, 200.0);

      Console.WriteLine($"articleNES.IsSame(articleSNES) = {articleNES.IsSame(articleSNES)}");
      Console.WriteLine($"articleNES.IsSame(articleNESCopy) = {articleNES.IsSame(articleNESCopy)}");
      Console.WriteLine($"{articleNES.ToString()}");
    }

    static void TestDiscountArticle()
    {
      var nes = new StandardArticle("NES", 200.0, 100.0);
      var discountArticle = new DiscountArticle(nes, 10);
      var tooCheap = new DiscountArticle(nes, 50);
      var stillTooCheap = new DiscountArticle(nes, 50);


      Console.WriteLine($"{discountArticle.ToString()}");

      try
      {
        var invalidItem = new DiscountArticle(nes, 200);
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine(e.Message);
      }

      Console.WriteLine($"discountArticle.IsSame(tooCheap) = {discountArticle.IsSame(tooCheap)}");
      Console.WriteLine($"tooCheap.IsSame(stillTooCheap) = {tooCheap.IsSame(stillTooCheap)}");
    }

    static void TestBundlerWare()
    {
      var bundleWare = new BundleWare();

      bundleWare.Add(new StandardArticle("TV", 1000.0, 500.0));
      Console.WriteLine(bundleWare.ToString());
      bundleWare.Add(200.0, 100.0);
      Console.WriteLine(bundleWare.ToString());

      var otherBundleWare = new BundleWare();
      otherBundleWare.Add(new StandardArticle("TV", 1000.0, 500.0));
      Console.WriteLine($"otherBundleWare.IsSame(bundleWare) = {otherBundleWare.IsSame(bundleWare)}");
      otherBundleWare = new BundleWare();
      otherBundleWare.Add(new StandardArticle("TV", 800.0, 400.0));
      otherBundleWare.Add(new StandardArticle("Radio", 400.0, 200.0));
      Console.WriteLine($"otherBundleWare.IsSame(bundleWare) = {otherBundleWare.IsSame(bundleWare)}");
      otherBundleWare.Add(bundleWare);
      Console.WriteLine(otherBundleWare.ToString());
    }

    static void TestWareHouse()
    {
      var wareHouse = new Warehouse();
      var articleToRemoveLater = new StandardArticle("TV", 2000.0, 1000.0);
      wareHouse.AddArticle(articleToRemoveLater);
      wareHouse.AddArticle(new StandardArticle("Chips", 3.0, 2.0));
      var discounted = new DiscountArticle(new StandardArticle("Car", 10000.0, 5000.0), 40);
      wareHouse.AddArticle(discounted);
      var bundleWare = new BundleWare();
      Console.WriteLine($"wareHouse.GetSummary() = {wareHouse.GetSummary()}");
      bundleWare.Add(new StandardArticle("TV", 1000.0, 500.0));
      bundleWare.Add(200.0, 100.0);
      wareHouse.AddArticle(bundleWare);
      Console.WriteLine($"(Sell price, Buy price) = {(wareHouse.GetWholeSellValue(), wareHouse.GetWholeBuyValue())}");
      Console.WriteLine($"wareHouse.GetWholeSellValue() = {wareHouse.GetWholeSellValue()}");
      Console.WriteLine($"wareHouse.GetWholeBuyValue() = {wareHouse.GetWholeBuyValue()}");
      Console.WriteLine($"wareHouse.GetExpectedProfit() = {wareHouse.GetExpectedProfit()}");
      wareHouse.RemoveArticle(articleToRemoveLater);
      Console.WriteLine($"(Sell price, Buy price) = {(wareHouse.GetWholeSellValue(), wareHouse.GetWholeBuyValue())}");
      Console.WriteLine($"wareHouse.GetWholeSellValue() = {wareHouse.GetWholeSellValue()}");
      Console.WriteLine($"wareHouse.GetWholeBuyValue() = {wareHouse.GetWholeBuyValue()}");
      Console.WriteLine($"wareHouse.GetExpectedProfit() = {wareHouse.GetExpectedProfit()}");
      Console.WriteLine($"{wareHouse.ToString()}");
    }
  }

  
}
