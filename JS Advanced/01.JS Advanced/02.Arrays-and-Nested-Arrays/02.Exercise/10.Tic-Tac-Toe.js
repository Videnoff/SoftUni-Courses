function solve(arr) {

    let currentPlayer = 'X';

    let gameArr = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ];

    for (const coordinates of arr) {
        let [x, y] = coordinates.split(' ').map(Number);

        if (gameArr[x][y] !== false) {
            console.log('This place is already taken. Please choose another!');
        } else {
            if (currentPlayer === 'X') {
                gameArr[x][y] = 'X';
                currentPlayer = 'O';
            } else {
                gameArr[x][y] = 'O';
                currentPlayer = 'X';
            }
        }

        let result = checkGameStatus(gameArr);

        if (result && result !== 'none') {
            console.log(`Player ${result} wins!`)
            gameArr.forEach(row => {
                console.log(row.join('\t'));
            });
            return;
        } else if (result === 'none') {
            console.log('The game ended! Nobody wins :(');
            gameArr.forEach(row => {
                console.log(row.join('\t'));
            });

            return;
        }
    }

    function checkGameStatus(arr) {
        let firstDiag = [];
        let secondDiag = [];
        let winner = '';

        for (let i = 0; i < gameArr.length; i++) {
            let currentCol = [];
            let row = gameArr[i];
            firstDiag.push(row[i]);
            secondDiag.push(row[row.length - 1 - i]);

            if (row.every(el => checkElement(el, 'X'))) {
                return winner = 'X';
            } else if (row.every(el => checkElement(el, 'O'))) {
                return winner = 'O';
            }

            for (let j = 0; j < gameArr.length; j++) {
                currentCol.push(arr[j][i]);

                if (currentCol.every(el => checkElement(el, 'X')) && currentCol.length === 3) {
                    return winner = 'X';
                } else if (currentCol.every(el => checkElement(el, 'O')) && currentCol.length === 3) {
                    return winner = 'O';
                }
            }
        }

        if (firstDiag.every(el => checkElement(el, 'X')) || secondDiag.every(el => checkElement(el, 'X'))) {
            return winner = 'X';
        } else if (firstDiag.every(el => checkElement(el, 'O')) || secondDiag.every(el => checkElement(el, 'O'))) {
            return winner = 'O';
        }

        let isBoardFull = [];

        for (let element of gameArr) {
            if (element.includes(false)) {
                isBoardFull.push(false);
            } else {
                isBoardFull.push(true);
            }
        }

        if (isBoardFull.every(el => el === true)) {
            return winner = 'none';
        }
    }

    function checkElement(el, type) {
        return el === type;
    }
}

console.log(solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 1",
    "1 2",
    "2 2",
    "2 1",
    "0 0"]
));

console.log(solve(["0 0",
    "0 0",
    "1 1",
    "0 1",
    "1 2",
    "0 2",
    "2 2",
    "1 2",
    "2 2",
    "2 1"]
));

console.log(solve(["0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]
));