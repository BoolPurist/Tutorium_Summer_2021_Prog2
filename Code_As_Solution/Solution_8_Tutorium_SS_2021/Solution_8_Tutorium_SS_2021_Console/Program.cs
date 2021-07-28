using System;

using Solution_8_Tutorium_SS_2021_Library;

namespace Solution_8_Tutorium_SS_2021_Console
{
  class Program
  {
    static void Main()
    {
      TestGameEntity_Exceptions();
    }

    static void TestGameEntity_Save()
    {
      var entity = new GameEntity(100, 10, 0, 5, 12, 6);
      Console.WriteLine(entity.Save());
      Console.WriteLine($"{new string('=', 50)}");
      entity = new GameEntity(200, -45, 45, 10, 2, 0);
      Console.WriteLine(entity.Save());
    }

    static void TestGameEintity_Load()
    {
      var entity = new GameEntity();
      string savedFormat = "HP=100\n" +
          "X=0\n" +
          "Y=0\n" +
          "Level=2\n" +
          "Damage=5\n" +
          "Defense=8";
      entity.Load(savedFormat);
      Console.WriteLine(entity.ToString());
      entity = new GameEntity(50, 0, 0, 10, 10, 5);
      Console.WriteLine(entity.ToString());
      savedFormat = "HP=10\n" +
          "X=5\n" +
          "Y=89\n" +
          "Level=4\n" +
          "Damage=2\n" +
          "Defense=1";
      entity.Load(savedFormat);
      Console.WriteLine(entity.ToString());
    }

    static void TestGameEntity_Exceptions()
    {
      var entity = new GameEntity();
      string wrongFormat = "HP=100\n" +
          "X0\n" + // Error
          "Y=0\n" +
          "Level=2\n" +
          "Damage=5\n" +
          "Defense=8";
      try
      {
        entity.Load(wrongFormat);
      }
      catch (NoValidPropertyEntryException e)
      {
        Console.WriteLine(e.Message);
      }
      wrongFormat = "MP=100\n" + // Error
          "X=0\n" + 
          "Y=0\n" +
          "Level=2\n" +
          "Damage=5\n" +
          "Defense=8";
      try
      {
        entity.Load(wrongFormat);
      }
      catch (NoValidPropertyEntryException e)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine($"e.PropertyName = {e.PropertyName}");
      }
      wrongFormat = "HP=100\n" + 
          "X=0\n" + 
          "Y=0\n" +
          "Level=a\n" + // Error
          "Damage=5\n" +
          "Defense=8";
      try
      {
        entity.Load(wrongFormat);
      }
      catch (NoValidPropertyEntryException e)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine($"e.PropertyName = {e.PropertyName}");
        Console.WriteLine($"e.PropertyValue = {e.PropertyValue}");
      }
    }

    public static void TestGameEntity_Equals()
    {
      var entity = new GameEntity();
      var otherEntity = new GameEntity(2, 24, 278, 2, 2, 10);
      Console.WriteLine($"entity.Equals(otherEntity) = {entity.Equals(otherEntity)}");

      otherEntity = new GameEntity();
      Console.WriteLine($"entity.Equals(otherEntity) = {entity.Equals(otherEntity)}");

      entity = new GameEntity(2, 24, 278, -2, 2, 10);
      otherEntity = new GameEntity(2, 24, 278, 2, 2, 10);
      Console.WriteLine($"entity.Equals(otherEntity) = {entity.Equals(otherEntity)}");
    }
  }
}
