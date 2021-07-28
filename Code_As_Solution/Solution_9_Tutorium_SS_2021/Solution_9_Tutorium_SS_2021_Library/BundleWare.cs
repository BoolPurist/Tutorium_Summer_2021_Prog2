using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_9_Tutorium_SS_2021_Library
{
  public class BundleWare : IArticle
  {
    private List<IArticle> _allPrices = new List<IArticle>();

    public BundleWare(double sellPrice, double buyPrice)
    {
      _allPrices.Add(new StandardArticle(null, sellPrice, buyPrice));
    }

    public BundleWare() : this(0.0, 0.0) { }

    public string Name => "Bundle Ware";

    public void Add(IArticle article) => this._allPrices.Add(new StandardArticle(this.Name, article.SellPrice, article.BuyPrice));

    public void Add(double sellPrice, double buyPrice) => this._allPrices.Add(new StandardArticle(this.Name, sellPrice, buyPrice));

    public double SellPrice
    {
      get
      {
        double total = 0.0;
        foreach (IArticle article in this._allPrices)
        {
          total += article.SellPrice;          
        }
        return total;
      }
      
    }

    public double BuyPrice
    {
      get
      {
        double total = 0.0;
        foreach (IArticle article in this._allPrices)
        {
          total += article.BuyPrice;
        }
        return total;
      }
    }

    public bool IsSame(IArticle otherArticle) => this.BuyPrice == otherArticle.BuyPrice && this.SellPrice == otherArticle.SellPrice;

    public override string ToString() => $"Whole sell value: {this.SellPrice}$, Whole buy value: {this.BuyPrice}$";
    
    

  }
}
