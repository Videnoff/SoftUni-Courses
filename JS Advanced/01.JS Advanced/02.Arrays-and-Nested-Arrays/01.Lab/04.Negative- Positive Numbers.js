function solve(arr) {
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] < 0) {
            result.unshift(arr[i]);
        } else {
            result.push(arr[i]);
        }
    }

    return result;
}

console.log(solve([7, -2, 8, 9]));
console.log(solve([3, -2, 0, -1]));