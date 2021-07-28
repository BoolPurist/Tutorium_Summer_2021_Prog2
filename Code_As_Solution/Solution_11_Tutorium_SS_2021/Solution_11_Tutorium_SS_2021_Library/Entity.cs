using System;

namespace Solution_11_Tutorium_SS_2021_Library
{
  public enum MoveDirection
  {
    Left,
    Right,
    Up,
    Down
  }

  public delegate void Movement(Entity self, MoveDirection moveDirection);

  public class Entity
  {
    // Identifier char for representing the kind of an object
    public virtual char Identifier { get; } = 'x';

    // Should be fired if the object moves, the X or Y property is changed
    public event Movement HasMoved;

    // Location of a game object in a level (intance of the class level)
    private int _x = 0;
    private int _y = 0;

    public int X => _x;
    public int Y => _y;

    public Entity(int x, int y)
    {
      _x = x;
      _y = y;
    }

    // Methods to move an object
    public void MoveLeft()
    {
      _x--;
      // Compact syntax for calling the event HasMoved including with null check
      HasMoved?.Invoke(this, MoveDirection.Left);
      // This Syntax above translates to this below
      //if (HasMoved != null)
      //{
      //  HasMoved.Invoke(this, MoveDirection.Left);
      //}
    }

    public void MoveRight()
    {
      _x++;
      HasMoved?.Invoke(this, MoveDirection.Right);
    }

    public void MoveUp()
    {
      _y--;
      HasMoved?.Invoke(this, MoveDirection.Up);
    }

    public void MoveDown()
    {
      _y++;
      HasMoved?.Invoke(this, MoveDirection.Down);
    }

    // Method which is registered under the event Collision under the class Level
    public virtual void OnCollision(Entity self, Entity other, MoveDirection direction)
    {
      if (self == this)
      {
        // Revert the position of an object
        // Move it back to the right
        if (direction == MoveDirection.Left)
        {
          _x++;
        }
        // Move it back to the left
        else if (direction == MoveDirection.Right)
        {
          _x--;
        }
        // Move it back downwards
        else if (direction == MoveDirection.Up)
        {
          _y++;
        }
        // Move it back upwards
        else
        {
          _y--;
        }
      }
    }

    
    public override string ToString()
    {
      return $"{Identifier}: ({_x}, {_y})";
    }



  }
}
