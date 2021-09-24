using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appl_TestsUnitaires
{
  public class E2_EvenNumbers
  {
    public IEnumerable<int> GetEvenNumbers(int MaxValue)
    {
      for (var i = 0; i <= MaxValue; i++)
        if (i % 2 == 0)
          yield return i;
    }
  }
}
