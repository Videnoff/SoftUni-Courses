function solve(n, k) {
    let newArr = [1];

    for (let i = 1; i < n; i++) {
        let result = newArr.slice(-k);
        let sum = 0;

        for (let number of result) {
            sum += number;
        }

        newArr.push(sum);
    }

    newArr.join(' ');
    return newArr;
}

console.log(solve(6, 3));
console.log(solve(8, 2));