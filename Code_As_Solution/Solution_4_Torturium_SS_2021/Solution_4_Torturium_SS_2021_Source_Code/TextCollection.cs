using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_4_Torturium_SS_2021
{
  // Ist nichts anderes als eine Liste von Elementen
  public class TextCollection
  {
    // Innere Klasse zur Verwaltung eines Element in der     
    private class Text
    {
      // Wert eines Element in der Liste
      // Dieser Wert wird auch von außen der Klasse TextCollection gelesen und beschrieben
      public string Value { get; set; }

      // Nachfolger eines Element in der Liste
      public Text Next { get; set; }

      // Vorgänger eines Element in der Liste
      public Text Prev { get; set; }

      // Ein Element verpackt den Wert in der Liste.
      public Text(string value)
      {
        Value = value;
      }
    }

    // Star Punkt um sich zu merken wo die Liste anfängt.
    private Text firstElement = null;


    // Es wird ein neues Element in die Liste hinzugefügt.
    public void Append(string newValue)
    {
      Text newElement = new Text(newValue);
      Text currentElement = this.firstElement;

      // List ist noch leer. Wir setzten die das 1. Element gleich dem neuen Element.
      // Ansonsten würden wir bei unteren while Schleife einen NullReferenzException bekommen
      // da noch das firstElement noch null ist.
      if (currentElement == null)
      {
        this.firstElement = newElement;
        // Wir sind fertig hier
        return;
      }

      // Sobald das Next Property null ist haben wir das letzte Element in der Liste gefunden.

      while (currentElement.Next != null)
      {
        // Gehen ein Element in der Liste weiter.
        currentElement = currentElement.Next;
      }

      // Hängen das Element am Ende Kette dran
      currentElement.Next = newElement;
      newElement.Prev = currentElement;

    }

    // Gibt ein Array zurück welche alle Elemente der Liste enthält.
    public String[] GetArray()
    {
      // Liste ist leer
      if (this.firstElement == null)
      {
        return null;
      }

      // Nötig um die Größe für das Array zu bekommen.
      int count = 1;
      
      Text currentElement = this.firstElement;
       
      while (currentElement.Next != null)
      {
        count++;
        // Gehen ein Element in der Liste weiter.
        currentElement = currentElement.Next;
      }

      string[] array = new string[count];


      currentElement = this.firstElement;
      for (int i = 0; i < count; i++)
      {
        // Aktuelles element wird in die nächste freie Stelle des Array geschrieben.
        array[i] = currentElement.Value;
        // Gehen ein Element weiter in der Liste.
        currentElement = currentElement.Next;
      }

      return array;

    }

    // Entfernt den letzten Wert von aus der Liste und gibt ihn zurück.
    // Falls die Liste leer ist wird null zurück gegeben.
    public string Pop()
    {
      Text currentElement = this.firstElement;
      // Falls das erste element nicht existiert, ist die Liste leer.
      // Es wird deswegen null zurück gegeben.
      if (currentElement == null)
      {
        return null;
      }
      // Falls der Nachfolger des 1. element nicht exerziert, dann gibt es nur noch eine Element in der Liste.
      else if (currentElement.Next == null)
      {
        // Diese Logik verhindert eine NullReferenceException die beim unteren Code entstehen kann durch den Aufruf von previousElement. 
        string value = firstElement.Value;
        firstElement = null;
        return value;
      }


      // Falls currentElement.Next null ist, gibt es kein Nachfolger mehr, currentElement ist also das letztes Element in der Liste.
      while (currentElement.Next != null)
      {
        // Gehen ein Element in der Liste weiter.
        currentElement = currentElement.Next;
      }

      Text previousElement = currentElement.Prev;
      // Abtrennen des letzten Elements von der Liste.
      previousElement.Next = null;

      // Wert des letzten Element aus der Liste wird zurück gegeben.
      return currentElement.Value;
    }

    // Getter für die Anzahl aller Element der Liste
    public int Count
    {
      get
      {
        int count = 0;
        Text currentElement = this.firstElement;

        // Iteration durch die Liste
        while (currentElement != null)
        {
          // Aktualisierung der Anzahl aller Elemente in der Liste. 
          count++;
          // Gehen ein Element in der Liste weiter
          currentElement = currentElement.Next;
        }

        return count;
      }
    }

    // Indexer das einen Zugriff auf ein Element der Liste. Das hier ermöglicht deb gleiche Schreibweise für den Zugriff wie bei Arrays
    // Return null falls Indexer negative oder größer ist als die Anzahl aller Element in der Liste.
    // Return falls die Liste leer ist.
    public string this[int index]
    {
      get
      {
        Text currentElement = this.firstElement;
        int count = 0;

        // List ist leer oder nicht valide da negative
        if (firstElement == null || index < 0)
        {
          return null;
        }

        // Iteration durch die Liste
        while (currentElement != null)
        {
          // Stelle gefunden auf der sich der Index bezieht
          if (count == index)
          {
            return currentElement.Value;
          }
          // Update von der aktuellen Position. Gehen eine Element in der Lister weiter.           
          count++;
          currentElement = currentElement.Next;
        }

        return null;
      }
      set
      {
        Text currentElement = this.firstElement;
        int count = 0;

        // List ist leer
        if (firstElement == null || index < 0)
        {
          return;
        }

        // Iteration durch die Liste
        while (currentElement != null)
        {
          // Stelle gefunden auf der sich der Index bezieht
          if (count == index)
          {
            currentElement.Value = value;
          }

          // Update von der aktuellen Position. Gehen eine Element in der Lister weiter.     
          count++;
          currentElement = currentElement.Next;
        }

        return;
      }
    }

    // Entfernt ein Element an einer gewissen Stelle in der Liste. Diese Stelle ist durch den Parameter index gegeben.
    public void RemoveAt(int index)
    {



      Text currentElement = this.firstElement;
      int count = 0;

      // List ist leer oder index nicht valid da negative
      if (firstElement == null || index < 0)
      {
        return;
      }

      // Es gibt 4 Falle zu handhaben
      // List ist leer.
      // 1. Element soll entfernt werden.
      //  Es gibt nur das 1. Element.
      //  Es soll der Anfang entfernt werden, 1. Element. Es gibt minds 2 Elemente.
      // Letztes element soll entfernt werden
      // Ein Element soll entfernt werden zwischen Anfang und Ende

      // Iteration durch die Liste
      while (currentElement != null)
      {
        // Bestimmte stelle in der Liste gefunden.
        if (count == index)
        {
          // Merken von den Nachfolger
          Text nextElement = currentElement.Next;

          // index = 0, 0. Element in der Liste wurde adressiert.
          if (currentElement == this.firstElement)
          {
            // Es gibt nur ein element in der Liste
            if (nextElement == null)
            {
              this.firstElement = null;
            }
            else
            {
              // Es gibt mehr als ein Element in der Liste
              // Jedoch erfordert es seine eigene Logik das 1. Element aus der Liste
              // zu entfernen.
              nextElement.Prev = null;
              firstElement = nextElement;
            }         
          }
          else
          {
            // Liste ist nicht leer und es muss nicht das 1. Element aus der Liste entfernt werden.
            Text previousElement = currentElement.Prev;
            // Linke Seite der Liste vom zu dem entfernen Element wird abgetrennt
            previousElement.Next = null;

            // Falls false muss das letzte Element in der Liste entfernt werden.
            // Wir sind also fertig
            if (nextElement != null) 
            {
              // Linke  Seite der liste wird abgetrennt und der Nachfolger von dem zu entfernen Element wird an die linke Seite angehängt.
              previousElement.Next = nextElement;
              
              // Rechte Seite an der linken Seite der Liste dran gehängt.              
              nextElement.Prev = previousElement;
            }
          }

          // Element wurde entfernt
          return;
        }

        // Gehe ein Element weiter. 
        count++;        
        currentElement = currentElement.Next;
      }

      // Wird diese Stelle erreicht, war der index höher als der Index des letzten Elements
      // Es soll also nichts passieren
     
    }
  }
}
