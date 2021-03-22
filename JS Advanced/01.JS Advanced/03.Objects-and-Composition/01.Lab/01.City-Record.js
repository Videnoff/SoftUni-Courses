function solve(name, population, treasury) {
    let City = {
        name: name,
        population: population,
        treasury: treasury,
    }

    return City;
}

console.log(solve('Tortuga',
    7000,
    15000
))

console.log(solve('Santo Domingo',
    12000,
    23500
));
