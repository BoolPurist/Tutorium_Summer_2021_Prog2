using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_11_Tutorium_SS_2021_Library
{
  public class Enemy : Entity
  {
    public override char Identifier => 'E';
    public Enemy(int x, int y) : base(x, y)
    {
    }

    public override void OnCollision(Entity entity, MoveDirection direction)
    {
      // If the enemy moves into the player the player has to die.
      if (entity is Player player)
      {
        player.Die();        
      }      
      else if (entity == null)
      {
        // Otherwise the player just went outside the level.
        base.OnCollision(this, direction);
      }
    }
  }
}
