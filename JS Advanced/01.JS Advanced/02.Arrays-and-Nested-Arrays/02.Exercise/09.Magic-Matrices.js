function solve(arr) {

    let rowSum = 0;
    let colSum = 0;

    let sumRows = [];
    let sumCols = [];

    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            rowSum += arr[i][j];
        }

        sumRows.push(rowSum);
        rowSum = 0;
    }

    for (let i = 0; i < arr.length; i++) {
        for (let j = 0; j < arr[i].length; j++) {
            colSum += arr[j][i];
        }

        sumCols.push(colSum);
        colSum = 0;
    }

    const allEqual = arr => arr.every(val => val === arr[0]);

    let rowResult = allEqual(sumRows);
    let colResult = allEqual(sumCols);

    if (rowResult && colResult ) {
        return true;
    } else {
        return false;
    }

}

console.log(solve([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
));

console.log(solve([[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
));

console.log(solve([[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
));