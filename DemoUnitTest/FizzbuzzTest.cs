using Demo;

namespace DemoUnitTest;

    [TestClass]
    public class FizzBuzzTests
    {
        private FizzBuzz _fizzBuzz;

        // Méthode appelée avant chaque test pour initialiser les dépendances
        [TestInitialize]
        public void Init()
        {
            _fizzBuzz = new FizzBuzz(); // Instancie l'objet FizzBuzz avant chaque test
        }

        [TestMethod]
        [DataRow(15, "FizzBuzz")]
        [DataRow(30, "FizzBuzz")]
        [DataRow(45, "FizzBuzz")]
        public void GetOutput_WhenDivisibleBy3And5_ReturnsFizzBuzz(int input, string expected)
        {
            // ACT
            var result = _fizzBuzz.GetOutput(input);

            // Console output
            Console.WriteLine($"Input: {input}, Expected: {expected}, Result: {result}");

            // ASSERT
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(5, "Buzz")]
        [DataRow(10, "Buzz")]
        [DataRow(20, "Buzz")]
        public void GetOutput_WhenDivisibleBy5Only_ReturnsBuzz(int input, string expected)
        {
            // ACT
            var result = _fizzBuzz.GetOutput(input);

            // Console output
            Console.WriteLine($"Input: {input}, Expected: {expected}, Result: {result}");

            // ASSERT
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(3, "Fizz")]
        [DataRow(6, "Fizz")]
        [DataRow(9, "Fizz")]
        public void GetOutput_WhenDivisibleBy3Only_ReturnsFizz(int input, string expected)
        {
            // ACT
            var result = _fizzBuzz.GetOutput(input);

            // Console output
            Console.WriteLine($"Input: {input}, Expected: {expected}, Result: {result}");

            // ASSERT
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(1, "1")]
        [DataRow(2, "2")]
        [DataRow(4, "4")]
        [DataRow(7, "7")]
        [DataRow(8, "8")]
        public void GetOutput_WhenNotDivisibleBy3Or5_ReturnsNumberAsString(int input, string expected)
        {
            // ACT
            var result = _fizzBuzz.GetOutput(input);

            // Console output
            Console.WriteLine($"Input: {input}, Expected: {expected}, Result: {result}");

            // ASSERT
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-15)]
        public void GetOutput_WhenNegative_ThrowsException(int input)
        {
            // ASSERT
            var exception = Assert.ThrowsException<ArgumentException>(() => _fizzBuzz.GetOutput(input));

            // Console output
            Console.WriteLine($"Input: {input}, Exception: {exception.Message}");

            // Validate exception message
            Assert.AreEqual("Value cannot be negative", exception.Message);
        }
    }

