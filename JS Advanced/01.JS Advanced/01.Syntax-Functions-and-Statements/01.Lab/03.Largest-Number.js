function solve(...params) {
    let result = params.reduce((a, c) => {
        return Math.max(a, c);
    });

    console.log(`The largest number is ${result}.`);
}

solve(5, -3, 16);
solve(-3, -5, -22.5);