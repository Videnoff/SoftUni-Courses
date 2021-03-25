function solve(arr) {
    let mainSum = 0;
    let secondarySum = 0;

    for (let i = 0; i < arr.length; i++) {
        mainSum += arr[i][i];
        secondarySum += arr[i][arr.length - 1 - i];
    }

    return `${mainSum} ${secondarySum}`
}

console.log(solve([[20, 40],
    [10, 60]]
));

console.log(solve([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
));