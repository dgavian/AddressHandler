using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace RefactoringExercise
{
    public static class AddressHandler
    {
        /*
            Refactoring Exercise

            Intro:
            One definition of legacy code is "Code that works". The code in this file
            works, but it could benefit from some clean-up. *Note*: this is not an implementation
            exercise as the code is already implemented and already works. It's covered by
            unit tests that test the required happy path and error conditions. The tests
            are all passing and can be run during refactoring to verify that nothing has broken.
            The goal here is to make the code cleaner, more readable, and more maintainable.

            After refactoring, the following should continue to work (as tested in
            the unit tests):

            1. If any of the following are not met, an exception of the appropriate type is thrown
                * Matching country must be found (matches either passed in id or name)
                * Postal code is required if the matching country is US*
                    ** If postal code is required it must be in the format ##### or #####-####
            2. Country of address object that's returned from PopulateDetails should be set to matching country
            3. Postal code of address object that's returned from PopulateDetails should be set to
               postal code that's passed in where applicable.

            Use case(s):
            * Customer types in free form address, which is parsed/split by a tool
            * Upstream code does some pre-processing/massaging of the parsed address data
            * Calling code will have either an integer country id or a string that represents either a country name or abbreviation
            * (from the perspective of the consuming code, it could be either)
            * Calling code *may* have a zip code
            
            Hints/Suggestions
            * Nothing is off the table (code removal, moving things around,
            * method/class extraction, renaming, changing signatures, using modern language features, etc.) as long as the requirements are met.
            * The existing tests may be updated if necessitated by your refactoring.
            * Focus on cleaning up the code in this file (AddressHandler.cs); the DTOs, Main entry point, and mock repository can be left as-is.
            * Read through and get a high-level understanding of the flow of the PopulateDetails method before starting
            * (the tests can help with this).
            * Ask questions whenever anything isn't clear!
        */
        public static Address PopulateDetails(int? addressCountryId, string addressCountryName, string postalCode)
        {
            var result = new Address();
            result.PostalCode = postalCode;
            var errorList = new List<string>();

            // Simulate a call to data storage.
            var repo = new CountryRepository();
            var countries = repo.GetCountries();

            if (countries != null && countries.Count > 0)
            {
                int countryIndex = -1;

                #region Get the Country Info

                if (addressCountryId != 0)
                    countryIndex = countries.FindIndex(c => c.CountryId.Equals(addressCountryId));

                if (!(countryIndex >= 0) && (!string.IsNullOrEmpty(addressCountryName)))
                {
                    if (!(countryIndex >= 0))
                        //Try the name
                        countryIndex = countries.FindIndex(c => !string.IsNullOrWhiteSpace(addressCountryName) && c.Name.Equals(addressCountryName, StringComparison.CurrentCultureIgnoreCase));
                }

                if (countryIndex >= 0)
                    //Set the country info
                    result.Country = countries[countryIndex];
                else
                    errorList.Add("Country");

                #endregion

                #region Enforce the Postal Code Requirement

                if (countryIndex >= 0)
                {
                    if (countries[countryIndex].PostalCodeRequired && countries[countryIndex].ShortName == "US")
                    {
                        //Postal code is required - add a validation failure
                        var isValid = ValidationHandler.IsValidUsPostalCode(result.PostalCode);
                        if (!isValid)
                        {
                            errorList.Add("PostalCode");
                        }
                    }
                }

                #endregion
            }
            else
            {
                //Unable to retrieve countries - create a validation failure
                errorList.Add("Countries");
            }

            var firstValidationFailure = errorList.FirstOrDefault();

            if (firstValidationFailure != null)
            {
                throw new InvalidOperationException(firstValidationFailure);
            }

            return result;
        }
    }

    public static class ValidationHandler
    {
        public static bool IsValidUsPostalCode(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (input == string.Empty)
            {
                throw new ArgumentException("cannot be empty", nameof(input));
            }
            var pattern = @"^\d{5}(-\d{4})?$";
            return Regex.IsMatch(input, pattern);
        }
    }
}
