function solve(n, m) {
    let sum = 0;

    for (let i = Number(n); i <= Number(m); i++) {
        sum += i;
    }

    return sum;
}

console.log(solve('1', '5'));
console.log(solve('-8', '20'));