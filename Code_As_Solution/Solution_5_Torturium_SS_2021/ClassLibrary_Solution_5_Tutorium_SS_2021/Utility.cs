using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary_Solution_5_Tutorium_SS_2021
{
  public static class Utility
  {
    // Sortiert ein array aufsteigend.
    // Beispiel:
    // Unsortiertes array [ 8, 2, -4 ]
    // Sortiertes array [ -4, 2 , 8 ]
    // Hier wird der Bubblesort angewendet für die Sortierung.
    public static void Sort(int[] numbers)
    {
      // Leeres array oder nur mit einen Element ist schon sortiert.
      if (numbers == null || numbers.Length <= 1)
      {
        return;
      }
      else
      {
        // Wenn ein Array schon sortiert wurde, dann wird ein Tausch von 2 Element nicht notwendig sein.
        // Wenn ein Tausch jedoch stattfindet dann muss der Loop noch mal durchgeführt werden.
        // Solange bis bei einem Durchlauf kein Tausch mehr nötig ist.
        bool wasNotSorted = true;
        do
        {
          wasNotSorted = true;
          for (int currentPosition = 0; currentPosition < numbers.Length - 1; currentPosition++)
          {
            // Rechter Nachbar ist größer und es wird ein Tausch gemacht mit den aktuellen Element
            // um ein genau an dieser Stelle zu sortieren.
            if (numbers[currentPosition] > numbers[currentPosition + 1])
            {
              // Durchführen eines Tausches von dem aktuellen Element und seinem rechten Nachbar.
              int tmp = numbers[currentPosition];
              numbers[currentPosition] = numbers[currentPosition + 1];
              numbers[currentPosition + 1] = tmp;
              // Ein Tausch wurde durchgeführt und es muss noch mal das array 
              // durch gelaufen werden.
              wasNotSorted = false;
            }
          }
        } while (!wasNotSorted);
        // Wenn der loop ohne notwendigen Tausch durchlaufen wurde, dann ist das Array sortiert.
      }
      
    }
  }
}
