using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_11_Tutorium_SS_2021_Library
{
  // Just there to block a player
  public class Obstacle : Entity
  {
    public override char Identifier => '#';
    public Obstacle(int x, int y) : base(x, y)
    {
    }
  }
}
