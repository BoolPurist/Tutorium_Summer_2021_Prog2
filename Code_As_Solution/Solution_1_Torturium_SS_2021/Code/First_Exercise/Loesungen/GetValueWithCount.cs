using System;
using System.Collections.Generic;
using System.Text;

namespace First_Exercise
{
  public class ValueWithCount
  {
    public ValueWithCount(string value)
    {
      Value = value;
      Count = 1;
    }

    public string Value { get; private set; } // Wert
    public int Count { get; private set; } // Wie oft der Wert vorkommt

    // Von außen soll nur der Wert um eins erhöht werden.
    public void IncrementCount() => Count++;
  }

  partial class Program
  {
    public static ValueWithCount[] GetValuesWithCount(string[] values)
    {
      // Anzahl von gefunden Werten
      // Wenn ein Wert nochmal gefunden wird, dann wird dieser Counter nicht erhöht.
      int uniqueCounte = 0;
      // Bereits gelesene Werte
      ValueWithCount[] readValues = new ValueWithCount[values.Length];
     

      foreach (string value in values)
      {
        bool alreadyRead = false;

        // Gehe durch alle zuvor gefunden Werte
        for (int j = 0; j < uniqueCounte; j++)
        {
          // Wert wurde schon mal gefunden
          if (readValues[j].Value == value)
          {
            alreadyRead = true;
            // Da wert schon mal gefunden wurde, einfach den Count erhöhen.
            readValues[j].IncrementCount();
            break;
          }
        }

        // Wir haben einen Wert zum 1. Mal gefunden.
        if (!alreadyRead)
        {
          // Wir legen den neu gefunden Wert mit den Count 1 an.
          readValues[uniqueCounte++] = new ValueWithCount(value);
        }
      }

      // Wir kennen nun die Anzahl der gefunden Werte.
      ValueWithCount[] allValues = new ValueWithCount[uniqueCounte];

      // Wir kopieren die gefunden Werte in ein Array welches exakt groß genug ist.
      for (int i = 0; i < allValues.Length; i++)
      {
        allValues[i] = readValues[i];      
      }

      return allValues;
    }
  }
}
