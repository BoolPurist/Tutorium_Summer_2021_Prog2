using System;

namespace Second_Exercise
{
  class Program
  {
    static void Main(string[] args)
    {
      
    }

    static void TestProperty()
    {
      var euroMoney = new Euro(5L, 30L);
      Console.WriteLine($"euroMoney.TotalCents = {euroMoney.TotalCents}");
      Console.WriteLine($"euroMoney.Cents = {euroMoney.Cents}");
      Console.WriteLine($"euroMoney.EuroAmount = {euroMoney.EuroAmount}");
      Console.WriteLine(euroMoney.ToString());
      euroMoney = new Euro(-2L, 10L);
      Console.WriteLine($"euroMoney.TotalCents = {euroMoney.TotalCents}");
      Console.WriteLine($"euroMoney.Cents = {euroMoney.Cents}");
      Console.WriteLine($"euroMoney.EuroAmount = {euroMoney.EuroAmount}");
      Console.WriteLine(euroMoney.ToString());
      euroMoney = new Euro(510L);
      Console.WriteLine($"euroMoney.TotalCents = {euroMoney.TotalCents}");
      Console.WriteLine($"euroMoney.Cents = {euroMoney.Cents}");
      Console.WriteLine($"euroMoney.EuroAmount = {euroMoney.EuroAmount}");
      Console.WriteLine(euroMoney.ToString());
    }

    static void TestBinaryOperator()
    {
      Euro euroMoney = new Euro(2L, 80L);
      Euro summand = new Euro(1L, 50L);

      Console.WriteLine($"euroMoney + summand = {euroMoney + summand}");
      Console.WriteLine($"euroMoney - summand = {euroMoney - summand}");
      Console.WriteLine($"summand - euroMoney = {summand - euroMoney}");

      euroMoney += summand;
      Console.WriteLine($"euroMoney += summand; euroMoney = {euroMoney}");
      euroMoney -= summand;
      Console.WriteLine($"euroMoney -= summand; euroMoney = {euroMoney}");
    }

    static void TestUnaryOperator()
    {
      Euro euroMoney = new Euro(0L);

      euroMoney++;
      Console.WriteLine($"euroMoney++; euroMoney = {euroMoney}");
      euroMoney--;
      euroMoney--;
      Console.WriteLine($"euroMoney++; euroMoney = {euroMoney}");
    }

    static void TestCasting()
    {
      Euro positiveEuro = new Euro(2L, 0L);
      long totalCents = positiveEuro;
      Console.WriteLine($"totalCents = {totalCents}");

      if ((bool)positiveEuro)
      {
        Console.WriteLine("Euro is positive");
      }

      Euro negativeEuro = new Euro(-1L, 0L);
      if (!(bool)negativeEuro)
      {
        Console.WriteLine("Euro is negative");
      }
    }

    static void TestOperatorWithLong()
    {
      Euro euro = new Euro(0L);

      Console.WriteLine($"0 + 60 = {euro + 60}");
      Console.WriteLine($"120 + 0 = {120 + euro}");
      Console.WriteLine($"0 + 240 = {euro - 240}");
      euro += 200;
      Console.WriteLine($"120 - 200 = {120 - euro}");
    }

  }
}
