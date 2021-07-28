using System;
using System.Collections.Generic;

using Solution_10_Tutorium_SS_2021_Library;

namespace Solution_10_Tutorium_SS_2021_Console
{
  class Program
  {
    static void Main(string[] args)
    {
      TestFilter();
    }

    static void TestStack()
    {
      var stack = new GenericStack<int>();

      stack.Push(2);
      stack.Push(4);
      stack.Push(8);

      Console.WriteLine($"stack.Empty = {stack.Empty}");

      Console.WriteLine($"stack.Pop() = {stack.Pop()}");
      Console.WriteLine($"stack.Pop() = {stack.Pop()}");
      Console.WriteLine($"stack.Pop() = {stack.Pop()}");

      Console.WriteLine($"stack.Empty = {stack.Empty}");
    }

    static void TestEnuramble()
    {
      var stack = new GenericStack<string>();

      stack.Push("Max");
      stack.Push("Graf Count");
      stack.Push("Lucky one");

      foreach (string name in stack)
      {
        Console.WriteLine($"Name: {name}");
      }
    }

    static void TestForEach()
    {
      var stack = new GenericStack<int>();
      stack.Push(2);
      stack.Push(4);
      ListUtility.ForEach<int>(stack, element => Console.WriteLine(element.ToString()));
      var list = new List<char>();
      list.AddRange(new char[] { 'H', 'e', 'l', 'l', 'o', ' ', 'W', 'o', 'r', 'l', 'd' });
      ListUtility.ForEach<char>(list, letter => Console.Write(letter));
      Console.WriteLine();

      var commaNumbers = new double[] { 2.0, 4.0, 1.0, 3.0 };
      double result = 0.0;
      ListUtility.ForEach<double>(commaNumbers, number => result += number);
      result /= Convert.ToDouble(commaNumbers.Length);
      Console.WriteLine($"result = {result}");

    }

    static void TestFilter()
    {
      var list = new List<string>(new string[] { "Auto", "Haus", "mit", "Arbeit", "Code", "Abs", "ab" });
      var result = ListUtility.Filter<string>(list, word => word.Length > 3);

      Console.Write("( ");
      foreach (string word in result)
      {
        Console.Write($"{word} ");
      }
      Console.WriteLine(")");

      var numberStack = new GenericStack<int>();
      numberStack.Push(2);
      numberStack.Push(5);
      numberStack.Push(12);
      numberStack.Push(73);
      numberStack.Push(440);
      var evenNumbers = ListUtility.Filter<int>(numberStack, number => number % 2 == 0);

      foreach (int evenNumber in evenNumbers)
      {
        Console.WriteLine($"Even number: {evenNumber}");        
      }
    }


  }
}
