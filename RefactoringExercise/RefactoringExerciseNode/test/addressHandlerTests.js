(function () {
    'use strict';

    const chai = require('chai');
    const should = require('chai').should();

    const sut = require('../service/addressHandler').AddressHanler;

    describe('Address Handler Tests', function () {
        it('should return expected address when PopulateDetails is called with USA country id', function () {
            let countryId = 1,
                countryName,
                postalCode = "12345";

            const actual = sut.populateDetails(countryId, countryName, postalCode);

            actual.should.exist;
            actual.country.name.should.equal("United States");
            actual.postalCode.should.equal(postalCode);
        });

        it('should return expected address without postal code when PopulateDetails is called with Canada country string', function () {
            let countryId,
                countryName = "Canada",
                postalCode;

            const actual = sut.populateDetails(countryId, countryName, postalCode);

            actual.should.exist;
            actual.country.name.should.equal("Canada");
            should.not.exist(actual.postalCode);
        });

        it('should not validate postal code when PopulateDetails is called with Canada country id', function () {
            let countryId = 2,
                countryName,
                postalCode = "CAN-456";

            const actual = sut.populateDetails(countryId, countryName, postalCode);

            actual.should.exist;
            actual.country.name.should.equal("Canada");
            actual.postalCode.should.equal(postalCode);
        });

        it('should throw Country error when PopulateDetails is called with invalid country id', function () {
            let countryId = 42,
                countryName,
                postalCode = "12345";


            (() => sut.populateDetails(countryId, countryName, postalCode)).should.throw(RangeError, "country");
        });

        it('should throw input error when PopulateDetails is called with United States and no postal code', function () {
            let countryId,
                countryName = "United States",
                postalCode;


            (() => sut.populateDetails(countryId, countryName, postalCode)).should.throw(TypeError, "input is null");
        });

        it('should throw PostalCode error when PopulateDetails is called with United States and invalid postal code', function () {
            let countryId,
                countryName = "United States",
                postalCode = "12345-";


            (() => sut.populateDetails(countryId, countryName, postalCode)).should.throw(RangeError, "postalCode")
        });
    });
}());