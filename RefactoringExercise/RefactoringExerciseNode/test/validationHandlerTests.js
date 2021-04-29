(function () {
    'use strict';

    const chai = require('chai');
    const should = require('chai').should();

    const sut = require('../service/addressHandler').ValidationHandler;

    describe('Validation Handler Tests', function () {
        it('should return true when IsValidUsPostalCode is called with valid value', function () {
            const actual = sut.isValidUsPostalCode('90210');

            actual.should.be.true;
        });

        it('should return false when IsValidUsPostalCode is called with invalid value', function () {
            const actual = sut.isValidUsPostalCode('9021');

            actual.should.be.false;
        });
    });
}());