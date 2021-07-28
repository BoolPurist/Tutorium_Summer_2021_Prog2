using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Solution_9_Tutorium_SS_2021_Library
{
  public class Warehouse
  {
    private readonly List<IArticle>  _allArticle = new List<IArticle>();

    public void AddArticle(IArticle article)
    {
      _allArticle.Add(article);

    }

    public void RemoveArticle(IArticle articleToRemove)
    {
      foreach(IArticle oneArticle in this._allArticle)
      {
        if (oneArticle.IsSame(articleToRemove) == true)
        {
          this._allArticle.Remove(oneArticle);
          return;
        }
      }
    }

    public double GetWholeSellValue()
    {
      double sum = 0.0;
      foreach (IArticle article in  this._allArticle)
      {
        sum += article.SellPrice;
      }

      return sum;
    }

    public double GetWholeBuyValue()
    {
      double sum = 0.0;
      foreach (IArticle article in this._allArticle)
      {
        sum += article.BuyPrice;
      }

      return sum;
    }

    public double GetExpectedProfit()
    {
      double sum = 0.0;
      foreach (IArticle article in this._allArticle)
      {
        sum += article.SellPrice - article.BuyPrice;
      }

      return sum;
    }

    public string GetSummary() => $"Expected Profit: {this.GetExpectedProfit()}, Whole Buy Value: {this.GetWholeBuyValue()}, Whole Sale value: {this.GetWholeSellValue()}";

    public override string ToString()
    {
      string result = "";

      foreach (IArticle article in this._allArticle)
      {
        result += $"{article.ToString()}\n";
      }

      return result;
    }
    

  }
}
