using System;

using Solution_7_Tutorium_SS_2021_Library.Geometry;

namespace Solution_7_Tutorium_SS_2021_Console
{
  class Program
  {
    static void Main()
    {
      TestRectangleExceptions();
    }

    static void TestRectangle()
    {
      var rectangle = new Rectangle();
      Console.WriteLine(rectangle.ToString());
      rectangle = new Rectangle(2.0);
      Console.WriteLine(rectangle.ToString());
      rectangle = new Rectangle(5.25, 4.0);
      Console.WriteLine(rectangle.ToString());


      if (rectangle is Shape)
      {
        Console.WriteLine($"{nameof(Rectangle)} inherits from {nameof(Shape)}");
      }

      Console.WriteLine($"rectangle.Surface = {rectangle.Surface}");
      Console.WriteLine($"rectangle.Volume = {rectangle.Volume}");
      rectangle = new Rectangle(5.0);
      Console.WriteLine($"rectangle.Surface = {rectangle.Surface}");
      Console.WriteLine($"rectangle.Volume = {rectangle.Volume}");


    }

    static void TestRectangleExceptions()
    {
      var rectangle = new Rectangle();

      try
      {
        rectangle.Width = -2.0;
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine($"Error Message: {e.Message}");
        Console.WriteLine($"Name of wrong Parameter: {e.ParamName}");
        Console.WriteLine($"Wrong Value: {e.ActualValue}");
      }

      Console.WriteLine($"{new string('=', 50)}");

      try
      {
        rectangle.Length = -2.0;
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine($"Error Message: {e.Message}");
        Console.WriteLine($"Name of wrong Parameter: {e.ParamName}");
        Console.WriteLine($"Wrong Value: {e.ActualValue}");
      }

      Console.WriteLine($"{new string('=', 50)}");

      try
      {
        rectangle = new Rectangle(-2.0);
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine($"Error Message: {e.Message}");
        Console.WriteLine($"Name of wrong Parameter: {e.ParamName}");
        Console.WriteLine($"Wrong Value: {e.ActualValue}");
      }

    }

    static void TestRectungularCuboid()
    {
      var cuboid = new RectangularCuboid(10.0, 4.0, 5.0);
      Console.WriteLine(cuboid);

      if (cuboid is Rectangle)
      {
        Console.WriteLine($"{nameof(RectangularCuboid)} inherits from {nameof(Rectangle)}");
      }

      Console.WriteLine($"cuboid.Surface = {cuboid.Surface}");
      Console.WriteLine($"cuboid.Volume = {cuboid.Volume}");

      Console.WriteLine($"{new string('=', 50)}");

      try
      {
        cuboid.Height = -2.0;
      }
      catch (ArgumentOutOfRangeException e)
      {
        Console.WriteLine($"Error Message: {e.Message}");
        Console.WriteLine($"Name of wrong Parameter: {e.ParamName}");
        Console.WriteLine($"Wrong Value: {e.ActualValue}");
      }
    }
  }
}
