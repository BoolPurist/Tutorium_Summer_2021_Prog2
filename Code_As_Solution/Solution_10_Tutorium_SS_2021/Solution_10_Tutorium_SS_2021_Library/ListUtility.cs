using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_10_Tutorium_SS_2021_Library
{
  public static class ListUtility
  {
    public delegate void ActionOnOneElement<T>(T value);

    public delegate bool CheckRoutine<T>(T value);

    public static void ForEach<T>(IEnumerable<T> sequence, ActionOnOneElement<T> action)
    {
      foreach (T element in sequence)
      {
        action(element);
      }
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> sequence, CheckRoutine<T> check)
    {
      var stack = new GenericStack<T>();

      foreach (T value in sequence)
      {
        if (check(value))
        {
          stack.Push(value);
        }
      }

      return stack;
    }
     
  }
}
