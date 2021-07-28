using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_9_Tutorium_SS_2021_Library
{
  public interface IArticle
  {
    string Name { get; }
    double SellPrice { get; }
    double BuyPrice { get; }

    bool IsSame(IArticle otherArticle);
  }
}
