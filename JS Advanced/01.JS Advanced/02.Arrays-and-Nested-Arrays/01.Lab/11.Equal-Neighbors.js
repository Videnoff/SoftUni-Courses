function solve(arr) {
    let neighbours = 0;

    for (let i = 0; i < arr.length - 1; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            if (arr[i][j] === arr[i][j + 1]) {
                neighbours++
            }

            if (arr[i][j] === arr[i + 1][j]) {
                neighbours++;
            }

            if (i === arr.length - 2 && arr[i + 1][j] === arr[i + 1][j + 1]) {
                neighbours++;
            }
        }
    }

    return neighbours;
}

console.log(solve([
        ['2', '3', '4', '7', '0'],
        ['4', '0', '5', '3', '4'],
        ['2', '3', '5', '4', '2'],
        ['9', '8', '7', '5', '4']
    ]
));

console.log(solve([
        ['test', 'yes', 'yo', 'ho'],
        ['well', 'done', 'yo', '6'],
        ['not', 'done', 'yet', '5']
    ]
));