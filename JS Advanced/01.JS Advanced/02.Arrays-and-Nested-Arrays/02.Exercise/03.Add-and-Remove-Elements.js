function solve(arr) {
    let num = 1;
    let newArr = [];
    for (let i = 0; i < arr.length; i++) {
        if (arr[i] === 'add') {
            newArr.push(num);
        } else {
            newArr.pop();
        }

        num++;
    }

    if (newArr.length === 0) {
        return 'Empty'
    }

    return newArr.join('\n');
}

console.log(solve(['add',
    'add',
    'add',
    'add']
));

console.log(solve(['add',
    'add',
    'remove',
    'add',
    'add']
));

console.log(solve(['remove',
    'remove',
    'remove']
));