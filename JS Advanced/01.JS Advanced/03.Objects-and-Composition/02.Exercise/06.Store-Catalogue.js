function solve(arr) {
    let list = [];
    let letter = new Set();

    for (const item of arr) {
        letter.add(item[0]);
        list.push(item.split(' : '));
    }

    list = list.sort((a, c) => a[0].localeCompare(c[0]));
    letter = Array.from(letter).sort((a, c) => a.localeCompare(c));
    for (const char of letter) {
        console.log(char);
        list.filter(x => x[0][0] === char).forEach(x => {
            console.log(`  ${x[0]}: ${x[1]}`)
        });
    }
}

console.log(solve(
    ['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']
));

console.log(solve(
    ['Banana : 2',
    'Rubic`s Cube : 5',
'Raspberry P : 4999',
    'Rolex : 100000',
    'Rollon : 10',
    'Rali Car : 2000000',
    'Pesho : 0.000001',
    'Barrel : 10']
));