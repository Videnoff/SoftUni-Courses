function solve(arr) {
    let result = [];
    while (arr.length) {
        let hero = arr.shift();

        let [name, level, itemsString] = hero.split(' / ');
        level = Number(level);
        let items = itemsString ? itemsString.split(', ') : [];

        result.push({name, level, items});
    }

    return JSON.stringify(result);

}

console.log(solve(
    [
        'Isacc / 25 / Apple, GravityGun',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara'
    ]
));

console.log(solve(
    [
        'Jake / 1000 / Gauss, HolidayGrenade'
    ]
));