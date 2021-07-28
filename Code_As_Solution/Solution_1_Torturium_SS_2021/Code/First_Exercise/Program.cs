using System;

namespace First_Exercise
{
  partial class Program
  {
    static void Main(string[] args)
    {
      TestGetUniqueValues();
    }

    private static void TestCustomClamp()
    {
      Console.WriteLine($"Math.CustomClamp(2.0, 0.0, 4.0) = {CustomClamp(2.0, 0.0, 4.0)}");
      Console.WriteLine($"Math.CustomClamp(-2.0, 0.0, 4.0) = {CustomClamp(-2.0, 0.0, 4.0)}");
      Console.WriteLine($"Math.CustomClamp(900.0, 1.0, 800.0) = {CustomClamp(900.0, 1.0, 800.0)}");
    }

    private static void TestGetAverage()
    {
      double[] numbers = new double[] { 2.0, 2.0, 8.0};
      Console.WriteLine($"GetAverage(numbers) = {GetAverage(numbers)}");
      numbers = new double[] { 5, 2.5 };
      Console.WriteLine($"GetAverage(numbers) = {GetAverage(numbers)}");
    }

    private static void TestIsUnique()
    {
      string[] names = new string[] { "Max", "Flo", "Alf", "Flo" };
      Console.WriteLine($"IsUnique(names, \"Max\") = {IsUnique(names, "Max")}");
      Console.WriteLine($"IsUnique(names, \"Flo\") = {IsUnique(names, "Flo")}");
      Console.WriteLine($"IsUnique(names, \"Anna\") = {IsUnique(names, "Anna")}");
    }

    private static void TestGetUniqueValues()
    {
      string[] names = new string[] { "Max", "Flo", "Alf", "Flo", "Alfred" };
      string[] allUniques = GetUniqueValues(names);

      Console.WriteLine("List of all unique value:");

      foreach (string name in allUniques)
      {
        Console.WriteLine(name);
      }
    }

    private static void TestGetValuesWithCount()
    {
      string[] names = new string[] { "Max", "Flo", "Alf", "Flo", "Alfred", "Alfred", "Alfred" };
      ValueWithCount[] valuesWithCount = GetValuesWithCount(names);

      Console.WriteLine("List of all values with count:");

      foreach (ValueWithCount valueAndCount in valuesWithCount)
      {
        Console.WriteLine($"Value: {valueAndCount.Value}, Count: {valueAndCount.Count}");
      }
    }

    private static void TestChatUser()
    {
      ChatUser happy = new ChatUser("HappyDude42");
      ChatUser meier = new ChatUser("Meier");
      happy.TypeMessage("Hi everybody !");
      meier.TypeMessage("Hihi");
      happy.TypeMessage("How are you doing ?");
      Console.WriteLine(ChatUser.GetAllMessages());
    }


  }
}
