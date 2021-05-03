const lookupChar = require('../03.Char-Lookup');
const {expect} = require('chai');

describe('lookupChar', function () {
    describe('check type', function () {
        it('should return undefined if string is not string', function () {
            expect(lookupChar(1, 1)).to.equal(undefined);
        });
        it('should return undefined if index is not number', function () {
            expect(lookupChar('1', '1')).to.equal(undefined);
        });
        it('should return undefined if string is not string', function () {
            expect(lookupChar('1', 1.5)).to.equal(undefined);
        });
    });

    describe('check length', function () {
        it('should return Incorrect index if string length less than index', function () {
            expect(lookupChar('asdasd', 10)).to.equal('Incorrect index');
        });
        it('should return Incorrect index if index less than 0', function () {
            expect(lookupChar('asdasd', -1)).to.equal('Incorrect index');
        });
    });

    describe('check return', function () {
        it('should return ok', function () {
            expect(lookupChar('asdasd', 1)).to.equal('s');
        });
        it('should return ok', function () {
            expect(lookupChar('asdasd', 5)).to.equal('d');
        });
    });
});