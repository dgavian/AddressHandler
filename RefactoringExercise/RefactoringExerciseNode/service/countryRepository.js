"use strict";

const countryRepository = function () {
    this.getCountries = function () {
        let countries = [
            {
                countryId: 1,
                name: "United States",
                shortName: "US",
                postalCodeRequired: true,
                stateProvinces: [
                    {
                        name: "Colorado",
                        shortName: "CO",
                        stateProvinceId: 6
                    },
                    {
                        name: "Nevada",
                        shortName: "NV",
                        stateProvinceId: 28
                    }
                ]
            },
            {
                countryId: 2,
                name: "Canada",
                shortName: "CA",
                postalCodeRequired: false,
                stateProvinces: [
                    {
                        name: "Quebec",
                        shortName: "Quebec",
                        stateProvinceId: 52
                    }
                ]
            }
        ];
        return countries;
    };
};
exports.CountryRepository = countryRepository;