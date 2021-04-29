function solve() {
    let result = [];
    let count = {};
    [...arguments].forEach(arg => {
        let type = typeof arg;
        result.push({ type, value: arg })
        if (count[type] !== undefined) {
            count[type]++;
        }
        else count[type] = 1;
    })
    result.forEach(a => console.log(`${a.type}: ${a.value}`))

    let sort = Object.entries(count).sort((a, b) => b[1] - a[1]);
    sort.forEach(a => console.log(`${a[0]} = ${a[1]}`))
}

solve('cat', 42, function () { console.log('Hello world!'); })