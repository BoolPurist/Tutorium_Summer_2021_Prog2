using System;
using System.Linq;

using Xunit;

using ClassLibrary_Solution_6_Tutorium_SS_2021;

namespace UnitTest_Solution_6_Torturium_SS_2021
{
  public class UnitTest_NumberBinaryTree
  {

    #region Tests

    [Theory]
    [MemberData(nameof(TestData_InsertReturnValues))]
    public void Test_InsertAndReturnValues(int[] initialSequence)
    {
      int[] expectedReturnValues = new int[initialSequence.Length];
      initialSequence.CopyTo(expectedReturnValues, 0);
      Array.Sort<int>(expectedReturnValues);

      var binaryTree = new NumberBinaryTree();


      foreach (int number in initialSequence)
      {
        binaryTree.Insert(number);
      }

      int[] actualReturnValues = binaryTree.ReturnValues();

      bool isEqual = expectedReturnValues.SequenceEqual<int>(actualReturnValues);
      Assert.True(isEqual);
    }

    [Theory]
    [MemberData(nameof(TestData_Count))]
    public void Test_NumberBinaryTree_Count(int[] valuesToBeInserted, int expectedCount)
    {
      var queue = new NumberBinaryTree();
      foreach (int number in valuesToBeInserted)
      {
        queue.Insert(number);
      }

      int actualCount = queue.Count;

      Assert.Equal<int>(expectedCount, actualCount);
    }

    [Theory]
    [MemberData(nameof(TestData_Maximum))]
    public void Test_NumberBinaryTree_Maximum(int[] valuesToBeInserted, int expectedMaximum)
    {
      var queue = new NumberBinaryTree();
      foreach (int number in valuesToBeInserted)
      {
        queue.Insert(number);
      }

      int actualMaximum = queue.Maximum;

      Assert.Equal<int>(expectedMaximum, actualMaximum);
    }

    [Theory]
    [MemberData(nameof(TestData_Minimum))]
    public void Test_NumberBinaryTree_Minimum(int[] valuesToBeInserted, int expectedMinimum)
    {
      var queue = new NumberBinaryTree();
      foreach (int number in valuesToBeInserted)
      {
        queue.Insert(number);
      }

      int actualMinimum = queue.Minimum;

      Assert.Equal<int>(expectedMinimum, actualMinimum);
    }

    #endregion

    #region Data

    public static TheoryData<int[]> TestData_InsertReturnValues
      => new TheoryData<int[]>()
      {
            {
              new int[] { 0, -2, 7 }           
            },
            {
              new int[] { 2, 8, 0, -2, 7 }
            },
            {
              new int[] { 2 }
            }
      };


    // 1. Type int[] list of elements to insert in binary tree.
    // 2. Type int expected count of binary tree.
    public static TheoryData<int[], int> TestData_Count
      => new TheoryData<int[], int>()
      {
        {
          new int[] { 2, 4, 5 }, 3
        },
        {
          new int[] { 10 }, 1
        },
        {
          new int[0], 0
        },
        {
          new int[] { 2, 4, 5, -8, -5 }, 5
        }
      };

    // 1. Type int[] Values to be inserted in binary tree.
    // 2. Type int expected returned highest value
    public static TheoryData<int[], int> TestData_Maximum
      => new TheoryData<int[], int>()
      {
        {
            new int[] { 2, 4, 8, -9 } , 8
        },
        {
            new int[] { 45 } , 45
        },
        {
            new int[] { -45, -180 } , -45
        },
        {
            new int[] { 45, 0, 200 } , 200
        },
      };

    // 1. Type int[] Values to be inserted in binary tree.
    // 2. Type int expected returned highest value
    public static TheoryData<int[], int> TestData_Minimum
      => new TheoryData<int[], int>()
      {
        {
            new int[] { 2, 4, 8, -9 } , -9
        },
        {
            new int[] { 45 } , 45
        },
        {
            new int[] { -45, -180 } , -180
        },
        {
            new int[] { 45, 0, 200 } , 0
        },
      };

    #endregion
  }
}
