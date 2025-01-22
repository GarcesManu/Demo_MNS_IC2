using Demo;
namespace DemoUnitTest;

[TestClass]
public class CalculatorTests
{
    
    private Calculator _calculator;
    
    [TestInitialize]
    public void Init()
    {
        _calculator = new Calculator();
    }




    [TestMethod]
    [DataRow(-1)]
    [DataRow(-1000)]
    [DataRow(-256)]
    public void add_WithFirstNumberAsNegativeNumber_ThrowsArgumentException(int numberOne)
    {
        Assert.ThrowsException<ArgumentException>(() => _calculator.Add(numberOne, 40));
    }
    
    
    
    
    
    [TestMethod]
    [DataRow(10, 5, 15)]

    public void CalculatorAdd_WithValidInputs_ReturnsSum(int numberOne, int numberTwo, int expectedResult)
    {
        
        // Arrange
  

        // Act
        int result = _calculator.Add(numberOne, numberTwo);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(100, 20, 80)]

    public void CalculatorSubtract_WithValidInputs_ReturnsSubtract( int numberOne, int numberTwo, int expectedResult)
    {

    
        int result = _calculator.Substract(numberOne, numberTwo);
    
        Assert.AreEqual(expectedResult, result);
    }

    [TestMethod]
    [DataRow(2, 10, 20)]
    public void CalculatorMultiply_WithValidInputs_ReturnsMultiply(int numberOne, int numberTwo, int expectedResult)
    {

        
        int result = _calculator.Multiply(numberOne, numberTwo);
        
        Assert.AreEqual(expectedResult, result);
    }


    [TestMethod]
    [DataRow(10, 2, 5)]
    public void CalculatorDivide_WithValidInputs_ReturnsDivide(int numberOne, int numberTwo, int expectedResult)
    {

        
        float result = _calculator.Divide(numberOne, numberTwo);
        
        Assert.AreEqual(expectedResult, result);
    }
    
    [TestMethod]
    public void CalculatorDivide_DivideByZero_ThrowsArgumentException(){
        
        
        // Arrange
        int numberOne = 10;
        int numberTwo = 0;

        // Act & Assert
        var exception = Assert.ThrowsException<ArgumentException>(() => _calculator.Divide(numberOne, numberTwo));
        Assert.AreEqual("You cannot divide by zero", exception.Message);
    }

}