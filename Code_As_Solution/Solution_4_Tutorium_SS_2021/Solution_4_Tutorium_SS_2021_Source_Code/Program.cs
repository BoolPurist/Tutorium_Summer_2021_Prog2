using System;

namespace Solution_4_Tutorium_SS_2021
{
  class Program
  {
    static void Main(string[] args)
    {
      
    }

    static void PrintList(TextCollection collection) 
    {
      string[] array = collection.GetArray();

      if (array != null)
      {
        int count = 0;
        foreach (string element in collection.GetArray())
        {
          Console.WriteLine($"Element {count}: {element}");
          count++;
        }
        Console.WriteLine(new String('@', 30));
      }
      else
      {
        Console.WriteLine("List is empty");
      }
    }

    static void TestAppendAndGetArray() 
    {
      Console.WriteLine("Testing Appending");
      TextCollection collection = new TextCollection();
      collection.Append("0");
      collection.Append("1");
      collection.Append("2");

      PrintList(collection);
    }



    static void TestingPoping()
    {
      Console.WriteLine("Testing Pop");
      TextCollection collection = new TextCollection();
      Console.WriteLine($"collection.Pop() = {collection.Pop()}");
      PrintList(collection);

      collection.Append("0");
      collection.Append("1");
      collection.Append("2");

      Console.WriteLine($"collection.Pop() = {collection.Pop()}");
      PrintList(collection);

      Console.WriteLine($"collection.Pop() = {collection.Pop()}");
      Console.WriteLine($"collection.Pop() = {collection.Pop()}");
      PrintList(collection);

      Console.WriteLine($"collection.Pop() = {collection.Pop()}");
      PrintList(collection);
    }

    static void TestingCount()
    {
      Console.WriteLine("Testing Count");
      TextCollection collection = new TextCollection();
      Console.WriteLine($"collection.Count = {collection.Count}");
      collection.Append("0");
      collection.Append("1");
      collection.Append("2");
      Console.WriteLine($"collection.Count = {collection.Count}");
      collection.Pop();
      Console.WriteLine($"collection.Count = {collection.Count}");
    }

    static void TestIndexer()
    {
      Console.WriteLine("Testing Indexer");
      TextCollection collection = new TextCollection();

      collection.Append("0");
      collection.Append("1");
      collection.Append("2");
     
      Console.WriteLine($"collection[-2] = {collection[-2]}");
      Console.WriteLine($"collection[0] = {collection[0]}");
      Console.WriteLine($"collection[1] = {collection[1]}");
      Console.WriteLine($"collection[2] = {collection[2]}");
      Console.WriteLine($"collection[3] = {collection[3]}");

      collection[-1] = "-10";
      collection[1] = "-1";
      collection[3] = "10";

      PrintList(collection);
    }

    static void TestRemoveAt()
    {
      Console.WriteLine("Testing RemoveAt");
      TextCollection collection = new TextCollection();

      collection.Append("0");
      collection.Append("1");
      collection.Append("2");

      collection.RemoveAt(-1);
      collection.RemoveAt(-3);

      PrintList(collection);

      collection.RemoveAt(1);

      PrintList(collection);

      collection.RemoveAt(0);

      PrintList(collection);

      collection.RemoveAt(0);
      collection.RemoveAt(0);

      PrintList(collection);
    }
  }
}
