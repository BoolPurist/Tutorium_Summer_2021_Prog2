using System;

using Xunit;

using Solution_7_Tutorium_SS_2021_Library.Geometry;

namespace Solution_7_Tutorium_SS_2021_XUnit
{

  public class TestRectangularCuboid
  {
    private const int ROUNDING_FACTOR = 1;

    [Theory]
    [MemberData(nameof(TestData_RectangleCuboid))]
    public void Test_RectangularCuboid(
      double actualLength, 
      double actualWidth, 
      double actualHeight, 
      double expectedSurface, 
      double expectedVolume
      )
    {
      var actualRectangleCuboid = new RectangularCuboid(actualLength, actualWidth, actualHeight);
      double expectedWidth = actualRectangleCuboid.Width;
      double expectedHeight = actualRectangleCuboid.Height;
      double expectedLength = actualRectangleCuboid.Length;

      Assert_WidthLengthSurfaceVolume(
        actualRectangleCuboid, 
        expectedWidth, 
        expectedLength, 
        expectedHeight,
        expectedSurface,
        expectedVolume
        );
    }

    [Fact]
    public void TestRectangle_Throws_OutOfRangeException()
    {
      Action[] casesForExceptions = new Action[]
      {
        () => new RectangularCuboid(-2.15),
        () => new RectangularCuboid(-789.0, -85.0, -15.0),
        () => new RectangularCuboid(-789.0, 85.0, 15.0),
        () => new RectangularCuboid(789.0, -85.0, 15.0),
        () => new RectangularCuboid(789.0, 85.0, -15.0),
        () =>
        {
          var cuboid = new RectangularCuboid();
          cuboid.Height = -2.0;
        }
        
      };

      foreach (Action exceptionShouldHappen in casesForExceptions)
      {
        Assert.Throws<ArgumentOutOfRangeException>(exceptionShouldHappen);
      }

    }

    private static void Assert_WidthLengthSurfaceVolume(
      RectangularCuboid actualRectangle,
      double expectedWidth,
      double expectedLength,
      double expectedHeight,
      double expectedSurface,
      double expectedVolume
    )
    {
      Assert.Equal<double>(expectedWidth, actualRectangle.Width);
      Assert.Equal<double>(expectedLength, actualRectangle.Length);
      Assert.Equal<double>(expectedHeight, actualRectangle.Height);
      Assert.Equal<double>(Math.Round(expectedSurface, ROUNDING_FACTOR), Math.Round(actualRectangle.Surface, ROUNDING_FACTOR));
      Assert.Equal<double>(Math.Round(expectedVolume, ROUNDING_FACTOR), Math.Round(actualRectangle.Volume, ROUNDING_FACTOR));
    }

    // 1. Parameter as double. Length of a rectangle.
    // 2. Parameter as double. Width of a rectangle.
    // 3. Parameter as double. Height of a rectangle.
    // 4. Parameter as double. Surface of a cube.
    // 5. Parameter as double. Volume of a cube.
    public static TheoryData<double, double, double, double, double> TestData_RectangleCuboid
    {
      get
      {
        return new TheoryData<double, double, double, double, double>()
        {
          {
            10.0,
            4.0,
            5.0,
            220.0,
            200.0
          },
          {
            1.5,
            1.25,
            0.65,
            7.3,
            1.22
          }

        };
      }
    }
  }
}
