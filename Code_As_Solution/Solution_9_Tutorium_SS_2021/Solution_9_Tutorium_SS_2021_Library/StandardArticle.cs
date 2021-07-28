using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_9_Tutorium_SS_2021_Library
{
  public class StandardArticle : IArticle
  {
    private readonly string _name;

    private readonly double _sellPrice;
    private readonly double _buyPrice;


    public StandardArticle(string Name, double sellPrice, double buyPrice)
    {
      this._name = Name;
      this._sellPrice = sellPrice;
      this._buyPrice = buyPrice;
    }

    public string Name => this._name;

    public double SellPrice => this._sellPrice;

    public double BuyPrice => this._buyPrice;

    public bool IsSame(IArticle otherArticle) => this.Name == otherArticle.Name && this.SellPrice == otherArticle.SellPrice && this.BuyPrice == otherArticle.BuyPrice;

    public override string ToString() => $"Name: {this.Name}, sell price: {this.SellPrice}$, buy price: {this.BuyPrice}$";
    

  }
}
