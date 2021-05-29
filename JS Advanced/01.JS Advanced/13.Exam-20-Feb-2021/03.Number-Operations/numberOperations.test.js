const numberOperations = require('./numberOperations');
const expect = require('chai').expect;

describe('test', () => {
    describe('powNumber', () => {
        //  there is no need of validation for the input
        it('check for 0', () => {
            expect(numberOperations.powNumber(0)).to.equal(0);
        });
        //	the function returns the power of the given number
        it('raises to n-th power', () => {
            expect(numberOperations.powNumber(1)).to.equal(1);
        });
        // negative
        it('negative', () => {
            expect(numberOperations.powNumber(3)).to.equal(9);
        });

    });
    describe('numberChecker', () => {
        //	the function parses the input to number, and validates it
        it('incorrect input 1', () => {
            expect(numberOperations.numberChecker.bind(numberOperations, 'a')).to.throw('The input is not a number!');
        });
        //  The number is lower than 100!
        it('lower than 100', () => {
            expect(numberOperations.numberChecker(1)).to.equal('The number is lower than 100!');
        });
        //  otherwise the function returns: "The number is greater or equal to 100!"
        it('equal to 100', () => {
            expect(numberOperations.numberChecker(100)).to.equal('The number is greater or equal to 100!');
        });
        //  otherwise the function returns: "The number is greater or equal to 100!"
        it('greater than 100', () => {
            expect(numberOperations.numberChecker(101)).to.equal('The number is greater or equal to 100!');
        });
    });
    describe('sumArrays', () => {
        //	the function loops through the arrays and sums the number on the first index in the first array with the number on the first index of the second array, then sums the number on the second index of the two arrays and so on.
        it('equal length arrays', () => {
            expect(numberOperations.sumArrays([1], [1])).to.deep.equal([2]);
        });
        it('first array longer', () => {
            expect(numberOperations.sumArrays([1, 2], [1])).to.deep.equal([2, 2]);
        });
        it('second array longer', () => {
            expect(numberOperations.sumArrays([1], [1, 2])).to.deep.equal([2, 2]);
        });
        it('one array empty', () => {
            expect(numberOperations.sumArrays([], [1, 2, 3])).to.deep.equal([1, 2, 3]);
        });
        it('sum indexes', () => {
            expect(numberOperations.sumArrays([1, 2, 3], [4, 5, 6])).to.deep.equal([5, 7, 9]);
        });
        
        //  The function returns new array, which represents the sum of the two arrays by indexes
        it('return new Array', () => {
            expect(numberOperations.sumArrays([1], [2])).to.deep.equal([3]);
        });
    });
    
});