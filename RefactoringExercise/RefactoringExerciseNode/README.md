# RefactoringExcerciseNode

1. Run npm install
2. Run npm test to run the unit tests

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

    1. If any of the following are not met, an error is thrown
        * Matching country must be found (matches either passed in id or name)
        * Postal code is required if the matching country is US*
            ** If postal code is required it must be in the format ##### or #####-####
    2. Country of address object that's returned from populateDetails should be set to matching country
    3. Postal code of address object that's returned from populateDetails should be set to postal code that's passed in where applicable.

    Use case(s):
    * Customer types in free form address, which is parsed/split by a tool
    * Upstream code does some pre-processing/massaging of the parsed address data
    * Calling code will have either an integer country id or a string that represents either a country name or abbreviation
    * (from the perspective of the consuming code, it could be either)
    * Calling code *may* have a zip code

    Hints/Suggestions
    * Nothing is off the table (code removal, moving things around,
    * method/module extraction, renaming, changing signatures, using modern language features, etc.) as long as the requirements are met.
    * The existing tests may be updated if necessitated by your refactoring.
    * Focus on cleaning up the code in the addressHandler.js file; the mock repository can be left as-is.
    * Read through and get a high-level understanding of the flow of the populateDetails method before starting
    * (the tests can help with this).
    * Ask questions whenever anything isn't clear!
