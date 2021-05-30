const stringOperations = require('../03.String-Operations');
const {expect} = require('chai');

describe('stringOperations', function () {
    describe('stringSlicer', function () {
        let str1 = 'asdasd';
        let str2 = 'as';
        let str3 = 'asd';
        let str4 = '';

        it('should return the first 3 chars of the str', function () {
            expect(stringOperations.stringSlicer(str1)).to.equal('asd...');
        });

        it('should return the whole string', function () {
            expect(stringOperations.stringSlicer(str2)).to.equal('as...')
        });

        it('should return the whole string', function () {
            expect(stringOperations.stringSlicer(str3)).to.equal('asd...')
        });

        it('should return the whole string', function () {
            expect(stringOperations.stringSlicer(str4)).to.equal('...')
        });
    });

    describe('wordChecker', function () {
        let word1 = 'someWord';
        let text1 = 'not Found';

        let word2 = 'anotherWord';
        let text2 = 'Insert the Contents of One Word Document into anotherWord';

        let word3 = 1;
        let text3 = 'Insert the Contents of One Word Document into anotherWord';

        it('should check if the word is not existing in the text', function () {
            expect(stringOperations.wordChecker(word1, text1)).to.equal(`${word1.toLowerCase().trim()} not found!`);
        });

        it('should check if the word is existing in the text', function () {
            expect(stringOperations.wordChecker(word2, text2)).to.equal(word2.toLowerCase().trim());
        });

        it('should check if the word is not existing in the text', function () {
            expect(stringOperations.wordChecker.bind(word3, text3)).to.throw('Cannot read property \'toLowerCase\' of undefined');
        });
    });

    describe('printEveryNthElement', function () {
        let num1 = 2;
        let arr1 = [1, 2, 3, 4, 5, 6];

        let num2 = 'a';
        let arr2 = 2;

        let num3 = 3;
        let arr3 = undefined;

        let num4 = 'b';
        let arr4 = 0;

        let num5 = 'b';
        let arr5 = 'c';

        let num6 = 1;
        let arr6 = [1];

        it('should return every nth element', function () {
            expect(stringOperations.printEveryNthElement(num1, arr1)).to.deep.equal([1, 3, 5]);
        });

        it('should return invalid input', function () {
            expect(stringOperations.printEveryNthElement.bind(num2, arr2)).to.throw("The input is not valid!");
        });

        it('should return invalid input with undefined', function () {
            expect(stringOperations.printEveryNthElement.bind(num3, arr3)).to.throw('The input is not valid!');
        });

        it('should return invalid input with letter', function () {
            expect(stringOperations.printEveryNthElement.bind(num4, arr4)).to.throw('The input is not valid!');
        });

        it('should return invalid input with letters', function () {
            expect(stringOperations.printEveryNthElement.bind(num5, arr5)).to.throw('The input is not valid!');
        });

        it('should return every nth element with 1', function () {
            expect(stringOperations.printEveryNthElement(num6, arr6)).to.deep.equal([1]);
        });
    });
});