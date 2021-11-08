using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
  partial class Program
  {
    public static string[] GetUniqueValues(string[] values)
    {
      // Merkt sich wie viel werte einzigartig sind.
      int uniqueCounter = 0;
      
      // Hier wird jeder Wert einmal reingeschrieben. Wird dann aber wieder heraus genommen falls der Wert mehr als einmal gefunden wird.
      string[] possibleUniqueValues = new string[values.Length];

      for (int i = 0; i < values.Length; i++)
      {
        
        possibleUniqueValues[uniqueCounter] = values[i];
        bool isUnique = true;

        for (int j = 0; j < values.Length; j++)
        {
          // i != j, da wir von Anfang bis Ende gehen soll, wird beim Durchlauf das element sich selbst einmal vergleichen ohne diesen Check. 
          // Deshalb müssen wir an dieser einen Stelle skippen.
          if (i != j && values[i] == values[j])
          {
            // Wert wurde schon ein zweites Mal gefunden. Es wird wieder aus der Liste heraus genommen
            possibleUniqueValues[uniqueCounter] = null;
            isUnique = false;
            break;
          }
        }

        // For Schleife kam bis zum Ende ohne den Wert ein 2. Mal zu finden.
        if (isUnique)
        {
          uniqueCounter++;
        }    
      }

      string[] uniqueValues = new string[uniqueCounter + 1];

      // Kopieren der Ergebnisse in ein Array welches exakt groß genug ist um die Ergebnisse zu speichern.
      for (int i = 0; i < uniqueValues.Length; i++)
      {
        uniqueValues[i] = possibleUniqueValues[i];
      }

      return uniqueValues;
    }
  }
}
