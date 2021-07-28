using System;

using ClassLibrary_Solution_5_Tutorium_SS_2021;



namespace Console_Solution_5_Tutorium_SS_2021
{
  class Program
  {
    static void Main(string[] args)
    {

    }

    static void TestGetStringArray()
    {
      int[] array = new int[] { 2, 4, 5};
      Console.WriteLine(GetStringArray(array));
      array = new int[0];
      Console.WriteLine(GetStringArray(array));
    }

    static void TestSort()
    {
      var array = new int[] { 0, -2, 7 };
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
      array = new int[] { -2, -90, -5, -89 };
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
      array = new int[] { -8, 5, -89, 0, 2, 4 };
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
      array = new int[] { 0 };
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
      array = new int[0];
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
      array = null;
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
      array = new int[] { -8, 5, 5, 0, 2, 4 };
      Utility.Sort(array);
      Console.WriteLine(GetStringArray(array));
    }

    static void TestNumberQueueInsertAndToNumberArray()
    {
      var queue = new NumberQueue();
      Console.WriteLine(GetStringArray(queue.ToNumberArray()));
      queue.Enqueue(5);
      queue.Enqueue(10);
      Console.WriteLine(GetStringArray(queue.ToNumberArray()));
      queue.Enqueue(-5);
      queue.Enqueue(-10);
      queue.Enqueue(20);
      Console.WriteLine(GetStringArray(queue.ToNumberArray()));
    }

    static void TestNumberQueueDequeue()
    {
      var queue = new NumberQueue();
      queue.Enqueue(2);
      queue.Dequeue();
      Console.WriteLine(GetStringArray(queue.ToNumberArray()));
      queue.Enqueue(2);
      queue.Enqueue(8);
      queue.Dequeue();
      Console.WriteLine(GetStringArray(queue.ToNumberArray()));
    }

    static void TestEmpty()
    {
      var queue = new NumberQueue();
      Console.WriteLine($"queue.Empty = {queue.Empty}");
      queue.Enqueue(2);
      Console.WriteLine($"queue.Empty = {queue.Empty}");
      queue.Dequeue();
      Console.WriteLine($"queue.Empty = {queue.Empty}");
    }

    static void TestNumberQueueCount()
    {
      var queue = new NumberQueue();
      queue.Enqueue(2);
      queue.Dequeue();
      Console.WriteLine($"queue.Count = {queue.Count}");
      queue.Enqueue(2);
      queue.Enqueue(8);
      queue.Dequeue();
      Console.WriteLine($"queue.Count = {queue.Count}");
      queue.Enqueue(8);
      queue.Enqueue(8);
      queue.Enqueue(8);
      Console.WriteLine($"queue.Count = {queue.Count}");
    }

    static string GetStringArray(int[] array)
    {
      if (array == null || array.Length == 0)
      {
        return "[]";
      }
      else
      {
        string endText = "[ ";

        foreach (int number in array)
        {
          endText += $"{number} ";
        }

        return endText + "]";
      }
    }
  }
}
