using System;
using System.Linq;

using Xunit;

using ClassLibrary_Solution_5_Tutorium_SS_2021;

namespace UnitTest_Solution_5_Tutorium_SS_2021
{
  public class UnitTest_NumberQueue
  {

    #region Tests
    [Theory]
    [MemberData(nameof(TestData_Queue_Enqueue_Dequeue))]
    public void Test_Queue_Enqueue_Dequeue(int[] inputSequence)
    {
      var queue = new NumberQueue();

      var outputSequnece = new int[inputSequence.Length];

      foreach (int number in inputSequence)
      {
        queue.Enqueue(number);
      }

      for (int outputIndex = 0; outputIndex < outputSequnece.Length; outputIndex++)
      {
        outputSequnece[outputIndex] = queue.Dequeue();
      }

      Assert.True(queue.Empty);
      bool isEqual = inputSequence.SequenceEqual<int>(outputSequnece);
      Assert.True(isEqual);
    }

    [Theory]
    [MemberData(nameof(TestData_Queue_Count))]
    public void Test_Queue_Count(int[] valuesToInsert, int expectedCount)
    {
      var queue = new NumberQueue();

      foreach (int number in valuesToInsert)
      {
        queue.Enqueue(number);
      }

      int actualCount = queue.Count;
      Assert.Equal(expectedCount, actualCount);
    }

    [Theory]
    [MemberData(nameof(TestData_Queue_ToNumberArray))]
    public void Test_Queue_ToNumberArray(int[] valuesToBeInserted)
    {
      var queue = new NumberQueue();
      foreach (int number in valuesToBeInserted)
      {
        queue.Enqueue(number);
      }

      int[] actualOutputArray = queue.ToNumberArray();

      valuesToBeInserted.SequenceEqual<int>(actualOutputArray);
    }

    [Fact]
    public void Test_Queue_Dequeue_ShouldThrowIfListEmpty()
    {
      var emptyQueue = new NumberQueue();
      Action causingException = () =>
      {
        emptyQueue.Dequeue();
      };

      Assert.Throws<Exception>(causingException);

      causingException = () =>
      {
        emptyQueue.Enqueue(2);
        emptyQueue.Dequeue();
        emptyQueue.Dequeue();
      };

      Assert.Throws<Exception>(causingException);
    }

    [Fact]
    public void Test_Queue_Empty()
    {
      var queue = new NumberQueue();
      Assert.True(queue.Empty);
      queue.Enqueue(2);
      Assert.False(queue.Empty);
      queue.Dequeue();
      Assert.True(queue.Empty);
    }
    
    #endregion

    #region TestData
    public static TheoryData<int[]> TestData_Queue_Enqueue_Dequeue
      => new TheoryData<int[]>()
      {
            {
              new int[] { 0, 1, 2}
            },
            {
              new int[] { 2, 4, -9, 8}
            },
            {
              new int[] { 1 }
            }
      };

    public static TheoryData<int[], int> TestData_Queue_Count
     => new TheoryData<int[], int>()
     {
       {
         new int[] { 2, 4 }, 2
       },
       {
         new int[] { 0 }, 1
       },
       {
         new int[0] , 0
       },
       {
         new int[] { 2, 4, 6, 6 }, 4
       },
       {
         new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, }, 10
       }
     };

    public static TheoryData<int[]> TestData_Queue_ToNumberArray
      => new TheoryData<int[]>()
      {
        {
          new int[] { 2, 4, 5 }
        },
        {
          new int[] { 1, 3, 5, 5, 8 }
        },
        {
          new int[] { 1 }
        },
        {
          new int[0]
        },
      };

    #endregion 
  }
}
