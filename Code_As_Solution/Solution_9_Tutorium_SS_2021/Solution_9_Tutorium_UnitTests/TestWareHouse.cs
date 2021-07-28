using System;

using Xunit;

using Solution_9_Tutorium_SS_2021_Library;


namespace Solution_9_Tutorium_UnitTests
{
    
  public class TestWareHouse
  {
    [Theory]
    [MemberData(nameof(TestData_StandardArticle_IsSame))]
    public void Test_StandartArticle_IsSame(StandardArticle article, StandardArticle other, bool expectedReturnValue)
      => Test_IArticle_IsSame<StandardArticle>(article, other, expectedReturnValue);

    [Theory]
    [MemberData(nameof(TestData_DiscountArticle_IsSame))]
    public void Test_DiscountArticle_IsSame(DiscountArticle article,DiscountArticle other ,bool expectedReturnValue)
      => Test_IArticle_IsSame<DiscountArticle>(article, other, expectedReturnValue);

    [Theory]
    [MemberData(nameof(TestData_BundleWare_IsSame))]
    public void Test_BundleWare_IsSame(BundleWare article, BundleWare other, bool expectedReturnValue)
    => Test_IArticle_IsSame<BundleWare>(article, other, expectedReturnValue);

    [Theory]
    [MemberData(nameof(TestData_DiscountArticle_SellPrice))]
    public void Test_Discount_SellPrice(DiscountArticle actualArticle, double expectedSellPrice)
    {
      double actualSellPrice = actualArticle.SellPrice;
      Assert.Equal(expectedSellPrice, actualSellPrice);
    }

    [Fact]
    public void Test_BundleWare_AddWithBuyPriceAndSellPrice()
    {
      var bundleWare = new BundleWare();

      bundleWare.Add(new StandardArticle("TV", 1000.0, 500.0));
      AssertOneStep(1000.0, 500.0);

      bundleWare.Add(200.0, 100.0);
      AssertOneStep(1200.0, 600.0);

      void AssertOneStep(double expectedSellPrice, double expectedBuyPrice)
      {
        double actualSellPrice = bundleWare.SellPrice;
        double actualBuyPrice = bundleWare.BuyPrice;

        Assert.Equal(expectedSellPrice, actualSellPrice);
        Assert.Equal(expectedBuyPrice, actualBuyPrice);
      }
    }

    [Fact]
    public void Test_WareHouse_Everything()
    {
      var wareHouse = new Warehouse();

      var articleToRemoveLater = new StandardArticle("TV", 2000.0, 1000.0);
      wareHouse.AddArticle(articleToRemoveLater);
      wareHouse.AddArticle(new StandardArticle("Chpips", 3.0, 2.0));
      var discounted = new DiscountArticle(new StandardArticle("Car", 10000.0, 5000.0), 40);
      wareHouse.AddArticle(discounted);
      var bundleWare = new BundleWare();
      bundleWare.Add(new StandardArticle("TV", 1000.0, 500.0));
      bundleWare.Add(200.0, 100.0);
      wareHouse.AddArticle(bundleWare);

      AssertWareHouse(9203.0, 6602.0);
      
      wareHouse.RemoveArticle(articleToRemoveLater);

      AssertWareHouse(7203, 5602.0);

      void AssertWareHouse(double expectedSellValue, double expectedBuyValue)
      {
        double expectedProfit = expectedSellValue - expectedBuyValue;

        Assert.Equal(expectedSellValue, wareHouse.GetWholeSellValue());
        Assert.Equal(expectedBuyValue, wareHouse.GetWholeBuyValue());
        Assert.Equal(expectedProfit, wareHouse.GetExpectedProfit());
      }

    }

    private static void Test_IArticle_IsSame<TArticle>(TArticle article, TArticle other, bool expectedReturnValue) where TArticle : IArticle
    {
      bool actualReturnValue = article.IsSame(other);
      Assert.Equal(expectedReturnValue, actualReturnValue);
    }

    public static TheoryData<StandardArticle, StandardArticle, bool> TestData_StandardArticle_IsSame
    {
      get
      {
        return new TheoryData<StandardArticle, StandardArticle, bool>()
        {
          {
            new StandardArticle("TV", 2000.0, 1000.0),
            new StandardArticle("Chips", 2.0, 1.0),
            false
          },
          {
            new StandardArticle("TV", 3000.0, 2500.0),
            new StandardArticle("TV", 3000.0, 2500.0),
            true
          },
          {
            new StandardArticle("TV", 2000.0, 1000.0),
            new StandardArticle("TV", 2001.0, 1000.0),
            false
          },
          {
            new StandardArticle("TV", 2000.0, 1000.0),
            new StandardArticle("TV", 2000.0, 1001.0),
            false
          },
        };
      }
    }

    public static TheoryData<DiscountArticle, DiscountArticle, bool> TestData_DiscountArticle_IsSame
    {
      get
      {
        return new TheoryData<DiscountArticle, DiscountArticle, bool>()
        {
          {
            new DiscountArticle(new StandardArticle("TV", 2000.0, 1000.0), 10),
            new DiscountArticle(new StandardArticle("TV", 2000.0, 1000.0), 10),
            true
          },
          {
            new DiscountArticle(new StandardArticle("TV", 2000.0, 1000.0), 20),
            new DiscountArticle(new StandardArticle("TV", 2000.0, 1000.0), 10),
            false
          },
          {
            new DiscountArticle(new StandardArticle("TV", 5001.0, 1000.0), 10),
            new DiscountArticle(new StandardArticle("TV", 2000.0, 1000.0), 10),
            false
          },
          {
            new DiscountArticle(new StandardArticle("TV", 2000.0, 1000.0), 10),
            new DiscountArticle(new StandardArticle("TV", 2000.0, 5005.0), 10),
            false
          }
        };
      }
    }

    public static TheoryData<BundleWare, BundleWare, bool> TestData_BundleWare_IsSame
    {
      get
      {
        return new TheoryData<BundleWare, BundleWare, bool>()
        {
          {
            new BundleWare(400, 200),
            new BundleWare(400, 200),
            true
          },
          {
            new BundleWare(800, 200),
            new BundleWare(400, 200),
            false
          },
          {
            new BundleWare(400, 1200),
            new BundleWare(400, 200),
            false
          },
          {
            new BundleWare(400, 200),
            new BundleWare(800, 200),
            false
          }
        };
      }
    }

    public static TheoryData<DiscountArticle, double> TestData_DiscountArticle_SellPrice
    {
      get
      {
        return new TheoryData<DiscountArticle, double>()
        {
          {
            new DiscountArticle(new StandardArticle("TV", 1000.0, 100.0), 10),
            900.0
          },
          {
            new DiscountArticle(new StandardArticle("TV", 10000.0, 5000.0), 40),
            6000.0
          }
        };
      }
    }

    

  }



}