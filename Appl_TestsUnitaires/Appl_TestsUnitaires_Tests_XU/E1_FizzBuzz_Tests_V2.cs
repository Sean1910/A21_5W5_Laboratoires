using Appl_TestsUnitaires;
using System;
using Xunit;

namespace Appl_TestsUnitaires_Tests_XU
{
  public class E1_FizzBuzz_Tests_V2
  {
    [Theory]
    [InlineData(15, "FizzBuzz")]
    [InlineData(6, "Fizz")]
    [InlineData(10, "Buzz")]
    [InlineData(4, "4")]
    public void GetOutPut_Div3OrAnd5_ReturnFizzBuzz(int divisable, string expected)
    {
      // Arrange

      // Act
      var result = E1_FizzBuzz.GetOutput(divisable);
      // Assert
      Assert.Equal(result, expected);
    }
  }

}
