function solve(arr) {
    let biggest = Number.NEGATIVE_INFINITY;
    arr.forEach(el => {
        el.forEach(num => {
            if (num > biggest) {
                biggest = num;
            }
        })
    })

    return biggest;
}

console.log(solve([[20, 50, 10],
    [8, 33, 145]]
));

console.log(solve([[3, 5, 7, 12],
    [-1, 4, 33, 2],
    [8, 3, 0, 4]]
));