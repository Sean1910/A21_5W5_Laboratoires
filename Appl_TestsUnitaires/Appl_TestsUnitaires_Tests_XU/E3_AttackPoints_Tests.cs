using Appl_TestsUnitaires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Appl_TestsUnitaires_Tests_XU
{
  public class E3_AttackPoints_tests
  {
    [Theory]
  [InlineData(0, 0)]
  [InlineData(6, 0)]
  [InlineData(19, 0)]
  [InlineData(20, 0)]
  [InlineData(21, 0)]
  [InlineData(25, 1)]
  [InlineData(30, 2)]
  [InlineData(85, 13)]
  public void AttackPointsCalculator_ReturnPoints(int nbrAttack, int expectedResult)
  {
      // Arrange
     E3_AttackPointsCalculator _zombieAttack = new E3_AttackPointsCalculator();

      //Act
      var result = _zombieAttack.CalculateAttackPoints(nbrAttack);

      // Assert
      Assert.Equal(expectedResult, result);
    }


    [Theory]
    [InlineData(-1)]
    [InlineData(205)]
    public void AttackPointsCalculator_ThrowArgumentOutOfRangeException(int nbrAttack)
    {
      // Arrange
      E3_AttackPointsCalculator _zombieAttack = new E3_AttackPointsCalculator();

      // Act et Assert
      Assert.Throws<ArgumentOutOfRangeException>(() => _zombieAttack.CalculateAttackPoints(nbrAttack));

    }
  }
}
