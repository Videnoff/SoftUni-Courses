function solve(arr) {
    let [rows, cols, starRow, starCol] = arr;
    
    let matrix = [];

    for (let i = 0; i < rows; i++) {
        matrix.push([]);
    }

    for (let i = 0; i < rows; i++) {
        for (let j = 0; j < cols; j++) {
            matrix[i][j] = Math.max(Math.abs(i - starRow), Math.abs(j - starCol)) + 1;
        }
    }

    return matrix.map(row => row.join(' ')).join('\n');
}

console.log(solve([4, 4, 0, 0]));

console.log(solve([5, 5, 2, 2]));

console.log(solve([3, 3, 2, 2]));