const dealership = require('../03.Dealership');
const {expect} = require('chai');

describe('dealership', function () {
    describe('newCarCost', function () {
        it('should return original price when model unsupported', function () {
            expect(dealership.newCarCost('a', 1)).to.equal(1);
        });

        it('should return discounted price', function () {
            expect(dealership.newCarCost('Audi A4 B8', 30000)).to.equal(15000);
        });
    });

    describe('carEquipment', function () {
        it('should return single element, single pick', function () {
            expect(dealership.carEquipment(['a'], [0])).to.deep.equal(['a']);
        });

        it('should return single element, single pick', function () {
            expect(dealership.carEquipment(['a', 'b', 'c'], [0, 2])).to.deep.equal(['a', 'c']);
        });

        it('should return single element, single pick', function () {
            expect(dealership.carEquipment(['a', 'b', 'c'], [1])).to.deep.equal(['b']);
        });
    });

    describe('euroCategory', function () {
        it('should check if category is bellow threshold', function () {
            expect(dealership.euroCategory(1)).to.equal('Your euro category is low, so there is no discount from the final price!');
        });

        it('should check if category is above threshold', function () {
            expect(dealership.euroCategory(5)).to.equal(`We have added 5% discount to the final price: 14250.`)
        });

        it('should check if category is at threshold (edge case)', function () {
            expect(dealership.euroCategory(4)).to.equal('We have added 5% discount to the final price: 14250.')
        });
    });
});