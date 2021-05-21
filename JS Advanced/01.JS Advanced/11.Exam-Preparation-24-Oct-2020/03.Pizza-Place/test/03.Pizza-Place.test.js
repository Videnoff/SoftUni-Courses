const {expect} = require('chai');
const pizzUni = require('../03.Pizza-Place');

describe('pizzUni', function () {
    it('should make an order', function () {
        let pizza = {orderedPizza: 'pizza', orderedDrink: 'drink'};
        let pizza1 = {orderedDrink: 'drink'};
        let pizza2 = {orderedPizza: 'pizza'};
        let pizza3 = {};

        expect(pizzUni.makeAnOrder.bind(pizzUni, pizza1)).to.throw('You must order at least 1 Pizza to finish the order.');

        expect(pizzUni.makeAnOrder(pizza2)).to.equal(`You just ordered ${pizza2.orderedPizza}`);

        expect(pizzUni.makeAnOrder.bind(pizzUni, pizza3)).to.throw(`You must order at least 1 Pizza to finish the order.`);

        expect(pizzUni.makeAnOrder(pizza)).to.equal(`You just ordered ${pizza.orderedPizza} and ${pizza.orderedDrink}.`)
    });

    it('should get remaining work', function () {
        let statusArr = [
            {pizzaName: 'pizza', status: 'ready'},
            {pizzaName: 'pizza2', status: 'ready'},
            {pizzaName: 'pizza3', status: 'preparing'},
            {pizzaName: 'pizza4', status: 'preparing'},
        ];

        let statusArr2 = [
            {pizzaName: 'pizza', status: 'ready'},
            {pizzaName: 'pizza2', status: 'ready'},
        ];

        let statusArr3 = [
            {pizzaName: 'pizza3', status: 'preparing'},
            {pizzaName: 'pizza4', status: 'preparing'},
        ];

        expect(pizzUni.getRemainingWork(statusArr2)).to.equal(`All orders are complete!`);

        expect(pizzUni.getRemainingWork(statusArr)).to.equal(`The following pizzas are still preparing: pizza3, pizza4.`)

        expect(pizzUni.getRemainingWork(statusArr3)).to.equal(`The following pizzas are still preparing: pizza3, pizza4.`)
    });

    it('should order Type', function () {
        let order1 = {
            totalSum: 100,
            typeOfOrder: 'Carry Out',
        }

        let order2 = {
            totalSum: 100,
            typeOfOrder: 'Delivery',
        }

        let order3 = {
            totalSum: -100,
            typeOfOrder: 'Delivery',
        }

        let order4 = {
            totalSum: -100,
            typeOfOrder: 'Carry Out',
        }

        let order5 = {
            totalSum: 0,
            typeOfOrder: 'Delivery',
        }

        let order6 = {
            totalSum: 0,
            typeOfOrder: 'Carry Out',
        }

        expect(pizzUni.orderType(order1.totalSum, order1.typeOfOrder)).to.equal(90);

        expect(pizzUni.orderType(order2.totalSum, order2.typeOfOrder)).to.equal(100);

        expect(pizzUni.orderType(order3.totalSum, order3.typeOfOrder)).to.equal(-100);

        expect(pizzUni.orderType(order4.totalSum, order4.typeOfOrder)).to.equal(-90);

        expect(pizzUni.orderType(order5.totalSum, order5.typeOfOrder)).to.equal(0);

        expect(pizzUni.orderType(order6.totalSum, order6.typeOfOrder)).to.equal(0);
    });
});