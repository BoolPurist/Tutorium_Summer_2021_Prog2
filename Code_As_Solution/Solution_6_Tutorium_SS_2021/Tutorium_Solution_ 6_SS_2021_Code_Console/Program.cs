using System;

using ClassLibrary_Solution_6_Tutorium_SS_2021;

namespace Tutorium_Solution__6_SS_2021_Code_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      
    }

    static void TestInsertAndGetArray()
    {
      var numberQueue = new NumberBinaryTree();
      Console.WriteLine(GetStringArray(numberQueue.ReturnValues()));
      numberQueue.Insert(2);
      Console.WriteLine(GetStringArray(numberQueue.ReturnValues()));
      numberQueue.Insert(5);
      numberQueue.Insert(-8);
      Console.WriteLine(GetStringArray(numberQueue.ReturnValues()));
      numberQueue.Insert(12);
      numberQueue.Insert(222);
      numberQueue.Insert(-222);
      Console.WriteLine(GetStringArray(numberQueue.ReturnValues()));
    }

    static void TestBinaryCount()
    {
      var numberQueue = new NumberBinaryTree();
      Console.WriteLine($"numberQueue.Count = {numberQueue.Count}");
      numberQueue.Insert(2);
      Console.WriteLine($"numberQueue.Count = {numberQueue.Count}");
      numberQueue.Insert(4);
      numberQueue.Insert(8);
      numberQueue.Insert(-20);
      numberQueue.Insert(0);
      Console.WriteLine($"numberQueue.Count = {numberQueue.Count}");
    }

    static void TestMininum()
    {
      var numberQueue = new NumberBinaryTree();
      numberQueue.Insert(2);
      Console.WriteLine($"numberQueue.Minimum = {numberQueue.Minimum}");
      numberQueue.Insert(4);
      Console.WriteLine($"numberQueue.Minimum = {numberQueue.Minimum}");
      numberQueue.Insert(-4);
      numberQueue.Insert(-84);
      Console.WriteLine($"numberQueue.Minimum = {numberQueue.Minimum}");
    }

    static void TestMaximum()
    {
      var numberQueue = new NumberBinaryTree();
      numberQueue.Insert(2);
      Console.WriteLine($"numberQueue.Maximum = {numberQueue.Maximum}");
      numberQueue.Insert(4);
      Console.WriteLine($"numberQueue.Maximum = {numberQueue.Maximum}");
      numberQueue.Insert(-4);
      numberQueue.Insert(-84);
      Console.WriteLine($"numberQueue.Maximum = {numberQueue.Maximum}");
      numberQueue.Insert(200);
      Console.WriteLine($"numberQueue.Maximum = {numberQueue.Maximum}");
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
