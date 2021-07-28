using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_7_Tutorium_SS_2021_Library.Geometry
{
  public class Rectangle : Shape
  {
    protected const string ERROR_MESSAGE = "Parameter must not be not negative";

    public override double Surface => 2 * this.Width + 2 * this.Length;

    public override double Volume => this.Width * this.Length;
    
    public double Length
    {
      get => this._length;
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(nameof(this.Length), value, ERROR_MESSAGE);
        }
        else
        {
          this._length = value;
        }        
      }
    }

    public double Width
    {
      get => this._width;
      set
      {
        if (value < 0)
        {
          throw new ArgumentOutOfRangeException(nameof(this.Width), value, ERROR_MESSAGE);
        }
        else
        {
           this._width = value;
        }
      }
    }

    public Rectangle() : this(0, 0) { }

    public Rectangle(double sideLength) : this(sideLength, sideLength) { }

    public Rectangle(double length, double width)
    {
      this.Length = length;
      this.Width = width;
    }

    public override string ToString() => $"Length: {this.Length}, Width: {this.Width}";

    protected double _length = 0;

    protected double _width = 0;

  }
}
