using NUnit.Framework;

namespace RefactoringExercise.Test
{
    [TestFixture]
    public class ValidationHandlerTests
    {
        // What tests would you add based on the requirements?
        [TestCase("12345", true)]
        [TestCase("1234", false)]
        public void IsValidUsPostalCode_VariedInputs_ExpectedResults(string text, bool expected)
        {
            var actual = ValidationHandler.IsValidUsPostalCode(text);

            Assert.AreEqual(expected, actual);
        }
    }
}
