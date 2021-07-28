using System;
using System.Collections;
using System.Collections.Generic;

namespace Solution_10_Tutorium_SS_2021_Library
{
  public class GenericStack<T> : IEnumerable<T>
  {
    private Element _tail;

    public bool Empty => _tail == null;

    public void Push(T value)
    {
      if (_tail == null)
      {
        _tail = new Element(value);
      }
      else
      {
        Element newTail = new Element(value);
        newTail.Previous = _tail;
        _tail = newTail;
      }
    }

    public T Pop()
    {
      if (_tail == null)
      {
        throw new Exception("Stack is empty");
      }
      else
      {
        Element newTail = _tail.Previous;
        T valule = _tail.Value;
        _tail = newTail;
        return valule;
      }
    }

    public IEnumerator<T> GetEnumerator()
    {
      return Generator(); 
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return this.GetEnumerator();
    }

    private IEnumerator<T> Generator()
    {
      Element currentElement = _tail;
      while (currentElement != null) 
      {
        yield return currentElement.Value;
        currentElement = currentElement.Previous;
        
      }
    }
    

    private class Element
    {
      public T Value { get; set; }

      public Element Previous { get; set; }

      public Element(T value)
      {
        Value = value;
      }
    }
  }
}
