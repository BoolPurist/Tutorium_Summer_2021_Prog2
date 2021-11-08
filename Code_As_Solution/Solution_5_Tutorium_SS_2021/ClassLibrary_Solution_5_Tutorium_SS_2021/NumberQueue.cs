using System;


namespace ClassLibrary_Solution_5_Tutorium_SS_2021
{
  public class NumberQueue
  {
    // Start der queue, also das 1. Element
    private Element Head = null;
    // Ende der queue, also das letzte Element
    private Element Tail = null;

    // Anzahl von Elementen der Queue.
    private int _count = 0;
    // Getter von _count
    public int Count => _count;
        
    // True wenn die Queue kein Element mehr hat
    public bool Empty => Head == null;

    // Fügt einen neuen Wert in die Queue hinzu.
    // Neuer Wert kommt an das Ender der Queue.
    public void Enqueue(int number)
    {
      // Das neu hinzufügende Element
      Element newElement = new Element(number);

      // Anzahl von Element in der Queue ist um 1 gestiegen.
      _count++;
      // Queue hat kein Element
      if (Head == null)
      {        
        Head = newElement;
        Tail = newElement;
        return;
      }

      // Queue hat schon mindestens ein ELement vor dem Hinzufügen des neuen Elements
      Tail.Next = newElement;
      Tail = newElement;
    }

    // Entfernt das erste Element aus der Queue
    public int Dequeue()
    {
      // Queue hat kein Element mehr
      if (Head == null)
      {
        throw new Exception();
      }

      // Nachfolger des 1. Element in der Queue
      Element newHead = Head.Next;

      // Anzahl der Elemente in der Queue ist um ein Element gesunken.
      _count--;

      // Queue hat nur eine Element
      if (newHead == null)
      {
        int onlyValue = Head.Value;
        Head = null;
        Tail = null;
        return onlyValue;
      }
      else
      {
        // Queue hat mehr als ein Element
        int oldHaedValue = Head.Value;
        // Nachfolger von Head wird der neue Head.
        Head = newHead;
        return oldHaedValue;
      }
    }

    // Gibt ein Array zurück, das genau alle Elemente im Binären Baum enthält
    public int[] ToNumberArray()
    {
      Element currentElement = Head;
      int arrayLength = this._count;

      var array = new int[arrayLength];

      // Kopieren aller Werte aus der Queue in das array, welches zurück gegeben wird.
      for (int arrayIndex = 0; arrayIndex < arrayLength; arrayIndex++)
      {
        array[arrayIndex] = currentElement.Value;
        currentElement = currentElement.Next;
      }

      return array;
    }

    // Stellt ein Element in der Queue dar.
    private class Element
    {      
      public int Value { get; set; }
      // Jedes Element in der Queue muss sich nur seinen Nachfolger merken.
      public Element Next { get; set; }

      public Element(int value)
      {
        this.Value = value;
      }
    }
  }
}
