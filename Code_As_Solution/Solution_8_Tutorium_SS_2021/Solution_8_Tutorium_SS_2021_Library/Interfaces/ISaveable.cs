using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_8_Tutorium_SS_2021_Library
{
  public interface ISaveable
  {
    string Save();

    void Load(string save);
  }
}
