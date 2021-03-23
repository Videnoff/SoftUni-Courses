function solve(arr) {
    let sum = arr.reduce((a, c) =>
        a + c
    );

    let invSum = arr.reduce((a, c) => {
        return  a + (1 / c)
    }, 0);

    let concatResult = arr.reduce((a, c) =>
        a + c.toString()
    );

    console.log(sum);
    console.log(invSum);
    console.log(concatResult);
}

solve([1, 2, 3]);
solve([2, 4, 8, 16]);