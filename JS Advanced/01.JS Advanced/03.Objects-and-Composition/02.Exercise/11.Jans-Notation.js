function solve(arr) {
    let operations = {
        '+': (first, second) => first + second,
        '-': (first, second) => first - second,
        '*': (first, second) => first * second,
        '/': (first, second) => first / second,
    }
    
    let numbers = [];

    for (const item of arr) {
        if (Number.isFinite(item)) {
            numbers.push(item);
        } else {
            if (numbers.length < 2) {
                return 'Error: not enough operands!';
            } else {
                let second = numbers.pop();
                let first = numbers.pop();
                numbers.push(operations[item](first, second));
            }
        }
    }

    return numbers.length > 1 ? 'Error: too many operands!' : numbers[0];
}

console.log(solve(
    [3,
        4,
        '+']
));

console.log(solve(
    [5,
        3,
        4,
        '*',
        '-']
));

console.log(solve(
    [7,
        33,
        8,
        '-']
));

console.log(solve(
    [15,
    '/']
));