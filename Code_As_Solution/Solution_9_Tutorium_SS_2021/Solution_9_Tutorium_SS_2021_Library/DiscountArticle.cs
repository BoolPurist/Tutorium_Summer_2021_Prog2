using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_9_Tutorium_SS_2021_Library
{
  public class DiscountArticle : IArticle
  {
    // Should be between 0.0 and 1.0
    private readonly double _discount;

    // Normal article whose sell price will be reduced by the discount (_discount)
    private readonly StandardArticle _article;
    public DiscountArticle(StandardArticle article, int discountInPrecent)
    {
      this._article = article;

      if (discountInPrecent < 0 || discountInPrecent > 100)
      {
        throw new ArgumentOutOfRangeException($"Parameter discountInPrecent must be between 0 and 100");
      }

      this._discount = Convert.ToDouble(discountInPrecent) / 100.0;
    }

    public string Name => this._article.Name;

    public double SellPrice => this._article.SellPrice - (this._article.SellPrice * this._discount);

    public double BuyPrice => this._article.BuyPrice;

    public bool IsSame(IArticle otherArticle)
     => this._article.BuyPrice == otherArticle.BuyPrice &&
      this._article.Name == otherArticle.Name &&
      this.SellPrice == otherArticle.SellPrice;

    public override string ToString() => $"Name: {this.Name}, sell price: {this.SellPrice}$, buy price: {this.BuyPrice}$, Discount: {this._discount}%";
  }
}
