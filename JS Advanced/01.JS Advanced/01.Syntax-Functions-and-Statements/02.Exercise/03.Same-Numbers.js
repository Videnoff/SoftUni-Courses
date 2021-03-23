function solve(num) {
    let numAsStr = String(num);

    let result = true;
    let sum = 0;

    for (let i = 0; i < numAsStr.length; i++) {
        let curr = Number(numAsStr[i]);
        if (curr !== Number(numAsStr[i + 1]) && numAsStr[i + 1] !== undefined) {
            result = false;
        }

        sum += curr;
    }

    return `${result}\n${sum}`
}

console.log(solve(2222222));
console.log(solve(1234));