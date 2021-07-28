﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_11_Tutorium_SS_2021_Library
{
  public delegate void EntityAction (Entity entity);

  public class Player : Entity
  {
    public event EntityAction HasDied;

    public override char Identifier => 'P';

      
    public Player(int x, int y) : base(x, y)
    {
    }


    public override void OnCollision(Entity entity, MoveDirection direction)
    {
      // If in a new location is an enemy the player dies, the game ends
      if (entity is Enemy)
      {
        Die();
      }
      else
      {
        // Otherwise the player just went outside the level.
        base.OnCollision(this, direction);
      }

    }

    public void Die()
    {
      HasDied?.Invoke(this);
    }
  }
}
