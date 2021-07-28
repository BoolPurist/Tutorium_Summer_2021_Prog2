using System;
using Solution_11_Tutorium_SS_2021_Library;

namespace Solution_11_Tutorium_SS_2021_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      TestDie();
    }

    public static void TestEntityMove()
    {
      var player = new Entity(0, 0);
      Console.WriteLine(player.ToString());
      player.MoveRight();
      player.MoveDown();
      Console.WriteLine(player.ToString());
      player.MoveUp();
      Console.WriteLine(player.ToString());
    }

    public static void TestLevelExample()
    {
      var level = new Level(5, 5);
      level.AddEntity(new Entity(0, 0));
      level.AddEntity(new Entity(2, 2));
      level.AddEntity(new Entity(2, 3));
      Console.WriteLine(level.ToString());
    }

    public static void TestLevel()
    {
      var level = new Level(10, 10);
      Console.WriteLine(level.ToString());
      level.AddEntity(new Entity(0, 0));
      level.AddEntity(new Entity(2, 2));
      level.AddEntity(new Entity(2, 3));
      level.AddEntity(new Entity(7, 7));
      level.AddEntity(new Entity(9, 8));
      Console.WriteLine(level.ToString());
    }

    public static void TestMovement()
    {
      var level = new Level(5, 5);
      var player = new Entity(2, 2);
      level.AddEntity(player);
      Console.WriteLine(level.ToString());
      player.MoveLeft();
      Console.WriteLine(level.ToString());
      player.MoveUp();
      Console.WriteLine(level.ToString());
      player.MoveRight();
      Console.WriteLine(level.ToString());
      player.MoveDown();
      Console.WriteLine(level.ToString());
    }

    public static void TestOutOfBoundMovement()
    {
      var level = new Level(3, 3);
      var player = new Entity(1, 1);
      level.AddEntity(player);
      Console.WriteLine(level.ToString());
      player.MoveLeft();
      Console.WriteLine(level.ToString());
      player.MoveLeft();
      Console.WriteLine(level.ToString());
    }

    public static void TestCollision()
    {
      var level = new Level(4, 4);
      level.LevelCollision += (entity, other, direction) => { Console.WriteLine($"Collision at {other.X}, {other.Y}"); };
      var player = new Player(1, 1);
      level.AddEntity(player);
      level.AddEntity(new Obstacle(1,2));
      level.AddEntity(new Obstacle(2,2));
      level.AddEntity(new Obstacle(0,3));
      level.AddEntity(new Obstacle(1,3));
      level.AddEntity(new Obstacle(2,3));
      level.AddEntity(new Obstacle(3,3));
      level.AddEntity(new Obstacle(0,0));
      Console.WriteLine(level.ToString());
      player.MoveRight();
      Console.WriteLine(level.ToString());
      player.MoveDown();
      player.MoveRight();
      player.MoveDown();
      Console.WriteLine(level.ToString());
      player.MoveDown();
    }

    public static void TestDie()
    {
      var level = new Level(4, 4);
      var player = new Player(1, 1);
      var enemy = new Enemy(2, 2);
      level.AddEntity(player);
      level.AddEntity(enemy);
      Console.WriteLine(level.ToString());
      enemy.MoveUp();
      player.MoveRight();
      enemy.MoveDown();
      Console.WriteLine(level.ToString());
      player.MoveLeft();      
      Console.WriteLine(level.ToString());

    }
  }
}
