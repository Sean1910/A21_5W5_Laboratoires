using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appl_TestsUnitaires_Tests_MS
{
  [TestClass]
  public class FizzBuzz_Tests_v1
  {
    // Arrange

    // Act
    var result = FizzBuzz.GetOutput(response);

    // Assert

    Assert.That(result, Is.EqualTo(expectedResult));
  }
}
