function solve(arr) {
    let towns = {};

    for (const townRecord of arr) {
        let [name, population] = townRecord.split(' <-> ');
        population = Number(population);

        if (towns[name] !== undefined) {
            population += towns[name];
        }

        towns[name] = population;
    }

    let result = [];

    for (let town in towns) {
        result.push(`${town} : ${towns[town]}`);
    }

    return result.join('\n');
}

console.log(solve(
    ['Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']
));

console.log(solve(
    ['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
));