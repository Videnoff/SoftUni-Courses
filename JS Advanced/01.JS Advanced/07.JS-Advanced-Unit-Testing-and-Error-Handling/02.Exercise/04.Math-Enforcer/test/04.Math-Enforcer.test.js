const mathEnforcer = require('../04.Math-Enforcer');
const {expect} = require('chai');

describe('mathEnforcer', function () {
    describe('addFive', function () {
        it('should return undefined if not number', function () {
            expect(mathEnforcer.addFive('5')).to.equal(undefined);
        });
        it('should return undefined if not number', function () {
            expect(mathEnforcer.addFive(undefined)).to.equal(undefined);
        });
        it('should add 5 if number', function () {
            expect(mathEnforcer.addFive(3)).to.equal(8);
        });
        it('should add 5 if number', function () {
            expect(mathEnforcer.addFive(0)).to.equal(5);
        });
        it('should add 5 if number', function () {
            expect(mathEnforcer.addFive(-3)).to.equal(2);
        });
        it('should add 5 if number', function () {
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        });
        it('should add 5 if number', function () {
            expect(mathEnforcer.addFive(0.3)).to.equal(5.3);
        });
    });

    describe('subtractTen', function () {
        it('should return undefined if not number', function () {
            expect(mathEnforcer.subtractTen('5')).to.equal(undefined);
        });
        it('should return undefined if not number', function () {
            expect(mathEnforcer.subtractTen(undefined)).to.equal(undefined);
        });
        it('should subtract 10 if number', function () {
            expect(mathEnforcer.subtractTen(3)).to.equal(-7);
        });
        it('should subtract 10 if number', function () {
            expect(mathEnforcer.subtractTen(0)).to.equal(-10);
        });
        it('should subtract 10 if number', function () {
            expect(mathEnforcer.subtractTen(-1)).to.equal(-11);
        });
        it('should subtract 10 if number', function () {
            expect(mathEnforcer.subtractTen(5.5)).to.equal(-4.5);
        });
    });

    describe('sum', function () {
        it('should return undefined if first num not number', function () {
            expect(mathEnforcer.sum('1', 1)).to.equal(undefined);
        });
        it('should return undefined if second num not number', function () {
            expect(mathEnforcer.sum(1, '1')).to.equal(undefined);
        });
        it('should return undefined if both nums not number', function () {
            expect(mathEnforcer.sum('1', '1')).to.equal(undefined);
        });
        it('should return undefined if second num undefined', function () {
            expect(mathEnforcer.sum(1, undefined)).to.equal(undefined);
        });
        it('should return correct sum if both positive numbers', function () {
            expect(mathEnforcer.sum(1, 1)).to.equal(2);
        });
        it('should return correct sum if first num negative', function () {
            expect(mathEnforcer.sum(-1, 1)).to.equal(0);
        });
        it('should return correct sum if both nums negative', function () {
            expect(mathEnforcer.sum(-1, -1)).to.equal(-2);
        });
        it('should return correct sum if first num not integer', function () {
            expect(mathEnforcer.sum(1.5, 1)).to.equal(2.5);
        });
        it('should return correct sum if first num zero', function () {
            expect(mathEnforcer.sum(0, 1)).to.equal(1);
        });
        it('should return correct sum if second num zero', function () {
            expect(mathEnforcer.sum(0, -1)).to.equal(-1);
        });
        it('should return correct sum if both not integers', function () {
            expect(mathEnforcer.sum(-2.5, -1.4)).to.equal(-3.9);
        });
    });
});