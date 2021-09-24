using System;

namespace Appl_TestsUnitaires
{
  public class E3_AttackPointsCalculator
  {
    private const int NbrAttackMin = 20;
    private const int NbrAttackMax = 200;

    public int CalculateAttackPoints(int nbrAttacks)
    {
      if (nbrAttacks < 0 || nbrAttacks > NbrAttackMax)
        throw new ArgumentOutOfRangeException();

      if (nbrAttacks <= NbrAttackMin) return 0;

      const int AttackPerPoint = 5;
      var AttackPoints = (nbrAttacks - NbrAttackMin) / AttackPerPoint;

      return AttackPoints;
    }
  }
}
