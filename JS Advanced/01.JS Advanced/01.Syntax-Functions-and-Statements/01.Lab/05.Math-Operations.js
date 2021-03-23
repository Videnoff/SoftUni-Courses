function solve(num1, num2, str) {
    let result;

    if (str === '+') {
        result = num1 + num2;
    } else if(str === '-') {
        result = num1 - num2;
    } else if(str === '*') {
        result = num1 * num2;
    } else if(str === '/') {
        result = num1 / num2;
    } else if(str === '%') {
        result = num1 % num2;
    } else if(str === '**') {
        result = num1 ** num2;
    }

    return result;
}

console.log(solve(5, 6, '+'));
console.log(solve(3, 5.5, '*'));