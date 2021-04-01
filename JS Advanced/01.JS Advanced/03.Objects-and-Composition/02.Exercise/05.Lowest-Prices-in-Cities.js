function solve(arr) {
    let list = new Map();
    for (const item of arr) {
        let [town, product, price] = item.split(' | ');
        if (!list.has(product)) {
            list.set(product, new Map());
        }

        list.get(product).set(town, Number(price));
    }

    for (const [car, data] of list) {
        let lowestPrice = [...data].reduce((a, c) => {
            if (a[1] > c[1]) {
                return c;
            }

            return a;
        })

        console.log(`${car} -> ${lowestPrice[1]} (${lowestPrice[0]})`);
    }
}

solve(
    [
        'Sample Town | Sample Product | 1000',
        'Sample Town | Orange | 2',
        'Sample Town | Peach | 1',
        'Sofia | Orange | 3',
        'Sofia | Peach | 2',
        'New York | Sample Product | 1000.1',
        'New York | Burger | 10'
    ]
)