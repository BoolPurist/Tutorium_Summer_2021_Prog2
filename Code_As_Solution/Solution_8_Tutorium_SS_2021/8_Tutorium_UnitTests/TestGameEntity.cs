using System;

using Xunit;

using Solution_8_Tutorium_SS_2021_Library;

namespace Solution_8_Tutorium_UnitTests
{
  public class TestGameEntity
  {
    [Theory]
    [MemberData(nameof(TestData_Save))]
    public void Test_Save(int actualHp, int actualX, int actualY,int actualLevel, int actualDamage, int actualDefense)
    {
      string expectedSaveString = ConcateSaveString(actualHp, actualX, actualY, actualLevel, actualDamage, actualDefense);
      var actualEntity = new GameEntity(actualHp, actualX, actualY, actualLevel, actualDamage, actualDefense);
      string actualSaveString = actualEntity.Save();

      Assert.Equal(expectedSaveString, actualSaveString);
    }

    [Theory]
    [MemberData(nameof(TestData_Equals))]
    public void Test_Equals(GameEntity one, GameEntity another,bool expectedReturnValue)
    {
      bool actualReturnValue = one.Equals(another);
      Assert.Equal(expectedReturnValue, actualReturnValue);
    }

    [Theory]
    [MemberData(nameof(TestData_Load))]
    public void Test_Load(int actualHp, int actualX, int actualY, int actualLevel, int actualDamage, int actualDefense)
    {
      string expectedSaveString = ConcateSaveString(actualHp, actualX, actualY, actualLevel, actualDamage, actualDefense);
      var expectedEntity = new GameEntity(actualHp, actualX, actualY, actualLevel, actualDamage, actualDefense);
      
      var actualEntity = new GameEntity();
      actualEntity.Load(expectedSaveString);
      Assert.True(expectedEntity.Equals(actualEntity));
    }

    [Theory]
    [MemberData(nameof(TestData_ThrowsLoad))]
    public void Test_ThrowLoad(string invalidString)
    {
      Action invalidLoading = () => 
      {       
        var entity = new GameEntity();
        entity.Load(invalidString);
      };

      Assert.Throws<NoValidPropertyEntryException>(invalidLoading);

    }


    public static TheoryData<int, int, int, int, int, int> TestData_Save
    {
      get
      {
        return new TheoryData<int, int, int, int, int, int>()
        {
          {
            100,
            10,
            0,
            5,
            12,
            6            
          },
          {
            200,
            -45,
            45,
            10,
            2,
            0
          }
        };
      }
    }


    private static string ConcateSaveString(int HP, int X, int Y,int Level, int Damage, int Defense)
    {
      return
        $"{nameof(HP)}={HP}\n" +
        $"{nameof(X)}={X}\n" +
        $"{nameof(Y)}={Y}\n" +
        $"{nameof(Level)}={Level}\n" +
        $"{nameof(Damage)}={Damage}\n" +
        $"{nameof(Defense)}={Defense}";
    }

    public static TheoryData<int, int, int, int, int, int> TestData_Load
    {
      get
      {
        return new TheoryData<int, int, int, int, int, int>()
          {
            {
              0,
              0,
              0,
              0,
              0,
              0
            }
          };
      }
    }

    public static TheoryData<GameEntity, GameEntity, bool> TestData_Equals
    {
      get
      {
        return new TheoryData<GameEntity, GameEntity, bool>()
        {
          {
            new GameEntity(2, 4, 5, 5, 0, 3),
            new GameEntity(2, 4, 5, 5, 0, 3),
            true
          },
          {
            new GameEntity(2, 0, 5, 5, 0, 3),
            new GameEntity(2, 4, 5, 5, 0, 3),
            false
          },
          {
            new GameEntity(0, 0, 0, 0, 0, 0),
            new GameEntity(0, 0, 0, 0, 0, 0),
            true
          },
          {
            new GameEntity(2, 5, 0, 5, 0, 3),
            new GameEntity(2, 0, 5, 5, 0, 3),
            false
          },
        };
      }
    }
  
    public static TheoryData<string> TestData_ThrowsLoad
    {
      get
      {
        return new TheoryData<string>()
        {
          {
            "HP=2\n" +
            "X=2\n" +
            "Y=2\n" +
            "Attack=4\n" +
            "Damage=\n" +
            "Defense="            
          },
          {
            "HP=a\n" +
            "X=2\n" +
            "Y=2\n" +
            "Level=4\n" +
            "Damage=5\n" +
            "Defense=5"            
          },
          {
            "HP=2\n" +
            "X=2\n" +
            "Y=2\n" +
            "Level=4\n" +
            "Damage=5\n" +
            "Defense="
          }
        };
      }
    }
  }
}
