using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
  partial class Program
  {
    // Lösung für die Nachtimplementierung zu folgenden Link:
    // https://docs.microsoft.com/en-us/dotnet/api/system.math.clamp?view=net-5.0#System_Math_Clamp_System_Double_System_Double_System_Double_
    public static double CustomClamp(double value, double min, double max)
    {
      // NaN kann nur durch die Methode IsNaN abgefragt werden
      if (Double.IsNaN(value))
      {
        return Double.NaN;
      }
      // Das ist ein kompakte Schreibweise zu if und else
      value = value < min ? min : value;
      // value = value < min ? min : value;
      // ist gleich
      // if (value < min)
      // {
      //    value = min;
      // }
      // else 
      // {
      //    value = value;
      // }
      value = value > max ? max : value;
      return value;
    }
  }
}
