"use strict";

const CountryRepository = require('./countryRepository').CountryRepository;

exports.ValidationHandler = {
    isValidUsPostalCode: function (input) {
        if (!input) {
            throw new TypeError("input is null");
        }
        let re = new RegExp(/^\d{5}(-\\d{4})?$/);
        return re.test(input);
    }
};

const ValidationHandler = exports.ValidationHandler;
exports.AddressHanler = {
    populateDetails: function (countryId, countryName, postalCode) {
        const result = {
            postalCode: postalCode
        };
        const errors = [];

        // Simulate a call to data storage
        const repo = new CountryRepository();
        const countries = repo.getCountries();

        if (countries && countries.length) {
            var countryIndex = -1;

            //Get the country info
            if (!(countryIndex >= 0)) {
                countryIndex = countries.findIndex(c => c.countryId === countryId);
            }

            if (!(countryIndex >= 0) && !!countryName) {
                if (!(countryIndex >= 0)) {
                    //Try the name
                    countryIndex = countries.findIndex(c => c.name.toLowerCase() === countryName.toLowerCase());
                }
            }

            if (countryIndex >= 0) {
                //Set the country info
                result.country = countries[countryIndex];
            } else {
                errors.push("country");
            }

            //Enforce the Postal Code Requirement
            if (countryIndex >= 0) {
                if (countries[countryIndex].postalCodeRequired && countries[countryIndex].shortName === "US") {
                    var isValid = ValidationHandler.isValidUsPostalCode(result.postalCode);
                    if (!isValid) {
                        errors.push("postalCode");
                    }
                }
            }
        } else {
            errors.push('countries');
        }

        var firstValidationFailure = errors.length ? errors[0] : null;
        if (firstValidationFailure) {
            throw new RangeError(firstValidationFailure);
        }

        return result;
    }
};