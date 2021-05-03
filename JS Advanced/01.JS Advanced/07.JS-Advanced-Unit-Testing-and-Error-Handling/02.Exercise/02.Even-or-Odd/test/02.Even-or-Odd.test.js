const isOddOrEven = require('../02.Even-or-Odd');
const {expect} = require('chai');

describe('isEvenOrOdd', function () {
    describe('check isEvenOrOdd', function () {
        it('should return undefined if type not string', function () {
            expect(isOddOrEven(1)).to.equal(undefined);
        });
        it('should return odd if length not even', function () {
            expect(isOddOrEven('asd')).to.equal('odd');
        });
        it('should return even if length not odd', function () {
            expect(isOddOrEven('asdasd')).to.equal('even');
        });
    });
});