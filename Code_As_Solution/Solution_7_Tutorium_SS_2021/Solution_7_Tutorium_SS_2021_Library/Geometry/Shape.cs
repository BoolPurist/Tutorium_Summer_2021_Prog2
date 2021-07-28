using System;

namespace Solution_7_Tutorium_SS_2021_Library.Geometry
{
  public abstract class Shape
  {
     
    // Gibt die Oberfleache  eines geometrischen Form zurueck
    public abstract double Surface { get; }

    // Gibt die Flaeche eines geometrischen Form zurueck
    public abstract double Volume { get; }
  }
}
