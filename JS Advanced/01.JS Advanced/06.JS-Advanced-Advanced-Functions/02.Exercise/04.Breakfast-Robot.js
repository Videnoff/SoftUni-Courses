function solve() {

    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            fat: 10,
            carbohydrate: 10,
            flavour: 10
        },
    };

    const stocks = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };
    const commands = {
        restock: (microelement, quantity) => {
            stocks[microelement] += quantity;
            return 'Success';
        },
        prepare: (product, quantity) => {
            let recipe = Object.entries(recipes[product]);

            for (let [item, countNeeded] of recipe) {
                if (stocks[item] < countNeeded * quantity) {
                    return `Error: not enough ${item} in stock`;
                }
            }

            recipe.forEach(([item, countNeeded]) => {
                stocks[item] -= countNeeded * quantity;
            });

            return 'Success'
        },
        report: () => Object.entries(stocks).map(([microelement, count]) => `${microelement}=${count}`).join(' ')
    };
    return (input) => {
        let [command, item, count] = input.split(' ');
        return commands[command](item, +count);
    }
}

let manager = solve();
console.log(manager("restock flavour 50"));  // Success
console.log(manager("prepare lemonade 4"));  // Error: not enough carbohydrate in stock

console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));

console.log(manager('turkey 1'));
console.log(manager('restock protein 10'));
console.log(manager('prepare turkey 1'))
console.log(manager('restock carbohydrate 10'))
console.log(manager('prepare turkey 1'))
console.log(manager('restock fat 10'))
console.log(manager('prepare turkey 1'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare turkey 1'));
console.log(manager('report'));

