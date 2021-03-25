function solve(arr) {
    let newArr = [];
    for (let i = 0; i <= arr.length - 1; i++) {
        if (i % 2 !== 0) {
            newArr.push(arr[i] * 2);
        }
    }

    return newArr.reverse().join(' ');
}

console.log(solve([10, 15, 20, 25]));
console.log(solve([3, 0, 10, 4, 7, 3]));