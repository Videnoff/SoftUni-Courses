function solve(arr) {
    arr.sort((a, b) => a - b);

    let [a, b, ...params] = arr;
    return `${a} ${b}`;
}

console.log(solve([30, 15, 50, 5]));
console.log(solve([3, 0, 10, 4, 7, 3]));