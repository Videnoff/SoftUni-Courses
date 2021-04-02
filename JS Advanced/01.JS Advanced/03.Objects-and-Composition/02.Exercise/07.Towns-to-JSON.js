function solve(input) {
    let [columns, ...table] = input.map(splitLine);

    function isEmptyString(x) {
        return x !== '';
    }

    function convertIfNum(x) {
        return isNaN(x) ? x : Number(Number(x).toFixed(2));
    }

    function splitLine(input) {
        return input.split('|').filter(isEmptyString).map(x => x.trim()).map(convertIfNum);
    }

    return JSON.stringify(table.map(entry => {
        return columns.reduce((a, c, index) => {
            a[c] = entry[index]
            return a;
        }, {})
    }));
}

console.log(solve(
    ['| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |']
));

console.log(solve(
    ['| Town | Latitude | Longitude |',
    '| Veliko Turnovo | 43.0757 | 25.6172 |',
    '| Monatevideo | 34.50 | 56.11 |']
));