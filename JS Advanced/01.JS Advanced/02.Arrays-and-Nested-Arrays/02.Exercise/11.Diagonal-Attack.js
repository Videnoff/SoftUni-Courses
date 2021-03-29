function solve(arr) {
    let matrix = [];
    let firstDiagonal = 0;
    let secondDiagonal = 0;
    
    arr.forEach(element => {
        let row = element.split(' ').map(Number);
        matrix.push(row);
    });

    for (let i = 0; i < arr.length; i++) {
        firstDiagonal += matrix[i][i];
        secondDiagonal += matrix[i][matrix.length - 1 - i];
    }

    if (!(firstDiagonal === secondDiagonal)) {
        matrix.forEach(row => {
            console.log(row.join(' '));
        });

        return;
    }

    for (let i = 0; i < matrix.length; i++) {
        let row = matrix[i];
        let firstDiag = `${i}${i}`;
        let secondDiag = `${[i]}${[matrix.length - 1 - i]}`;

        for (let j = 0; j < row.length; j++) {
            let elementPos = `${i}${j}`;

            if (elementPos !== firstDiag && elementPos !== secondDiag) {
                matrix[i][j] = firstDiagonal;
            }
        }
    }

    matrix.forEach(row => {
        console.log(row.join(' '));
    });
}

solve(['5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']
);

solve(['1 1 1',
    '1 1 1',
    '1 1 0']
);