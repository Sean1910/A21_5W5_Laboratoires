using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Appl_TestsUnitaires;

namespace Appl_TestsUnitaires_Tests_NU
{
  [TestFixture]
  public class E1_FizzBuzz_Tests_v2
  {
    [Test]
    [TestCase(15, "FizzBuzz")]
    [TestCase(3, "Fizz")]
    [TestCase(5, "Buzz")]
    [TestCase(7, "7")]
    public void GetOutPut_Div3OrAnd5_ReturnFizzBuzz(int response, string expectedResult)
    {
      // Arrange

      // Act
      var result = E1_FizzBuzz.GetOutput(response);

      // Assert

      Assert.That(result, Is.EqualTo(expectedResult));
    }
  }
}
