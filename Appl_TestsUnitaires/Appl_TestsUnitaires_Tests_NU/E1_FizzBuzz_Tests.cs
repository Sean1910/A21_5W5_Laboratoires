using NUnit.Framework;
using Appl_TestsUnitaires;

namespace Appl_TestsUnitaires_Tests_NU
{
  public class E1_FizzBuzz_Tests
  {
    
    [Test]
    public void GetOutput_Div3And5_ReturnFizzBuzz()
    {
      // Arrange
      int Valeur = 15;

      // Act
      var Result = E1_FizzBuzz.GetOutput(Valeur);

      // Assert
      // par défaut: sensible aux majuscules/minuscules
      Assert.That(Result, Is.EqualTo("FizzBuzz"));
     }

    [Test]
    public void GetOutput_Div3_ReturnFizz()
    {
      // Arrange
      int Valeur = 3;

      // Act
      var Result = E1_FizzBuzz.GetOutput(Valeur);

      // Assert
      // par défaut: sensible aux majuscules/minuscules
      Assert.That(Result, Is.EqualTo("fizz"));
      // Insensible aux majuscules/minuscules 
      Assert.That(Result, Is.EqualTo("fizz").IgnoreCase);

    }

    [Test]
    public void GetOutput_Div5_ReturnBuzz()
    {
      // Arrange
      int Valeur = 5;

      // Act
      var Result = E1_FizzBuzz.GetOutput(Valeur);

      // Assert
      // par défaut: sensible aux majuscules/minuscules
      Assert.That(Result, Is.EqualTo("Buzz"));
   
    }

    [Test]
    public void GetOutput_NonDiv3OrDiv5_ReturnParametre()
    {
      // Arrange
      int Valeur = 7;

      // Act
      var Result = E1_FizzBuzz.GetOutput(Valeur);

      // Assert
      // par défaut: sensible aux majuscules/minuscules
      Assert.That(Result, Is.EqualTo("7"));
    }
  }
}