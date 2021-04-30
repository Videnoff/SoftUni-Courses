const {expect} = require('chai');
const sum = require('../04.Sum-of-Numbers');

describe('Sum numbers', () => {
    it('should Sums single number', function () {
        expect(sum([1])).to.equal(1);
    });

    it('should Sums multiple numbers', function () {
        expect(sum([1, 1])).to.equal(2);
    });

    it('should Sums different numbers', function () {
        expect(sum([2, 3, 4])).to.equal(9);
    });
})