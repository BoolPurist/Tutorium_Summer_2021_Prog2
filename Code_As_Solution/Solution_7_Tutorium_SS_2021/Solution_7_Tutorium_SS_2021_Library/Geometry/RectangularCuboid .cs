using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_7_Tutorium_SS_2021_Library.Geometry
{
  public class RectangularCuboid : Rectangle
  {
    public double Height
    {
      get => this._height;
      set
      {
        if (value < 0)
        { 
          throw new ArgumentOutOfRangeException(nameof(this.Height), value, ERROR_MESSAGE);
        }
        else
        {
          this._height = value;
        }
      }
    }

    public override double Surface
    {
      get
      {
        double bottomTopSurface = 2.0 * base.Volume;
        double leftRightInHeightSurface = 2.0 * (this.Height * this.Width);
        double frontBehindInHeightSurface = 2.0 * (this.Height * this.Length);

        return bottomTopSurface + leftRightInHeightSurface + frontBehindInHeightSurface;
      }
    }

    public override double Volume => base.Volume * this.Height;

    public RectangularCuboid(double length, double width, double height) : base(length, width)
    {
      this.Height = height;
    }

    public RectangularCuboid(double cubdeSide) : this(cubdeSide, cubdeSide, cubdeSide) { }

    public RectangularCuboid() : this(0.0, 0.0, 0.0) { }

    public override string ToString() => $"Length: {this.Length}, Width: {this.Width}, Height: {this.Height}";


    protected double _height = 0;
  }

  
}
