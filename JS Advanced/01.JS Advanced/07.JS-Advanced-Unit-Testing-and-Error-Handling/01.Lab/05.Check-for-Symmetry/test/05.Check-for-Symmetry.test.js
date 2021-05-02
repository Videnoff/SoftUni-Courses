const {expect} = require('chai');
const isSymmetric = require('../05.Check-for-Symmetry');

describe('isSymmetric', function () {
    it('should work with valid symmetric input', function () {
        expect(isSymmetric([1, 1])).to.equal(true);
    });

    it('should work with valid non-symmetric input', function () {
        expect(isSymmetric([1, 2])).to.equal(false);
    });

    it('should return false for type-coerced elements', function () {
        expect(isSymmetric(['1', 1])).to.equal(false);
    });

    it('should return false for invalid argument', function () {
        expect(isSymmetric('a')).to.equal(false);
    });

    it('should return true for valid symmetric odd-element array', function () {
        expect(isSymmetric([1, 1, 1])).to.equal(true);
    });

    it('should return true for valid symmetric string array', function () {
        expect(isSymmetric(['a', 'a'])).to.equal(true);
    });

    it('should return false for valid non-symmetric string array', function () {
        expect(isSymmetric(['a', 'b'])).to.equal(false);
    });
});