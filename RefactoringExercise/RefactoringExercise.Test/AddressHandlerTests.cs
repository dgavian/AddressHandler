using NUnit.Framework;
using System;

namespace RefactoringExercise.Test
{
    [TestFixture]
    public class AddressHandlerTests
    {
        [Test]
        public void PopulateDetails_MatchingCountryUSA_ReturnsExpectedAddress()
        {
            var countryId = 1;
            string countryName = null;
            var postalCode = "12345";

            var actual = AddressHandler.PopulateDetails(countryId, countryName, postalCode);

            Assert.NotNull(actual?.Country);
            Assert.AreEqual("United States", actual.Country.Name);
            Assert.AreEqual(postalCode, actual.PostalCode);
        }

        [Test]
        public void PopulateDetails_MatchingCountryCanada_DoesNotRequirePostalCode()
        {
            int? countryId = null;
            string countryName = "Canada";
            string postalCode = null;

            var actual = AddressHandler.PopulateDetails(countryId, countryName, postalCode);

            Assert.NotNull(actual?.Country);
            Assert.AreEqual("Canada", actual.Country.Name);
            Assert.Null(actual.PostalCode);
        }

        [Test]
        public void PopulateDetails_MatchingCountryCanada_DoesNotValidatePostalCode()
        {
            int? countryId = 2;
            string countryName = null;
            string postalCode = "CAN-456";

            var actual = AddressHandler.PopulateDetails(countryId, countryName, postalCode);

            Assert.NotNull(actual?.Country);
            Assert.AreEqual("Canada", actual.Country.Name);
            Assert.AreEqual(postalCode, actual.PostalCode);
        }

        [Test]
        public void PopulateDetails_NoMatchingCountryId_Throws()
        {
            int? countryId = 42;
            string countryName = null;
            string postalCode = "12345";

            var ex = Assert.Throws<InvalidOperationException>(() => AddressHandler.PopulateDetails(countryId, countryName, postalCode));

            StringAssert.Contains("Country", ex.Message);
        }

        [Test]
        public void PopulateDetails_NoPostalCodeForUSCountry_Throws()
        {
            int? countryId = null;
            string countryName = "United States";
            string postalCode = null;

            var ex = Assert.Throws<ArgumentNullException>(() => AddressHandler.PopulateDetails(countryId, countryName, postalCode));

            StringAssert.Contains("input", ex.Message);
        }

        [Test]
        public void PopulateDetails_InvalidPostalCodeForUSCountry_Throws()
        {
            int? countryId = null;
            string countryName = "United States";
            string postalCode = "12321-";

            var ex = Assert.Throws<InvalidOperationException>(() => AddressHandler.PopulateDetails(countryId, countryName, postalCode));

            StringAssert.Contains("PostalCode", ex.Message);
        }
    }
}
