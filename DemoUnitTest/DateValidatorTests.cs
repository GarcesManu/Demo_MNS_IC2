using Demo;
namespace DemoUnitTest
{
    [TestClass]
    public class DateValidatorTests
    {
        private DateValidator _dateValidator;

        [TestInitialize]
        public void Init()
        {
            _dateValidator = new DateValidator("10-10-2024");
        }

        [TestMethod]
        public void CheckNumberOfDashes_WithTwoDashes_ReturnsTrue()
        {
            var result = _dateValidator.CheckNumberOfDashes();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("10--20-2025")]
        [DataRow("1020-2025")]
        [DataRow("10202025")]
        [DataRow("---------")]
        public void CheckNumberOfDashes_WithNotTwoDashes_ObjectInitializationThrowsException(string date)
        {
            Assert.ThrowsException<Exception>(() => new DateValidator(date));
        }

        [TestMethod]
        public void CheckAllNumbersAreIntegers_WithIntegers_ReturnsTrue()
        {
            var result = _dateValidator.CheckAllNumbersAreIntegers();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("qsd-10-2024")]
        [DataRow("10-qsdqsd-2024")]
        [DataRow("10-10-qsdqsd")]
        [DataRow("qsdqsd-qsdqsd-qsdqsd")]
        public void CheckAllNumbersAreIntegers_WithNonIntegers_ReturnsFalse(string date)
        {
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckAllNumbersAreIntegers();

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow("qsd-10-2024")]
        [DataRow("10-qsdqsd-2024")]
        [DataRow("10-10-qsdqsd")]
        [DataRow("qsdqsd-qsdqsd-qsdqsd")]
        public void ThrowExceptionIfNumbersAreNotIntegers_WithNonIntegers_ThrowsInvalidCastException(string date)
        {
            _dateValidator = new DateValidator(date);

            Assert.ThrowsException<InvalidCastException>(() => _dateValidator.ThrowExceptionIfNumbersAreNotIntegers());
        }

        [TestMethod]
        public void ThrowExceptionIfNumbersAreNotIntegers_WithIntegers_DoNothing()
        {
            _dateValidator.ThrowExceptionIfNumbersAreNotIntegers();

            // Cas particulier, ici, j'ai rien à vérifier en assertion, mais le fait de passer dans la méthode sans lever
            // D'exception est un test en soit.
        }

        [TestMethod]
        [DataRow("01-10-2024")]
        [DataRow("31-10-2024")]
        [DataRow("16-10-2024")]
        public void CheckDayNumber_WithCorrectDay_ReturnsTrue(string date)
        {
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckDayNumber();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("00-10-2024")]
        [DataRow("32-10-2024")]
        [DataRow("154-10-2024")]
        public void CheckDayNumber_WithIncorrectDay_ReturnsFalse(string date)
        {
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckDayNumber();

            Assert.IsFalse(result);
        }

        // Je fais pas les mois (par manque de temps, mais on aurait dû avoir deux tests)

        [TestMethod]
        [DataRow("01-10-2000")]
        [DataRow("01-10-2012")]
        [DataRow("01-10-2025")]
        // Pour avoir la borne de l'année du jour, il faut faire qqch de dynamique
        public void CheckYearNumber_WithCorrectYear_ReturnsTrue(string date)
        {
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckYearNumber();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CheckYearNumber_WithDynamicYear_ReturnsTrue()
        {
            var actualYear = DateTime.Now.Year;
            var date = $"10-10-{actualYear}";
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckYearNumber();

            Assert.IsTrue(result);
        }

        [TestMethod]
        [DataRow("10-10-1999")]
        [DataRow("10-10-1980")]
        public void CheckYearNumber_WithInferiorDate_ReturnsFalse(string date)
        {
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckYearNumber();

            Assert.IsFalse(result);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        [DataRow(180)]
        public void CheckYearNumber_WithHigherDynamicDate_ReturnsFalse(int value)
        {
            var actualYearPlusValue = DateTime.Now.Year + value;
            var date = $"10-10-{actualYearPlusValue}";
            _dateValidator = new DateValidator(date);

            var result = _dateValidator.CheckYearNumber();

            Assert.IsFalse(result);
        }
    }
}
