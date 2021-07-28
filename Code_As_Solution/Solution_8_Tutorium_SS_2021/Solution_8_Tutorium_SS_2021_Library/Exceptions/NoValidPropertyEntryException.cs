using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_8_Tutorium_SS_2021_Library
{
  public class NoValidPropertyEntryException : Exception
  {
    public string PropertyName { get; private set; }

    public string PropertyValue { get; private set; }

    public NoValidPropertyEntryException(string message, string propertyName = null, string propertyValue = null) : base(message)
    {
      this.PropertyName = propertyName;
      this.PropertyValue = propertyValue;
    }

    
  }
}
