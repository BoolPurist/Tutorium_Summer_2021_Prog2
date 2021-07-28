using System;
using System.Linq;

using Xunit;

using ClassLibrary_Solution_5_Tutorium_SS_2021;

namespace UnitTest_Solution_5_Tutorium_SS_2021
{
  public class UnitTest_Utility
  {
    [Theory]
    [MemberData(nameof(TestData_Sort))]
    public void Test_Sort(int[] initialSequence)
    {
      if (initialSequence == null)
      {
        Utility.Sort(initialSequence);
        Assert.Null(initialSequence);
      }
      else
      {
        int[] expectedArray = new int[initialSequence.Length];
        initialSequence.CopyTo(expectedArray, 0);
        Array.Sort<int>(expectedArray);

        Utility.Sort(initialSequence);
        bool isEqual = expectedArray.SequenceEqual<int>(initialSequence);
        Assert.True(isEqual);
      }

    }

    public static TheoryData<int[]> TestData_Sort
      => new TheoryData<int[]>()
      {
            {
              new int[] { 0, -2, 7 }
            },
            {
              new int[] { 0 }
            },
            {
              null
            },
            {
              new int[0]
            },
            {
              new int[] { -8, 5, -89, 0, 2, 4 }
            },
            {
              new int[] { -2, -90, -5, -89  }
            }
      };


  }
}
