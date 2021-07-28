using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_11_Tutorium_SS_2021_Library
{
  public class Level
  {
    private char _standardTile = '.';

    // Char for one empty tile, no object is located there.
    public char StandardTile {get; private set;} = '.';

    private Entity[,] _tileMap;

    // This should be fired if one object moves into another object
    public event Movement Collision;

    // Creating a level which is 2d array.
    public Level(int height,int width)
    {
      _tileMap = new Entity[height, width];
    }

    // Adds an entity to the level and sets up the event of one game object
    public void AddEntity(Entity newEntity)
    {
      // Places a game object in the level (2d array) in the loaction according to the coordinates of an entity.
      _tileMap[newEntity.Y, newEntity.X] = newEntity;
      // Level pays attention if a game objects moves
      newEntity.HasMoved += this.OnMove;
      // Added game object pays attention if the level detects a collision after the movement of the added object
      // collision means that 2 objects are in the same location
      this.Collision += newEntity.OnCollision;

      // The added entity is the player of the game
      if (newEntity is Player player)
      { 
        // Levels pays attention when the player is killed, collided with an enemy
        // An anonymous function, lambda is added as a reaction to this event
        player.HasDied += (Entity diedPlayer) => 
        {
          // Announcing the game has ended
          Console.WriteLine("Game over");
          Console.WriteLine($"Player died at Position ({diedPlayer.X}, {diedPlayer.Y})");

          // Take the player instance out of the level.
          for (int i = 0; i < _tileMap.GetLength(0); i++)
          {
            for (int j = 0; j < _tileMap.GetLength(1); j++)
            {
              if (_tileMap[i, j] == diedPlayer)
              {
                _tileMap[i, j] = null;
              }
            }
          }

          // Stop listening for the movement of the player because it is removed from the level
          player.HasMoved -= this.OnMove;
          
        };
      }
    }

    // Reaction of the movement of an game object
    public void OnMove(Entity entity, MoveDirection direction)
    {
      // Check if game object has moved outside the level
      if (entity.X < 0 || entity.X >= _tileMap.GetLength(1) || entity.Y < 0 || entity.Y >= _tileMap.GetLength(0))
      {
        Collision?.Invoke(null, direction);
        return;
      }

      // Check if the new position is already occupied by another object
      Entity otherEntity = _tileMap[entity.Y, entity.X];
      // Field is occupied
      if (otherEntity != null)
      {
        Collision?.Invoke(otherEntity, direction);
        return;
      }
      
      // Adjust position of object in the level to the new position of the object itself
      if (direction == MoveDirection.Left)
      {
        _tileMap[entity.Y, entity.X] = entity;
        _tileMap[entity.Y, entity.X + 1] = null;
      }
      else if (direction == MoveDirection.Right)
      {
        _tileMap[entity.Y, entity.X] = entity;
        _tileMap[entity.Y, entity.X - 1] = null;
      }
      else if (direction == MoveDirection.Up)
      {
        _tileMap[entity.Y, entity.X] = entity;
        _tileMap[entity.Y + 1, entity.X] = null;
      }
      else
      {
        _tileMap[entity.Y, entity.X] = entity;
        _tileMap[entity.Y - 1, entity.X] = null;
      }
    }

    // Printing out the whole level
    public override string ToString()
    {
      string grid = "";
      for (int i = 0; i < _tileMap.GetLength(0); i++)
      {
        for (int j = 0; j < _tileMap.GetLength(1); j++)
        {
          // If no object is on the tile then print the .
          if (_tileMap[i, j] == null)
          {
            grid += _standardTile;
          }
          else
          {
            // otherwise print the char representing the object.
            grid += _tileMap[i, j].Identifier;
          }
        }

        // Every Line is a row of the level.
        grid += "\n";
      }

      return grid;
    }
  }
}
