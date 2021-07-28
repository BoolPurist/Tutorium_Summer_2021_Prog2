using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
  partial class Program
  {
    public static double GetAverage(double[] values)
    {
      double sum = 0.0;
     
      foreach (double value in values)
      {
        sum += value;
      }

      return sum / Convert.ToDouble(values.Length);
    }
  }
}
