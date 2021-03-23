function solve(str) {
    let result = str.toUpperCase().match(/\w+/g).join(', ');
    return result;
}

console.log(solve('Hi, how are you?'));
console.log(solve('hello'));