using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
  partial class Program
  {
    public static bool IsUnique(string[] values, string valueToBeUnique)
    {
      // Merkt sich ob der Wert schon mal gefunden wurde.
      bool foundItOnce = false;

      foreach (string value in values)
      {
        // Abgleichen ob der gesucht Wert im array vorkommt.
        if (value == valueToBeUnique)
        {          
          // Wert wurde schon mal gefunden.
          if (foundItOnce)
          {
            // Wir müssen hier nicht mehr weiter machen und geben zurück
            return false;
          }
          else
          {
            // Merken uns das der Wert einmal gefunden wurde.
            foundItOnce = true;
          }
        }
      }

      // Der Wert wurde kein einziges Mal im array gefunden.
      return foundItOnce;
    }
  }
}
