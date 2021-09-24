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
  public class E2_EvenNumbersTests
  {
    private E2_EvenNumbers _evenNumbers;

    [SetUp]
    public void SetUp()
    {
      _evenNumbers = new E2_EvenNumbers();
    }

    [Test]
    public void GetEvenNumbers_LimitIsGreaterThanZero_ReturnNumberUpToLimit()
    {
      // Arrange

      // Act
      var result = _evenNumbers.GetEvenNumbers(6);

      // Assert
      // valide seulement si contenu. trop general
      Assert.That(result, Is.Not.Empty);

      // plus specifique mais ne valide pas le contenu
      Assert.That(result.Count(), Is.EqualTo(4));

      // Plus specifique et valide le contenu  methode longue
      Assert.That(result, Does.Contain(0));
      Assert.That(result, Does.Contain(2));
      Assert.That(result, Does.Contain(4));
      Assert.That(result, Does.Contain(6));

      // Plus specifique et valide le contenu  methode courte
      Assert.That(result, Is.EquivalentTo(new[] { 2, 0, 4, 6 }));

      //// Methode qui valide l ordre
      Assert.That(result, Is.Ordered);
      Assert.That(result, Is.Unique);
    }

  }
}
