function solve(arr, num) {
    for (let i = 0; i < num; i++) {
        arr.unshift(arr[arr.length - 1]);
        arr.pop();
    }

    return arr.join(' ');
}

console.log(solve(['1',
        '2',
        '3',
        '4'],
    2
));

console.log(solve(['Banana',
        'Orange',
        'Coconut',
        'Apple'],
    15
));