using System;

using Xunit;

using Solution_7_Tutorium_SS_2021_Library.Geometry;

namespace Solution_7_Tutorium_SS_2021_XUnit
{
  public class TestRectangle
  {
    private const int ROUNDING_FACTOR = 1;

    [Fact]
    public void TestRectangle_NoSide()
    {
      const double ZERO = 0.0;
      var actualRectangle = new Rectangle();
      Assert_WidthLengthSurfaceVolume(actualRectangle, ZERO, ZERO, ZERO, ZERO);
    }

    [Theory]
    [MemberData(nameof(TestData_RectangleAsCube))]
    public void TestRectangle_OneSide(double cubeSide, double expectedSurface, double expectedVolume)
    {
      var actualRectangle = new Rectangle(cubeSide);
      double actualWidth = actualRectangle.Width;
      double actualLength = actualRectangle.Length;

      Assert_WidthLengthSurfaceVolume(actualRectangle, actualWidth, actualLength, expectedSurface, expectedVolume);
    }

    [Theory]
    [MemberData(nameof(TestData_Rectangle))]
    public void TestRectangle_TwoSides(
      double expectedLength, 
      double expectedWidth, 
      double expectedSurface, 
      double expectedVolume)
    {
      var actualRectangle = new Rectangle(expectedLength, expectedWidth);
      double actualLength = actualRectangle.Length;
      double actualWidth = actualRectangle.Width;

      Assert_WidthLengthSurfaceVolume(actualRectangle, actualWidth, actualLength, expectedSurface, expectedVolume);
    }

    [Fact]
    public void TestRectangle_Throws_OutOfRangeException()
    {
      Action[] casesForExceptions = new Action[]
      {
        () => new Rectangle(-2.15),
        () => new Rectangle(-789.0, -85.0),
        () => new Rectangle(-8.456, 4.0),
        () => new Rectangle(4.0, -4.78),
        () => 
        { 
          var rectangle = new Rectangle() { Width = -89.0 };          
        },
        () =>
        {
          var rectangle = new Rectangle() { Length = -7.1 };
        }
      };

      foreach (Action exceptionShouldHappen in casesForExceptions)
      {
        Assert.Throws<ArgumentOutOfRangeException>(exceptionShouldHappen);
      }
      
    }

    private static void Assert_WidthLengthSurfaceVolume(
      Rectangle actualRectangle,
      double expectedWidth, 
      double expectedLength, 
      double expectedSurface, 
      double expectedVolume
      )
    {
      Assert.Equal<double>(expectedWidth, actualRectangle.Width);
      Assert.Equal<double>(expectedLength, actualRectangle.Length);
      Assert.Equal<double>( Math.Round(expectedSurface, ROUNDING_FACTOR) , Math.Round(actualRectangle.Surface, ROUNDING_FACTOR) );
      Assert.Equal<double>( Math.Round(expectedVolume, ROUNDING_FACTOR), Math.Round(actualRectangle.Volume, ROUNDING_FACTOR));
    }

    // 1. Parameter as double. Side of a cube.
    // 2. Parameter as double. Surface of a cube.
    // 3. Parameter as double. Volume of a cube.
    public static TheoryData<double, double, double> TestData_RectangleAsCube
    {
      get
      {
        return new TheoryData<double, double, double>()
        {
          {
            2.0,
            8.0,
            4.0
          },
          {
            5.789,
            23.2,
            33.5
          },
          {
            100,
            400.0,
            10000
          },
        };
      }
    }

    // 1. Parameter as double. Length of a rectangle.
    // 2. Parameter as double. Width of a rectangle.
    // 3. Parameter as double. Surface of a cube.
    // 4. Parameter as double. Volume of a cube.
    public static TheoryData<double, double, double, double> TestData_Rectangle
    {
      get
      {
        return new TheoryData<double, double, double, double>()
        {
          {
            2.0,
            3.0,
            10.0,
            6.0
          },
          {
            25.25,
            40.1,
            130.7,
            1012.5
          },
          {
            121,
            2458,
            5158.0,
            297418.0
          },
        };
      }
    }

    
  }
}
