using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_8_Tutorium_SS_2021_Library
{
  public class GameEntity : ISaveable, IEquatable<GameEntity>
  {
    public int HP { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int Level { get; set; }

    public int Damage { get; set; }

    public int Defense { get; set; }

    public GameEntity(int hp, int x, int y, int level,int Damage, int defense) 
    {
      this.HP = hp;
      this.X = x;
      this.Y = y;
      this.Level = level;
      this.Damage = Damage;
      this.Defense = defense;
    }

    public GameEntity() : this(0, 0, 0, 0, 0, 0) { }

    public string Save()
    {
      string result = "";

      result += $"{nameof(HP)}={HP}\n";
      result += $"{nameof(X)}={X}\n";
      result += $"{nameof(Y)}={Y}\n";
      result += $"{nameof(Level)}={Level}\n";
      result += $"{nameof(Damage)}={Damage}\n";
      result += $"{nameof(Defense)}={Defense}";

      return result;
    }

    public override string ToString() => $"HP: {this.HP}, X: {this.X}, Y: {this.Y}, Level: {this.Level}, Damage: {this.Damage}, Defense: {this.Defense}";

    public bool Equals(GameEntity other)
    {
      return this.HP == other.HP &&
      this.X == other.X &&
      this.Y == other.Y &&
      this.Level == other.Level &&
      this.Damage == other.Damage &&
      this.Defense == other.Defense; 
    }

    public void Load(string save)
    {
      foreach (string row in save.Split("\n"))
      {
        string[] columns = row.Split("=");


        if (columns.Length != 2)
        {
          throw new NoValidPropertyEntryException("Entry for property is not in the following format (name=value)");
        }

        string propertyName = columns[0];
        string propertyValue = columns[1];

        switch (propertyName)
        {
          case nameof(HP):
            try
            {
              this.HP = Convert.ToInt32(propertyValue);
            }
            catch (FormatException)
            {
              throw new NoValidPropertyEntryException($"For Property {propertyName} the value is not convertible to an integer", propertyName, propertyValue);
            }
            break;
          case nameof(X):
            try
            {
              this.X = Convert.ToInt32(propertyValue);
            }
            catch (FormatException)
            {
              throw new NoValidPropertyEntryException($"For Property {propertyName} the value is not convertible to an integer", propertyName, propertyValue);
            }
            break;
          case nameof(Y):
            try
            {
              this.Y = Convert.ToInt32(propertyValue);
            }
            catch (FormatException)
            {
              throw new NoValidPropertyEntryException($"For Property {propertyName} the value is not convertible to an integer", propertyName, propertyValue);
            }
            break;
          case nameof(Level):
            try
            {
              this.Level = Convert.ToInt32(propertyValue);
            }
            catch (FormatException)
            {
              throw new NoValidPropertyEntryException($"For Property {propertyName} the value is not convertible to an integer", propertyName, propertyValue);
            }
            break;
          case nameof(Damage):
            try
            {
              this.Damage = Convert.ToInt32(propertyValue);
            }
            catch (FormatException)
            {
              throw new NoValidPropertyEntryException($"For Property {propertyName} the value is not convertible to an integer", propertyName, propertyValue);
            }
            break;
          case nameof(Defense):
            try
            {
              this.Defense = Convert.ToInt32(propertyValue);
            }
            catch (FormatException)
            {
              throw new NoValidPropertyEntryException($"For Property {propertyName} the value is not convertible to an integer", propertyName, propertyValue);
            }
            break;
          default:
            throw new NoValidPropertyEntryException($"{propertyName} as property name is not valid ", propertyName);
        }
      }
    }
  }
}
