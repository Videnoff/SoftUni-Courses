function solve(arr) {
    let result = [];

    while (arr.length) {
        result.push(Math.min.apply(Math, arr));
        arr.splice(arr.indexOf(Math.min.apply(Math, arr)), 1);

        if (arr.length > 0) {
            result.push(Math.max.apply(Math, arr));
            arr.splice(arr.indexOf(Math.max.apply(Math, arr)), 1);
        }
    }

    return result;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18, 56, 72]));
